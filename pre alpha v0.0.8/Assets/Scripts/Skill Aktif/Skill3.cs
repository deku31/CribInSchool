using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public Image maskSpawn;
    public Image maskSkillactive;

    public GameObject bintang;
    public Transform parrent;
    public int lvskill;
    private void Awake()
    {
        speedpesawat = speedpesawat+ UserDataManager.Progress.skill3;
        lvskill = UserDataManager.Progress.lvskill[2];
        for (int i = 0; i < lvskill; i++)
        {
            Instantiate(bintang, parrent);
        }
        maskSpawn.enabled = false;
        maskSkillactive.enabled = false;
        gm = FindObjectOfType<Gamemanager>();
        if (gm != null)
        {
            maskSpawn.fillAmount = durasispawnDefault;
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
                maskSkillactive.enabled = false;
                invisible = false;
                timeinvisible = timeinvisibleDefault;
                maskSpawn.rectTransform.sizeDelta = new Vector2(79f, 67f);
                maskSpawn.enabled = true;
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
                maskSpawn.enabled = false;
                skillaktif = true;
                playskill = false;
                durasispawn = durasispawnDefault;
            }
        }

        maskSpawn.fillAmount = durasispawn / durasispawnDefault;
        maskSkillactive.fillAmount = timeinvisible / timeinvisibleDefault;

    }
    public void Invisible()//method tombol untuk invisible
    {
        if (gm != null)
        {
            if (skillaktif == true)
            {
                maskSkillactive.rectTransform.sizeDelta = new Vector2(79f, 67f);
                maskSkillactive.enabled = true;
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
    public void upgrade()
    {
        if (lvskill < 3)
        {
            UserDataManager.Progress.lvskill[2]++;
            lvskill++;
            speedpesawat += 0.5f;
            UserDataManager.Progress.skill3 += 0.5f;
            Instantiate(bintang, parrent);
            UserDataManager.Save();
        }
        else
        {
            print("Lv penuh");
        }
    }
}
