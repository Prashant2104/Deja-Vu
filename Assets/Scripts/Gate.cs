using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gate : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OpenGate()
    {
        Debug.Log("Enter");
        animator.SetBool("Enter", true);
    }
    public void CloseGate()
    {
        Debug.Log("Closed");
        animator.SetBool("Enter", false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Key")
        {
            //gameObject.SetActive(false);
            Debug.Log("Enter");
            animator.SetBool("Enter", true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Key")
        {
            //gameObject.SetActive(false);
            Debug.Log("Enter");
            animator.SetBool("Enter", true);
        }
    }
}