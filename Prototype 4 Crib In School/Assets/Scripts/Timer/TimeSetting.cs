using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeSetting : MonoBehaviour
{
    public Text textTimer;
    public float waktu;

    public bool waktuAktif = true;
    public GameObject puzzleScramble;

    public void SetText()
    {
        int Menit = Mathf.FloorToInt(waktu / 60);
        int Detik = Mathf.FloorToInt(waktu % 60);
        textTimer.text = Menit.ToString("00") + ":" + Detik.ToString("00");
    }

    float s;

    private void Update()
    {
        
        if (waktuAktif)
        {
            s += Time.deltaTime;
            if (s >= 1)
            {
                waktu--;
                s = 0;
            }
        }
        

        if (waktuAktif && waktu <= 0)
        {
            Debug.Log("Game Over1");
            waktuAktif = false;
            //FindObjectOfType<PuzzleManager>().EndGame();
            Destroy(puzzleScramble);
        }

        SetText();
    }
}
