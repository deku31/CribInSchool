using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameCompleted : MonoBehaviour
{
    public Image title, grade;
    public Sprite[] berhasil, gagal;

    public GameObject panelComplete;
    public GameObject panelbutton;

    public PuzzleManager puzzle;

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void Next()
    {

    }

    public void Retry()
    {
        SceneManager.LoadScene("gameplay 1");
    }
}
