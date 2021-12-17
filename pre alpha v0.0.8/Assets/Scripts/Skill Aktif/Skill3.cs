using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill3 : MonoBehaviour
{
    public float timeinvisibleDefault = 30f;
    private float timeinvisible;
    public float speedpesawat=0.2f;
    public float durasispawnDefault = 90;
    private float durasispawn;

    public bool skillaktif;
    public bool invisible;
    public bool playskill;
    public Gamemanager gm;
    // Start is called before the first frame update

    private void Awake()
    {
        gm = FindObjectOfType<Gamemanager>();
        if (gm != null)
        {
            skillaktif = true;
            timeinvisible = timeinvisibleDefault;
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

        if (invisible == true)
        {
            if (timeinvisible > 0.1f)
            {
                timeinvisible -= Time.deltaTime;
            }
            else
            {
                invisible = false;
                timeinvisible = timeinvisibleDefault;
            }
        }
        if (skillaktif == false)
        {
            if (durasispawn > 0.1f)
            {
                durasispawn -= Time.deltaTime;
            }
            else
            {
                skillaktif = true;
                playskill = false;
                durasispawn = durasispawnDefault;
            }
        }
       
        

    }
    public void Invisible()//method tombol untuk invisible
    {
        if (gm != null)
        {
            if (skillaktif == true)
            {
                invisible = true;
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
        invisible = false;
    }
    void activeButtonSkills()//mengaktifkan button skill
    {
        skillaktif = true;
    }
}
