using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject Camera;
    public bool IsPaused;

    private CameraManager mute;
    void Start()
    {
        mute = FindObjectOfType<CameraManager>();
        PauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PauseButton()
    {
        if(IsPaused == true)
        {
            OnResumeButtonClick();
        }
        else
        {
            OnPauseButtonClick();
        }
    }

    public void OnPauseButtonClick()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;
    }

    public void OnResumeButtonClick()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
    }

    public void OnMenuButtonClick()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void OnMuteButtonClick()
    {
        Debug.Log("Mute");
        mute.Mute();
    }

    public void OnExitButtonPress()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        //Application.Quit();
    }
}
