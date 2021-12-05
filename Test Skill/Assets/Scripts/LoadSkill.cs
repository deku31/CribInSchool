using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSkill : MonoBehaviour
{
    public GameObject[] skillPrefabs;
    public Transform spawnPointSkill;

    public void Start()
    {
        int selectSkill = PlayerPrefs.GetInt("selectSkill");
        GameObject prefab = skillPrefabs[selectSkill];
        GameObject clone = Instantiate(prefab, spawnPointSkill.position, Quaternion.identity);

    }
}
