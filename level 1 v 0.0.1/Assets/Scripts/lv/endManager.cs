using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(endManager))]
public class endManager : MonoBehaviour
{
    public LoadSkill lskl;
    //======================================================================================================================
    //lv unlock variabel
    levelmanager lm;
    public int bukalv;//nomor lv yang ingin dibuka

    //exp dan koin variabel
    public Text exptext;
    public int expRecived;

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
        lskl = FindObjectOfType<LoadSkill>();
        lm = FindObjectOfType<levelmanager>();
        playermanager = FindObjectOfType<player>();
        audiomanager = FindObjectOfType<SoundManager>();
        bgm = FindObjectOfType<BgmManager>();
        ending = true;
    }
    private void Start()
    {
        bgm.bgm.Stop();
        lskl.clone_1.SetActive(false);
        lskl.panelskill.SetActive(false);
        //audiomanager.resultMethod(2);
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
        int kurang=1;
        if (puzzle.jumlahSoal>=5)
        {
            kurang = 2;
        }
        if (jawabanBenar==nilaitertinggi&& ketahuan==false)
        {

            title.sprite = berhasil[0];
            grade.sprite = berhasil[1];
            expRecived = 100;
            UserDataManager.Progress.lvunlock = bukalv;
            lm.lvUnlock[bukalv - 1] = true;

        }
        else if (jawabanBenar>=nilaitertinggi-kurang && ketahuan == false)
        {
            title.sprite = berhasil[0];
            grade.sprite = gagal[1];
            lm.lvUnlock[bukalv - 1] = true;
            expRecived = 80;
        }
        else if(ketahuan==true||jawabanBenar<nilaitertinggi-kurang)
        {
            expRecived = 10;
            title.sprite = gagal[0];
            grade.sprite = gagal[2];
        }
        exptext.text = "+"+expRecived+"Exp";
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
        audiomanager.result.Stop();
        UserDataManager.Progress.expPlayer += expRecived;
        UserDataManager.Save();
        Time.timeScale = 1;
    }
}
