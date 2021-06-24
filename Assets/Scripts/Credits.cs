using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    public void Prashant()
    {
        Application.OpenURL("https://www.linkedin.com/in/prashant-gupta-3465b61a3/");
    }
    public void Sahil()
    {
        Application.OpenURL("https://www.linkedin.com/in/sahil-jounwal-8892b81a0/");
    }
    public void Pankhudi()
    {
        Application.OpenURL("https://www.linkedin.com/in/pankhudi-saraswat-8b81b61a0/");
    }
    public void Shubham()
    {
        Application.OpenURL("https://www.linkedin.com/in/shubham-drolia/");
    }
    public void Satvik()
    {
        Application.OpenURL("https://www.linkedin.com/in/satviknagpal01/");
    }
    public void Nitish()
    {
        Application.OpenURL("https://github.com/Nitish-K15");
    }

    public void OnMenuButtonClick()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
