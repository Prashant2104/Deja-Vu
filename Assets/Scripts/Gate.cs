﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gate : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
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
        if(collision.gameObject.CompareTag("Key"))
        {
            //gameObject.SetActive(false);
            Debug.Log("Enter");
            animator.SetBool("Enter", true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Key"))
        {
            //gameObject.SetActive(false);
            Debug.Log("Enter");
            animator.SetBool("Enter", true);
        }
    }
}