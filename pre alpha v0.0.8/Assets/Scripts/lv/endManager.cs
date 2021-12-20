using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(endManager))]
public class endManager : MonoBehaviour
{
    //======================================================================================================================
    //lv unlock fariabel
    levelmanager lm;
    public int bukalv;//nomor lv yang ingin dibuka


    //======================================================================================================================

    [SerializeField] private SoundManager audiomanager=null;
    [SerializeField] private BgmManager bgm=null;
    //isi panel
    public Text lulustxt;
    public int totallulus;

    //jumlah puzzle benar
    public Text hasilAkhir;
    public Image title,grade;
    public Sprite[] berhasil,gagal;

    public GameObject papan;
    public GameObject endPanel;

    public int jawabanBenar;
    //berdasarkan jumlah puzzle
    public float nilaitertinggi;

    public PuzzleManager puzzle;
    private bool ending;
    private float timestop=1f;

    public bool ketahuan;//ketahuan guru dan murid cepu

    //player manager
    [SerializeField] private player playermanager;

    void Awake()
    {
        lm = FindObjectOfType<levelmanager>();
        playermanager = FindObjectOfType<player>();
        audiomanager = FindObjectOfType<SoundManager>();
        bgm = FindObjectOfType<BgmManager>();
        ending = true;
    }
    private void Start()
    {
        bgm.bgm.Stop();
        audiomanager.resultMethod(2);
    }

    // Update is called once per frame
    void Update()
    {
        //for (int i = 0; i < playermanager.jumlahPlayer; i++)
        //{
        //    if (playermanager.progresplayer[i].current>=playermanager.progresplayer[i].maxlenght*0.8f)
        //    {
        //        totallulus = 1;
        //    }
        //    else
        //    {
        //        totallulus += 0;
        //    }
        //}
       
        nilaitertinggi = puzzle.jumlahSoal;
        lulustxt.text = totallulus.ToString();
        hasilAkhir.text = puzzle.score.ToString();
        //panel akhir setting
        if (jawabanBenar==nilaitertinggi&& ketahuan==false)
        {
            title.sprite = berhasil[0];
            grade.sprite = berhasil[1];
            UserDataManager.Progress.lvunlock = bukalv;
            lm.lvUnlock[bukalv - 1] = true;

        }
        else if (jawabanBenar>=nilaitertinggi-1 && ketahuan == false)
        {
            title.sprite = berhasil[0];
            grade.sprite = gagal[1];
            lm.lvUnlock[bukalv - 1] = true;
        }
        else 
        {
            title.sprite = gagal[0];
            grade.sprite = gagal[2];
        }
        if (ending==true)
        {
            UserDataManager.Save();
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
        audiomanager.result.Stop();
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
        lm.lvpanel.SetActive(true);
        DontDestroyOnLoad(lm);
        SceneManager.LoadScene("Level 1");
        Time.timeScale = 1;
    }
}
