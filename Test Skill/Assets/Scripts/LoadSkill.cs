using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSkill : MonoBehaviour
{
    public GameObject[] skillPrefabs;
    public Transform spawnPointSkill_1;
    public Transform spawnPointSkill_2;

    public void Start()
    {
        int selectSkill_1 = PlayerPrefs.GetInt("selectSkill_1");
        int selectSkill_2 = PlayerPrefs.GetInt("selectSkill_2");

        GameObject prefab_1 = skillPrefabs[selectSkill_1];
        GameObject prefab_2 = skillPrefabs[selectSkill_2];

        GameObject clone_1 = Instantiate(prefab_1, spawnPointSkill_1.position, Quaternion.identity);
        GameObject clone_2 = Instantiate(prefab_2, spawnPointSkill_2.position, Quaternion.identity);
    }
}
