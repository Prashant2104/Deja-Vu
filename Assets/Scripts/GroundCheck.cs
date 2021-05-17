using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GroundCheck : MonoBehaviour 
{

    [SerializeField] private LayerMask platformLayerMask;

    public bool isGrounded;

    private int LevelIndex;

    private void Start()
    {
        LevelIndex = SceneManager.GetActiveScene().buildIndex;
    }
    private void Update()
    {
        if(LevelIndex == 10)
        {
            isGrounded = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collider) 
    {
        isGrounded = collider != null && (((1 << collider.gameObject.layer) & platformLayerMask) != 0);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isGrounded = false;
    }

}
