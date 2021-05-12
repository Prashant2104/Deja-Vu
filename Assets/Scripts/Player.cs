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
  

    private Rigidbody2D Rigidbody;
    private float InputX;
    private SpriteRenderer Spriterenderer;
    private Animator animator;
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
        Spriterenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Rigidbody.velocity = new Vector2(InputX * speed, Rigidbody.velocity.y);

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
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && IsGrounded())
        {
            Rigidbody.velocity = new Vector2(Rigidbody.velocity.x, jump);
        }
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
    }

    public void Pass()
    {
        CurrentLevel = SceneManager.GetActiveScene().buildIndex;

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