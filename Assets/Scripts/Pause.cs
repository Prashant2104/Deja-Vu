using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject Camera;
    public GameObject FirstButton;
    public Text Timer;

    public static bool IsPaused = true;

    private CameraManager mute;
    void Start()
    {
        mute = FindObjectOfType<CameraManager>();
        PauseMenu.SetActive(false);
    }

    public void OnPauseButtonClick()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(FirstButton);
    }

    public void OnResumeButtonClick()
    {
        Debug.Log("Resume");
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;
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
        IsPaused = !IsPaused;
    }

    public void OnExitButtonPress()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        //Application.Quit();
    }
}
