using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerManager : MonoBehaviour
{
    [SerializeField] Timer timer1;

    public GameObject pausePanel;

    public GameObject puzzleManager;

    private void Awake()
    {
        BeginPause();
    }

    private void Start()
    {

        timer1.SetDuration(120).Begin();
    }

    public void Update()
    {
        if (!puzzleManager.gameObject.activeInHierarchy == false)
        {
            timer1.SetPaused(!timer1.IsPaused);
        }

        else if(!pausePanel.gameObject.activeInHierarchy == true)
        {
            timer1.SetPaused(!timer1.IsPaused);
        }

        //if (Input.GetKeyUp("p"))
        {
            //pausePanel.SetActive(true);
           // timer1.SetPaused(!timer1.IsPaused);
        }
    }

    public void BeginPause()
    {

    }
}
