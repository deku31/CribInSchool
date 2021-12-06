using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSetting : MonoBehaviour
{
    public GameObject dragScript_1;
    public GameObject dragScript_2;
    public GameObject dragScript_3;
    public GameObject dragScript_4;
    public GameObject dragScript_5;

    public LoadSkill loadSkill;

    public void Update()
    {
        dragScript_1 = FindInActiveObjectByName("Skill1");
        dragScript_2 = FindInActiveObjectByName("Skill2");
        dragScript_3 = FindInActiveObjectByName("Skill3");
        dragScript_4 = FindInActiveObjectByName("Skill4");
        dragScript_5 = FindInActiveObjectByName("Skill5");


        dragScript_1.GetComponent<DraggableComponent>().enabled = false;
        dragScript_2.GetComponent<DraggableComponent>().enabled = false;
        dragScript_3.GetComponent<DraggableComponent>().enabled = false;
        dragScript_4.GetComponent<DraggableComponent>().enabled = false;
        dragScript_5.GetComponent<DraggableComponent>().enabled = false;

        //dragScript_1.transform.position = loadSkill.spawnPointSkill_1;
    }

    

    GameObject FindInActiveObjectByName(string name) //fungsi mencari object yang tidak aktif menggunakan nama
    {
        Transform[] objs = Resources.FindObjectsOfTypeAll<Transform>() as Transform[];
        for (int i = 0; i < objs.Length; i++)
        {
            if (objs[i].hideFlags == HideFlags.None)
            {
                if (objs[i].name == name)
                {
                    return objs[i].gameObject;
                }
            }
        }
        return null;
    }

    GameObject FindInActiveObjectByTag(string tag) //fungsi mencari object yang tidak aktif menggunakan tag
    {

        Transform[] objs = Resources.FindObjectsOfTypeAll<Transform>() as Transform[];
        for (int i = 0; i < objs.Length; i++)
        {
            if (objs[i].hideFlags == HideFlags.None)
            {
                if (objs[i].CompareTag(tag))
                {

                    return objs[i].gameObject;
                }
            }
        }
        return null;
    }
}
