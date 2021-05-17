using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    int CurrentLevel;

    public float speed, jump;
    public GameObject Key;

    private Pause pause;
    private CameraManager Camera;
    private Rigidbody2D Rigidbody;
    private float InputX;
    private float InputY;
    private SpriteRenderer Spriterenderer;
    private Animator animator;
    void Start()
    {
        CurrentLevel = SceneManager.GetActiveScene().buildIndex;
        Camera = FindObjectOfType<CameraManager>();
        pause = FindObjectOfType<Pause>();
        Rigidbody = GetComponent<Rigidbody2D>();
        Spriterenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {        
        if(CurrentLevel != 10)
        {
            Rigidbody.velocity = new Vector2(InputX * speed, Rigidbody.velocity.y);
        }
        if(CurrentLevel == 10)
        {
            Rigidbody.velocity = new Vector2(InputX * speed, InputY * (speed / 2));
            animator.SetBool("Walk", false);
        }

        if (Rigidbody.velocity.x > 0f)
        {
            Spriterenderer.flipX = false;
        }
        else if (Rigidbody.velocity.x < 0f)
        {
            Spriterenderer.flipX = true;
        }

        if (IsGrounded())
        {
            animator.SetBool("Jump", false);            
        }
        else
        {
            animator.SetBool("Jump", true);
        }

        if (Rigidbody.velocity.x >= 0.1 && IsGrounded() || Rigidbody.velocity.x <= -0.1 && IsGrounded())
        {
            animator.SetBool("Walk", true);
        }
        else
        {
            animator.SetBool("Walk", false);
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        InputX = context.ReadValue<Vector2>().x;
        InputY = context.ReadValue<Vector2>().y;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && IsGrounded())
        {
            Rigidbody.velocity = new Vector2(Rigidbody.velocity.x, jump);
        }
    }
    public void Pause_Start(InputAction.CallbackContext context)
    {
        pause.PauseButton();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Key")
        {
            Destroy(collision.gameObject);
            gameObject.transform.GetChild(1).gameObject.SetActive(true);
        }

        if (collision.gameObject.tag == "Gate_On")
        {
            animator.SetBool("Glitch", true);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Gate_On")
        {
            animator.SetBool("Glitch", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Finish")
        {
            Pass();
        }

        if (collision.gameObject.tag == "Switch")
        {
            Camera.Move();
            if(Camera.Count == true)
            {
                collision.transform.position = new Vector2(11, 0);
            }
            if(Camera.Count == false)
            {
                collision.transform.position = new Vector2(14, 0);
            }
        }        
    }

    public void Pass()
    {
        if (CurrentLevel >= PlayerPrefs.GetInt("LevelsUnlocked"))
        {
            PlayerPrefs.SetInt("LevelsUnlocked", CurrentLevel + 1);
        }

        Debug.Log("Level unlocked = " + PlayerPrefs.GetInt("LevelsUnlocked"));

        SceneManager.LoadScene(CurrentLevel + 1);
    }
    private bool IsGrounded()
    {
        return transform.Find("GroundCheck").GetComponent<GroundCheck>().isGrounded;
    }
}