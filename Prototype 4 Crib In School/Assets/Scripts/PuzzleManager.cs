using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    [Header("TimeManager")]
    public GameObject progressBarTime;

    //Waktu
    public float time;
    public bool hitungWaktu;
    public bool _pause;

    public player player;
    public Camera camPuzzleManager;
    public int score=0;

    public GameObject[] slidingPuzzlePrefabs;
    public GameObject[] wordScramblePrefabs;

    public Transform perent;
    public int PuzzleNUmber;
    public int urutanPuzzle;

    public bool munculpuzzle;
    public bool hitungScore;

    public GameObject obj;

    public GameObject gameComplete;
    public GameObject puzzlePrefab;

    private void Start()
    {

        PuzzleNUmber = 0;
        slidingPuzzlePrefabs[urutanPuzzle].SetActive(true);
        munculpuzzle = true;
        hitungScore = false;
    }

    private void Update()
    {


        if (PuzzleNUmber==0)
        {
            slidingPuzzle();
            
        }

        else if (PuzzleNUmber==1)
        {
            wordScramblePuzzle();
        }
    }

    public void pause()
    {
        if (_pause == false)
        {
            _pause = true;
            hitungWaktu = false;
        }
        else
        {
            _pause = false;
            hitungWaktu = true;
        }
    }

    //=============================================================================================================================
    private void slidingPuzzle() 
    {
        if (PuzzleNUmber==0 && munculpuzzle == true)
        {
            munculpuzzle = false;
            instance(slidingPuzzlePrefabs);
        }


        if ( GameObject.Find(slidingPuzzlePrefabs[urutanPuzzle].name + "(Clone)") == null&&PuzzleNUmber==0)
        {
            score += 1;
            munculpuzzle = true;
            PuzzleNUmber += 1;
        }
    }

    private void wordScramblePuzzle()
    {
        if (PuzzleNUmber==1 && munculpuzzle == true)
        {
            munculpuzzle = false;
            instance(wordScramblePrefabs);
        }
        if (GameObject.Find(wordScramblePrefabs[urutanPuzzle].name + "(Clone)") == null && PuzzleNUmber == 0)
        {
            score += 1;
            munculpuzzle = true;
            PuzzleNUmber += 1;
        }
    }

    private void instance(GameObject[] jenis) 
    {
        Instantiate(jenis[urutanPuzzle], perent);
    }

    public void EndGame()
    {
        Debug.Log("Game Over");
        gameComplete.SetActive(true);
        puzzlePrefab.SetActive(false);
    }
}
