using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Blocks : MonoBehaviour
{
    int CurrentLevel;
    public float speed;
    private Rigidbody2D rigidBody2D;
    void Start()
    {
        CurrentLevel = SceneManager.GetActiveScene().buildIndex;
        rigidBody2D = GetComponent<Rigidbody2D>();
        
        if (CurrentLevel == 6)
        {
            speed = Random.Range(0.5f, 8f);
        }
    }

    void Update()
    {
        rigidBody2D.velocity = new Vector2(speed, rigidBody2D.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Trigger"))
        {
            speed *= -1;
            transform.localScale = new Vector3((transform.localScale.x) * -1, transform.localScale.y, transform.localScale.z);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            speed *= -1;
            transform.localScale = new Vector3((transform.localScale.x) * -1, transform.localScale.y, transform.localScale.z);            
        }

        if (CurrentLevel == 14)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                rigidBody2D.constraints = RigidbodyConstraints2D.None;
                rigidBody2D.gravityScale = 0.5f;
            }
        }
    }
}