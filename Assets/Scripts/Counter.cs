using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    public static int C = 0;
    public Sprite[] Number;
    public bool Grounded = false;

    private SpriteRenderer spriteRenderer;
    private Gate gate;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        gate = FindObjectOfType<Gate>();
    }
    private void Update()
    {
        if((this.gameObject.transform.rotation.eulerAngles.z >= 80 && this.gameObject.transform.rotation.eulerAngles.z <= 100) || (this.gameObject.transform.rotation.eulerAngles.z >= 260 && this.gameObject.transform.rotation.eulerAngles.z <= 280))
        {
            Grounded = true;
        }
        else
        {
            Grounded = false;
        }

        spriteRenderer.sprite = Number[C];

        if(C == 8)
        {
            if(Grounded)
            {
                gate.OpenGate();
            }
        }
        else
        {
            gate.CloseGate();
        }
    }
    /*
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Ground"))
        {
            Grounded = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            Grounded = false;
        }
    }*/
}
