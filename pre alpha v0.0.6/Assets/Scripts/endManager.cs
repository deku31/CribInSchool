using System.Collections;
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
    public GameObject endPanel;

    public int jawabanBenar;
    //berdasarkan jumlah puzzle
    public int nilaitertinggi;

    public PuzzleManager puzzle;
    private bool ending;
    private float timestop=1f;

    void Awake()
    {
        ending = true;
    }


    // Update is called once per frame
    void Update()
    {
        nilaitertinggi = puzzle.jumlahSoal;

        hasilAkhir.text = puzzle.score.ToString();
        //panel akhir setting
        if (jawabanBenar==nilaitertinggi)
        {
            title.sprite = berhasil[0];
            grade.sprite = berhasil[1];
        }
        else if (jawabanBenar>=nilaitertinggi/2)
        {
            title.sprite = berhasil[0];
            grade.sprite = gagal[1];
        }
        else 
        {
            title.sprite = gagal[0];
            grade.sprite = gagal[2];
        }
        if (ending==true)
        {
            timestop -= Time.deltaTime;
            if (timestop<0.1f)
            {
                Time.timeScale = 0;
            }
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
    }

    public void Next()
    {
        SceneManager.LoadScene("Gameplay1");
        Time.timeScale = 1;
    }
}
