using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CameraManager : MonoBehaviour
{
    public bool IsMuted;
    public bool Count = false;

    private int LevelIndex;
    private Gate gate;
    void Start()
    {
        LevelIndex = SceneManager.GetActiveScene().buildIndex;
        gate = FindObjectOfType<Gate>();
        //IsMuted = false;
        LevelIndex = SceneManager.GetActiveScene().buildIndex;
    }

    void Update()
    {
        if (LevelIndex == 8)
        {
            if (IsMuted == true)
            {
                gate.OpenGate();
            }
            if (IsMuted == false)
            {
                gate.CloseGate();
            }
        }
    }

    public void Move()
    {
        Count = !Count;

        if (Count == true)
        {
            transform.position = new Vector3(transform.position.x + 25.5f, transform.position.y, -10);
        }
        if (Count == false)
        {
            transform.position = new Vector3(transform.position.x - 25.5f, transform.position.y, -10);
        }
    }

    public void Mute()
    {
        IsMuted = !IsMuted;
        AudioListener.pause = IsMuted;
    }
}
