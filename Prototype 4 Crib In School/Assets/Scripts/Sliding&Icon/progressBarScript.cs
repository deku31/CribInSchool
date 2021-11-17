using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class progressBarScript : MonoBehaviour
{
    public float maxlenght;

    public int current;

    public Image imgProgressPuzzle;

    void Start()
    {
    }

    // Update is called once per frame
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
