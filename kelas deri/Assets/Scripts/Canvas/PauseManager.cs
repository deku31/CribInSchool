using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{

    public GameObject pausePanel;

    public bool gameIsPaused = false;

    private void Awake()
    {
        pausePanel.SetActive(false);
        gameIsPaused = false;
        Time.timeScale = 1f;
    }

    public void Pause()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;

    }

    public void Resume()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    public void Restart()
    {
        SceneManager.LoadScene("Gameplay1");
    }

    public void Quit()
    {
        //Application.Quit();
        SceneManager.LoadScene("1. MainMenu");
    }
}
