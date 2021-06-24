using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Story : MonoBehaviour
{
    public GameObject Story_1, Story_2;
    public Button F, B;

    // Start is called before the first frame update
    void Start()
    {
        Story_1.SetActive(true);
        Story_2.SetActive(false);

        F.interactable = true;
        B.interactable = false;
    }

    public void OnNext()
    {
        Story_1.SetActive(false);
        Story_2.SetActive(true);

        F.interactable = false;
        B.interactable = true;

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(B.gameObject);
    }
    public void OnBack()
    {
        Story_1.SetActive(true);
        Story_2.SetActive(false);

        F.interactable = true;
        B.interactable = false;

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(F.gameObject);
    }
    public void OnMenuButtonClick()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
