using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Selection : MonoBehaviour
{
    public EquipmentSlot equipSlotSkill_1;
    //public EquipmentSlot skill_2;

    public int selectSkill_1;
    //public int selectSkill_2 = 0;

    public void Awake()
    {

    }

    public void Update()
    {
        selectSkill_1 = equipSlotSkill_1.nomer;
        //selectSkill_2 = skill_2.nomer;
    }

    public void StartGame()
    {
        PlayerPrefs.SetInt("selectSkill_1", selectSkill_1);
        SceneManager.LoadScene("lodingScane", LoadSceneMode.Single);

        //PlayerPrefs.SetInt("selectSkill_2", selectSkill_2);


    }
}
