using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class ProgressData
{
    public int lvunlock=1;
    //setting
    public int qualityvalue=1;
    public float volumebgm=100;
    public float volumesfx=100;
    //skill
    public int[] lvskill= { 1, 1, 1 };
    public float skill1=0;//menambah durasi frezzer
    public float skill2=0;//menambah kecepatan guru
    public float skill3=0;//menambah kecepatan pesawat saat menghilang

}
