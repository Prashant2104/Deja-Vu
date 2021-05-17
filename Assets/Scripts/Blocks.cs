using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocks : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rigidBody2D;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        speed = Random.Range(1f, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        rigidBody2D.velocity = new Vector2(speed, rigidBody2D.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Trigger")
        {
            speed = speed * -1;
            transform.localScale = new Vector3((transform.localScale.x) * -1, transform.localScale.y, transform.localScale.z);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            speed = speed * -1;
            transform.localScale = new Vector3((transform.localScale.x) * -1, transform.localScale.y, transform.localScale.z);            
        }
    }
}