﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadSkill : MonoBehaviour
{
    public GameObject[] skillPrefabs;
    public Transform spawnPointSkill_1;
    public Transform spawnPointSkill_2;
    public Vector3 spawn_1 = new Vector3(-910f, -200f, 0f);
    public Vector3 spawn_2 = new Vector3(-910f, -400f, 0f);

    public GameObject prefab_1;
    public GameObject prefab_2;

    public GameObject clone_1;
    public GameObject clone_2;

    public GameObject[] ObjectImageClone;
    public Image[] imageClone;

    public void Awake()
    {
        //clone_1 = GameObject.FindGameObjectWithTag("Skill");
        //dragScript = GameObject.FindGameObjectWithTag("Skill");
    }

    public void Start()
    {
        

        int selectSkill_1 = PlayerPrefs.GetInt("selectSkill_1");
        int selectSkill_2 = PlayerPrefs.GetInt("selectSkill_2");

        prefab_1 = skillPrefabs[selectSkill_1];
        prefab_2 = skillPrefabs[selectSkill_2];

        //GameObject clone_1 = Instantiate(prefab_1, spawnPointSkill_1.position, Quaternion.identity);
        //GameObject clone_2 = Instantiate(prefab_2, spawnPointSkill_2.position, Quaternion.identity);

        clone_1 = Instantiate(prefab_1, spawnPointSkill_1.position, prefab_1.transform.rotation);
        clone_2 = Instantiate(prefab_2, spawnPointSkill_2.position, prefab_2.transform.rotation);


        ObjectImageClone = GameObject.FindGameObjectsWithTag("Skill");
        imageClone = new Image[ObjectImageClone.Length];
        for(int i = 0; i<ObjectImageClone.Length; i++)
        {
            imageClone[i] = ObjectImageClone[i].GetComponent<Image>();
        }
    }

    public void Update()
    {
        imageClone[0].transform.localPosition = spawn_1;
        imageClone[1].transform.localPosition = spawn_2;
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
