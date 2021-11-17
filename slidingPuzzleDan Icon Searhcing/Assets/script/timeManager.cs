using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class timeManager : MonoBehaviour
{
    public float waktu;
    public int menit;
    public Text timetxt;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        TimeSpan time = TimeSpan.FromSeconds(waktu);
        timetxt.text = "0"+time.Minutes.ToString() + ":" + time.Seconds.ToString();
    }
}
