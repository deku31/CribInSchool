using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillButton : MonoBehaviour
{
    public Text skillNameText;
    public Text skilDeskripsiText;
    public Sprite spriteChange;

    public int skillId;

    void Start()
    {
        skillNameText = FindInActiveObjectByName("Nama Skill").GetComponent<Text>();
        skilDeskripsiText = FindInActiveObjectByName("Deskripsi Skill").GetComponent<Text>();
    }

    void Update()
    {
        
    }

    public void SkillDeskripsi()
    {
        if (skillNameText!=null&&skilDeskripsiText!=null)
        {
            SkillManager.instance.activateSkill = transform.GetComponent<Skill>();

            skillNameText.text = SkillManager.instance.skills[skillId].skillName;
            skilDeskripsiText.text = SkillManager.instance.skills[skillId].skillDeskripsi;
        }
        else
        {
            print("deskripsi tidak ada");
        }
    }

    public void ActiveSkill_1()
    {
        Debug.Log("Skill 1 Sudah Aktif");
    }

    public void ActiveSkill_2()
    {
        Debug.Log("Skill 2 Sudah Aktif");
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

}
