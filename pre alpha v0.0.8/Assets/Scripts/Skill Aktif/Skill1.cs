using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill1 : MonoBehaviour
{
    public float timefrezzerDefault=2f;
    private float timefrezzer;
    
    public float durasispawnDefault=120;
    private float durasispawn;

    public bool skillaktif;
    public bool frezeer;
    public Gamemanager gm;
    // Start is called before the first frame update

    private void Awake()
    {
        gm = FindObjectOfType<Gamemanager>();
        if (gm!=null)
        {
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

        if (frezeer==true)
        {
            if (timefrezzer > 0.1f)
            {
                timefrezzer -= Time.deltaTime;
            }
            else
            {
                frezeer = false;
                timefrezzer = timefrezzerDefault;
            }
        }
        if (skillaktif==false)
        {
            if (durasispawn > 0.1f)
            {
                durasispawn -= Time.deltaTime;
            }
            else
            {
                skillaktif = true;
                durasispawn = durasispawnDefault;
            }
        }
        
    }
    public void frezee()//method tombol untik frezze guru
    {
        if (gm!=null)
        {
            if (skillaktif == true)
            {
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
}
