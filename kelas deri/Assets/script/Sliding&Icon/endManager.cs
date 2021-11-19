﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class endManager : MonoBehaviour
{
    //isi panel
    //public Text sisaWaktu;
    public Text hasilAkhir;
    public Image title,grade;
    public Sprite[] berhasil,gagal;

    public GameObject papan;
    public GameObject panelButon;

    public int jawabanBenar;
    //berdasarkan jumlah puzzle
    public int nilaitertinggi;

    public PuzzleManager puzzle;
    // Start is called before the first frame update
    void Start()
    {

    }   

    // Update is called once per frame
    void Update()
    {
        //sisaWaktu.text =string.Format("{0:00}", puzzle.slidingscript[puzzle.urutanPuzzle].waktu.waktu-1)+" detik";
        hasilAkhir.text = puzzle.score.ToString();
        //panel akhir setting
        if (jawabanBenar==nilaitertinggi)
        {
            title.sprite = berhasil[0];
            grade.sprite = berhasil[1];
        }
        else if (jawabanBenar==nilaitertinggi/2)
        {
            title.sprite = berhasil[0];
            grade.sprite = gagal[1];
        }
        else
        {
            title.sprite = gagal[0];
            grade.sprite = gagal[2];
        }

    }
    public void restart()
    {
        SceneManager.LoadScene(Application.loadedLevel);
    }
    public void keluar()
    {
        Application.Quit();
    }
    public void close()
    {
        papan.SetActive(false);
        panelButon.SetActive(true);
    }
}
