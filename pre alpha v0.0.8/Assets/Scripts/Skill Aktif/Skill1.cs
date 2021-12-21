using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill1 : MonoBehaviour
{
    public float timefrezzerDefault=2f;
    private float timefrezzer;
    private float timeActivefrezzer=0;
    
    public float durasispawnDefault=120;
    private float durasispawn;

    public bool skillaktif;
    public bool frezeer;
    public Gamemanager gm;

    public Image maskSpawn;
    public Image maskSkillactive;
    public Image lockimg;

    public GameObject bintang;
    public Transform parrent;
    public int lvskill;
    private void Awake()
    {
        timefrezzerDefault = timefrezzerDefault + UserDataManager.Progress.skill1;
        lvskill = UserDataManager.Progress.lvskill[0];
        for (int i = 0; i < lvskill; i++)
        {
            Instantiate(bintang, parrent);
        }
        maskSpawn.enabled = false;
        maskSkillactive.enabled = false;
       
        gm = FindObjectOfType<Gamemanager>();
        if (gm!=null)
        {
            maskSpawn.fillAmount = durasispawnDefault;
            skillaktif = true;
            timefrezzer = timefrezzerDefault;
            durasispawn = durasispawnDefault;
            //frezee();
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (frezeer == true)
        {
            if (timefrezzer > 0.1f)
            {
                timefrezzer -= Time.deltaTime;
                timeActivefrezzer += Time.deltaTime;
            }
            else
            {
                maskSkillactive.enabled = false;
                frezeer = false;
                timefrezzer = timefrezzerDefault;
                timeActivefrezzer = 0;
                maskSpawn.rectTransform.sizeDelta = new Vector2(79f, 67f);
                maskSpawn.enabled = true;
            }
        }
        if (skillaktif == false&&maskSpawn.enabled==true)
        {
            if (durasispawn > 0.1f)
            {
                durasispawn -= Time.deltaTime;
            }
            else
            {
                maskSpawn.enabled = false;
                skillaktif = true;
                durasispawn = durasispawnDefault;
            }
        }
        maskSpawn.fillAmount = durasispawn / durasispawnDefault;
        maskSkillactive.fillAmount = timeActivefrezzer/ timefrezzerDefault;


    }
    public void frezee()//method tombol untik frezze guru
    {
        if (gm!=null)
        {
            if (skillaktif == true)
            {
                maskSkillactive.rectTransform.sizeDelta = new Vector2(79f, 67f);
                maskSkillactive.enabled = true;
                frezeer = true;
                skillaktif = false;
            }
            else
            {
                print("proses");
            }
        }
        else
        {
            print("balm ada gm");
        }
    }
    void activeSkills()//mengaktifkan skill
    {
        frezeer = false;
    }
    void activeButtonSkills()//mengaktifkan button skill
    {
        skillaktif = true;
    }

    public void upgrade()
    {
        if (lvskill < 3)
        {
            UserDataManager.Progress.lvskill[0]++;
            lvskill++;
            timefrezzerDefault += 2;
            UserDataManager.Progress.skill1 += 2;
            Instantiate(bintang, parrent);
            UserDataManager.Save();
        }
        else
        {
            print("Lv penuh");
        }
    }
}
