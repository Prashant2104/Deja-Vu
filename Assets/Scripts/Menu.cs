using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    private TimeController time;
    private void Start()
    {
        time = FindObjectOfType<TimeController>();
        time.IsTimer = false;
        Time.timeScale = 1f;
    }
    public void OnLevelsButtonClick()
    {
        //Debug.Log("Levels");
        SceneManager.LoadScene("Levels");
    }
    public void OnPlayButtonClick()
    {
        //Debug.Log("Play");
        //Debug.Log(PlayerPrefs.GetInt("LevelsUnlocked"));
        if(PlayerPrefs.GetInt("LevelsUnlocked") == 0)
        {
            SceneManager.LoadScene(1);
        }
        else
        {
            SceneManager.LoadScene(PlayerPrefs.GetInt("LevelsUnlocked"));
        }
        time.Begin();
    }

    public void OnBackButtonClick()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void OnCreditsButtonPress()
    {
        //Debug.Log("Credits");
        SceneManager.LoadScene("Credits");
    }

    public void OnHowToButtonPress()
    {
        //Debug.Log("HowTo");
        SceneManager.LoadScene("HowTo");
    }

    public void OnControlsButtonPress()
    {
        //Debug.Log("Controls");
        SceneManager.LoadScene("Controls");
    }
    public void OnStoryButtonClick()
    {
        SceneManager.LoadScene("Story");
    }
    public void OnExitButtonPress()
    {
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}