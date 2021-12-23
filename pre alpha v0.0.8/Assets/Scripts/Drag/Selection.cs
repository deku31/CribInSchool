using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Selection : MonoBehaviour
{
    public EquipmentSlot skill_1;
    public EquipmentSlot skill_2;

    public int selectSkill_1 = 0;
    public int selectSkill_2 = 0;

    public void Awake()
    {

    }

    public void Update()
    {
        selectSkill_1 = skill_1.nomer;
        selectSkill_2 = skill_2.nomer;
    }

    public void StartGame()
    {
        PlayerPrefs.SetInt("selectSkill_1", selectSkill_1);
        PlayerPrefs.SetInt("selectSkill_2", selectSkill_2);

        SceneManager.LoadScene("lodingScane", LoadSceneMode.Single);
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
