using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarPlayer : MonoBehaviour
{
    public float maxlenght = 4;

    public int current = 0;

    public Image imgProgressPuzzle;

    void Start()
    {
    }

    void Update()
    {
        GetCurrentFill();
    }
    void GetCurrentFill()
    {
        float fillAmount = (float)current / (float)maxlenght;
        imgProgressPuzzle.fillAmount = fillAmount;
    }
}
