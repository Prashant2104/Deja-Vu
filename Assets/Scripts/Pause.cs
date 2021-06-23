using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject PauseMenu;
    public GameObject Hints;
    public GameObject Camera;
    public GameObject FirstButton;
    //public Text Timer;

    public bool IsPaused = false;

    public Text Lives;
    private Player player;
    private CameraManager mute;
    void Start()
    {
        player = FindObjectOfType<Player>();
        mute = FindObjectOfType<CameraManager>();
        PauseMenu.SetActive(false);
        Hints.SetActive(false);
    }
    private void FixedUpdate()
    {
        Lives.text = "Deaths = " + Player.DeathCount;
    }

    public void OnPauseButtonClick()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(FirstButton);
    }

    public void OnResumeButtonClick()
    {
        //Debug.Log("Resume");
        PauseMenu.SetActive(false);
        Hints.SetActive(false);
        IsPaused = false;
        Time.timeScale = 1f;        
    }

    public void OnHintsButtonClick()
    {
        Hints.SetActive(true);
    }

    public void OnRetryButtonClick()
    {
        Time.timeScale = 1f;
        player.Kill();
    }

    public void OnMenuButtonClick()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1f;
    }

    public void OnMuteButtonClick()
    {
        //Debug.Log("Mute");
        mute.Mute();
        OnResumeButtonClick();
        IsPaused = false;
    }

    public void OnExitButtonPress()
    {
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
    public void OnLevelsButtonClick()
    {
        //Debug.Log("Levels");
        SceneManager.LoadScene("Levels");
        Time.timeScale = 1f;
    }

}
