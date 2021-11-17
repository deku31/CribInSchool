using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class endManager : MonoBehaviour
{
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
        hasilAkhir.text = jawabanBenar.ToString();

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
