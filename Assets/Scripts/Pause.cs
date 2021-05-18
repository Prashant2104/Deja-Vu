using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject Camera;
    public GameObject FirstButton;

    public static bool IsPaused = true;

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

    /*public void PauseButton()
    {
        if(IsPaused == true)
        {
            OnResumeButtonClick();
        }
        else
        {
            OnPauseButtonClick();
        }
    }*/

    public void OnPauseButtonClick()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        //IsPaused = true;

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(FirstButton);
    }

    public void OnResumeButtonClick()
    {
        Debug.Log("Resume");
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
        //IsPaused = false;
    }

    public void OnMenuButtonClick()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1f;
    }

    public void OnMuteButtonClick()
    {
        Debug.Log("Mute");
        mute.Mute();
        OnResumeButtonClick();
    }

    public void OnExitButtonPress()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        //Application.Quit();
    }
}
