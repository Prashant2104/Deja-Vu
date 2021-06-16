using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Levels : MonoBehaviour
{

    int LevelsUnlocked;

    public Button[] buttons;

    private TimeController time;
    void Start()
    {
        time = FindObjectOfType<TimeController>();

        LevelsUnlocked = PlayerPrefs.GetInt("LevelsUnlocked", 1);

        for(int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }

        for (int i = 0; i < LevelsUnlocked; i++)
        {
            buttons[i].interactable = true;
        }
    }

    public void LoadLevel(int LevelIndex)
    {
        SceneManager.LoadScene(LevelIndex);
        time.BeginTimer();
    }
    public void ResetProgression()
    {
        PlayerPrefs.DeleteKey("LevelsUnlocked");
        Start();
    }
    public void OnBackButtonClick()
    {
        SceneManager.LoadScene("Main Menu");
    }
}