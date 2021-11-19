using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guruMangaer : MonoBehaviour
{
    public TeacherAI guru;
    public Transform[] wayPoint;

    // Start is called before the first frame update
    void Start()
    {
        guru.wayPoint = wayPoint;
        Invoke("instanceGuru", 1.5f);
    }
    void instanceGuru()
    {
        Instantiate(guru, wayPoint[0]);
    }
    // Update is called once per frame
    void Update()
    {
    }
}
