using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSkill : MonoBehaviour
{
    public GameObject[] skillPrefabs;
    public Transform spawnPointSkill_1;
    public Transform spawnPointSkill_2;

    public GameObject prefab_1;
    public GameObject prefab_2;

    public GameObject clone_1;
    public GameObject clone_2;

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
    }
}
