using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spikes : MonoBehaviour
{
    private Rigidbody2D RB;
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            RB.constraints = RigidbodyConstraints2D.None;
            RB.gravityScale = 0.5f;
        }
    }
}