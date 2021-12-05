using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Selection : MonoBehaviour
{
    public GameObject[] skill;
    public int selectSkill = 0;

    public void Awake()
    {
        //skill = FindInActiveObjectByTag("Skill");
        skill = GameObject.FindGameObjectsWithTag("Skill");
    }

    public void Start()
    {
        skill = GameObject.FindGameObjectsWithTag("Skill");
    }

    public void Update()
    {
        skill = GameObject.FindGameObjectsWithTag("Skill");
    }

    public void StartGame()
    {
        PlayerPrefs.SetInt("selectSkill", selectSkill);
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    //GameObject FindInActiveObjectByTag(string tag) //fungsi mencari object yang tidak aktif menggunakan tag
    //{

        //Transform[] objs = Resources.FindObjectsOfTypeAll<Transform>() as Transform[];
        //for (int i = 0; i < objs.Length; i++)
        //{
            //if (objs[i].hideFlags == HideFlags.None)
            //{
                //if (objs[i].CompareTag(tag))
                //{

                    //return objs[i].gameObject;
                //}
            //}
        //}
        //return null;
    //}
}
