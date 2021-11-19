﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    //mengambil dari script player
    public player player;
    //untuk menentukan kamera puzzle
    public Camera cam;

    /*kamera gamepalay 
     * yang atas tag main camera bertujuan untuk select player
     * yang bawah tag default berfungsi agar puzzle yang menggunakan sistem kamera dapat digunakan
    */
    public GameObject gamePlayCamera;
    public GameObject gamePlaycamera2;

    //setiap puzzle yang diselesaikan akan menambah skor atau dengan katalain jumlah puzzle yang telah diselesaikan dengan benar
    public int score = 0;

    //bertujuan mengambil prefab sliding puzzle
    /*
     * menggunakan array bertujuan jika ingin menggunakan sliding puzzle dengan jumlah selain 3x3 dapat memasukan prefab kesini
     */
    public GameObject[] SlidingpuzzlePrefabs;
    public slidingpuzzlescript[] slidingscript;

    //variabel wordsearch **belum digunakan**
    /*
     * mengambil prefab word search
     * tujuan sama seperti sliding puzzle di atas
     */
    public GameObject[] WordSearchprefab;
    public WordGrid wg;
    //akhir variabel word search

    public GameObject[] _WordScramble;



    public Transform perent;/*berfungsi tempan instance atau tempat munculnya puzzle*/
    //nomor puzzle
    public int PuzzleNUmber;
    public int jumlahPuzzle;
    //nomor urutan cabang puzzle
    public int urutanPuzzle;

    public bool munculpuzzle;
    //fungsi dimana hitung score dapat digunakan
    public bool hitungScore;

    public Animator puzzleanim;

    //memunculkan btn popup
    public GameObject btnPopuppuzzle;

    //end game
    public GameObject EndPanel;
    public endManager end;

    private void Start()
    {
        puzzleanim = GetComponent<Animator>();/*mengambil komponen animator*/
        wg.cameraPuzzle = cam;
        //PuzzleNUmber = Random.Range(0,jumlahPuzzle);
        SlidingpuzzlePrefabs[urutanPuzzle].SetActive(true);
        munculpuzzle = true;
        hitungScore = false;
    }
    private void Update()
    {
        end.jawabanBenar = score;

        if (PuzzleNUmber == 0)
        {
            cam.enabled = false;
            slidingPuzzle();
        }
        else if (PuzzleNUmber == 1)
        {
            cam.enabled = true;
            WordScramble();
        }
        else
        {
            EndPanel.SetActive(true);
        }
        if (player.munculPuzzle == true)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                keluar();
            }

        }
    }
    //=============================================================================================================================
    private void WordScramble()
    {
        if (munculpuzzle == true)
        {
            munculpuzzle = false;
            instance(_WordScramble);
        }
        if (GameObject.Find(_WordScramble[urutanPuzzle].name + "(Clone)") == null)
        {
            score += 1;
            munculpuzzle = true;
            PuzzleNUmber += 1;
        }
    }    
    //=============================================================================================================================
    private void wordSearch()
    {
        if (PuzzleNUmber == 1 && munculpuzzle == true)
        {
            munculpuzzle = false;
            instance(WordSearchprefab);
        }
        if (GameObject.Find(WordSearchprefab[urutanPuzzle].name + "(Clone)") == null)
        {
            munculpuzzle = true;
            PuzzleNUmber += 1;
        }
    }
    //=============================================================================================================================
    private void slidingPuzzle()
    {
        if (munculpuzzle == true)
        {
            munculpuzzle = false;
            instance(SlidingpuzzlePrefabs);

        }
        if (GameObject.Find(SlidingpuzzlePrefabs[urutanPuzzle].name + "(Clone)") == null)
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
    public void keluar()
    {
        gamePlaycamera2.SetActive(false);
        gamePlayCamera.SetActive(true);
        gameObject.SetActive(false);
        btnPopuppuzzle.SetActive(true);
        player.munculPuzzle = false;
    }
}
