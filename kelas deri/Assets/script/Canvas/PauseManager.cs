using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{

    public GameObject pausePanel;


    void Start()
    {
        
    }

    public void OpenPause()
    {
        if (pausePanel != null)
        {
            pausePanel.SetActive(true);
        }
    }

    public void Resume()
    {
        if (pausePanel != null)
        {
            pausePanel.SetActive(false);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("gameplay 1");
    }

    public void OnApplicationQuit()
    {
        Application.Quit();
    }
}
