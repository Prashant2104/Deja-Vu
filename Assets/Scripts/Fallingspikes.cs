using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fallingspikes : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            transform.position = new Vector2(transform.position.x, 6);
        }
    }
}
