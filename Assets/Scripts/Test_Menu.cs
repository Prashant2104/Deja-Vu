using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Test_Menu : MonoBehaviour
{
    public bool Play, Levels, Story, How_to, Credits, Exit;
    private TimeController time;
    private void Start()
    {
        time = FindObjectOfType<TimeController>();
        time.IsTimer = false;
        Time.timeScale = 1f;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            if(Play)
            {
                Debug.Log("Play");
                if (PlayerPrefs.GetInt("LevelsUnlocked") == 0)
                {
                    SceneManager.LoadScene(1);
                }
                else
                {
                    SceneManager.LoadScene(PlayerPrefs.GetInt("LevelsUnlocked"));
                }
                time.Begin();
            }      

            if(Levels)
            {
                Debug.Log("Levels");
                SceneManager.LoadScene("Levels");
            }

            if(How_to)
            {
                Debug.Log("HowTo");
                SceneManager.LoadScene("HowTo");
            }

            if(Story)
            {
                Debug.Log("Story");
                SceneManager.LoadScene("Story");
            }

            if(Credits)
            {
                Debug.Log("Credits");
                SceneManager.LoadScene("Credits");
            }

            if(Exit)
            {
                UnityEditor.EditorApplication.isPlaying = false;
                //Application.Quit();
                Debug.Log("Exit");
            }
        }
    }
}