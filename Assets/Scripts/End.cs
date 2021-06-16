using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class End : MonoBehaviour
{
    public GameObject EndPanel;
    void Start()
    {
        EndPanel.SetActive(false);
    }
    public void Ending()
    {
        StartCoroutine(xyz());
    }
    public void OnMenuButtonClick()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1f;
    }
    IEnumerator xyz()
    {
        EndPanel.SetActive(true);
        yield return new WaitForSeconds(5f);
        OnMenuButtonClick();
    }
}