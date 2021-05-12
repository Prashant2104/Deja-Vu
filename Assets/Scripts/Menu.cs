using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void OnLevelsButtonClick()
    {
        // TODO
        Debug.Log("Levels");
        SceneManager.LoadScene("Levels");
    }
    public void OnPlayButtonClick()
    {
        // TODO
        Debug.Log("Play");
        SceneManager.LoadScene("LVL1");
    }
    public void OnCreditsButtonPress()
    {
        // TODO
        Debug.Log("Credits");
        SceneManager.LoadScene("Credits");
    }
    public void OnExitButtonPress()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        //Application.Quit();
    }
}