using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class endManager : MonoBehaviour
{
    //isi panel
    public Text sisaWaktu;
    public Text hasilAkhir;
    public Image title,grade;
    public Sprite[] berhasil,gagal;

    public GameObject papan;
    public GameObject panelButon;

    public int jawabanBenar;
    public int nilaitertinggi;

    public slidingpuzzlescript puzzle;
    // Start is called before the first frame update
    void Start()
    {

    }   

    // Update is called once per frame
    void Update()
    {
        sisaWaktu.text =string.Format("{0:00}", puzzle.waktu.waktu-1)+" detik";
        hasilAkhir.text = jawabanBenar.ToString();

        //panel akhir setting
        if (jawabanBenar==nilaitertinggi&&puzzle.waktu.waktu>=40)
        {
            title.sprite = berhasil[0];
            grade.sprite = berhasil[1];
        }
        else if ((jawabanBenar==nilaitertinggi&&puzzle.waktu.waktu<40)||(jawabanBenar==nilaitertinggi/2&&puzzle.waktu.waktu>=40))
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
        SceneManager.LoadScene("slidingPuzzle&IconSearch");
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
