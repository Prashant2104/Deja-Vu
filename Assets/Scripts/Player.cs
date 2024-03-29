﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    int CurrentLevel;

    public bool Stop;
    public static int DeathCount = 0;
    public float speed, jump;
    public GameObject Key;
    public GameObject DeadBody;
    public Transform SpawnPoint;

    private Pause pause;
    private End end;
    private CameraManager Camera;
    private Rigidbody2D Rigidbody;
    private float InputX;
    private float InputY;
    private SpriteRenderer Spriterenderer;
    private Animator animator;
    void Start()
    {
        Stop = true;
        Time.timeScale = 1f;
        CurrentLevel = SceneManager.GetActiveScene().buildIndex;
        Camera = FindObjectOfType<CameraManager>();
        pause = FindObjectOfType<Pause>();
        end = FindObjectOfType<End>();
        Rigidbody = GetComponent<Rigidbody2D>();
        Spriterenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        if (CurrentLevel == 17)
        {
            StartCoroutine(Ninja());
        }
    }
    void Update()
    {
        if (Stop == true)
        {
            if (CurrentLevel != 10 || CurrentLevel != 16 || CurrentLevel != 21 || CurrentLevel == 20)
            {
                Rigidbody.velocity = new Vector2(InputX * speed, Rigidbody.velocity.y);
            }
            if (CurrentLevel == 16 || CurrentLevel == 20)
            {
                Rigidbody.velocity = new Vector2(-(InputX * speed), Rigidbody.velocity.y);
            }
            if (CurrentLevel == 10 || CurrentLevel == 21)
            {
                animator.SetBool("Walk", false);
                Rigidbody.velocity = new Vector2(InputX * speed, InputY * (speed / 2));
            }

            if (Rigidbody.velocity.x > 0f)
            {
                Spriterenderer.flipX = false;
                //gameObject.transform.GetChild(1).gameObject.transform.position = new Vector2(gameObject.transform.GetChild(1).gameObject.transform.position.x, gameObject.transform.GetChild(1).gameObject.transform.position.y);
            }
            else if (Rigidbody.velocity.x < 0f)
            {
                Spriterenderer.flipX = true;
                //gameObject.transform.GetChild(1).gameObject.transform.position = new Vector2(gameObject.transform.GetChild(1).gameObject.transform.position.x * -1, gameObject.transform.GetChild(1).gameObject.transform.position.y);
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
            if (CurrentLevel == 15)
            {
                Counter.C++;
                if (Counter.C == 10)
                {
                    Counter.C = 0;
                }
            }

            if (CurrentLevel == 23)
            {
                Rigidbody.gravityScale *= -1;
                Spriterenderer.flipY = !Spriterenderer.flipY;
            }
        }
        if (context.performed && CurrentLevel == 17)
        {
            Rigidbody.velocity = new Vector2(Rigidbody.velocity.x, jump);
        }
    }
    IEnumerator Ninja()
    {
        yield return new WaitForSeconds(1f);
        Spriterenderer.enabled = false;


        yield return new WaitForSeconds(5f);
        Spriterenderer.enabled = true;

        StartCoroutine(Ninja());
    }
    public void Pause_Start(InputAction.CallbackContext context)
    {
        //Debug.Log("Pause press");
        if(context.performed)
        {
            if (pause.IsPaused)
            {
                pause.OnResumeButtonClick();
                Time.timeScale = 1f;
            }
            else
            {
                pause.OnPauseButtonClick();
                Time.timeScale = 0f;
            }
        }
    }
    public void Hints(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            pause.OnHintsButtonClick();
        }
    }

    public void Kill()
    {
        DeathCount++;
        SceneManager.LoadScene(CurrentLevel);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Key"))
        {
            if (CurrentLevel != 13)
            {
                Destroy(collision.gameObject);
                gameObject.transform.GetChild(1).gameObject.SetActive(true);
            }            
        }

        if (collision.gameObject.CompareTag("Gate_On"))
        {
            animator.SetBool("Glitch", true);
            Rigidbody.velocity = new Vector2(0,0);
            Rigidbody.AddForce(new Vector2(3,3), ForceMode2D.Impulse);
        }

        if (collision.gameObject.CompareTag("Spikes"))
        {
            Kill();
        }

        if (collision.gameObject.CompareTag("Ending"))
        {
            end.Ending();
            Stop = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Gate_On"))
        {
            animator.SetBool("Glitch", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Finish"))
        {
            Pass();
        }

        if (collision.gameObject.CompareTag("Switch"))
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

        //Debug.Log("Level unlocked = " + PlayerPrefs.GetInt("LevelsUnlocked"));

        SceneManager.LoadScene(CurrentLevel + 1);
    }
    private bool IsGrounded()
    {
        if(CurrentLevel == 10 || CurrentLevel == 22)
        {
            return true;
        }
        return transform.Find("GroundCheck").GetComponent<GroundCheck>().isGrounded;
    }
}