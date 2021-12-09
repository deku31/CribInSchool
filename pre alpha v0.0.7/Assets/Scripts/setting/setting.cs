﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setting : MonoBehaviour
{
    public GameObject panel;
    public GameObject about;
    //sound
    public Slider volumesetting;
    public Slider volumesettingsfx;
    public BgmManager bgm;
    public SoundManager sfx;

    //QUALITY   setting
    public Dropdown quality;
    public int lvquality=3;
    private void Awake()
    {
        bgm = FindObjectOfType<BgmManager>();
        sfx = FindObjectOfType<SoundManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        //volumesetting.value = bgm.maxvol; 
        volumesetting.maxValue = bgm.maxvol;
        //volumesettingsfx.value = sfx.maxvol; 
        volumesettingsfx.maxValue = 1;
    }
    public void optionex()
    {
        sfx.buttonclickMethod();
        panel.SetActive(false);
    }
    public void AboutEx()
    {
        sfx.buttonclickMethod();
        panel.SetActive(true);
        about.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        bgm.volume = volumesetting.value;
        sfx.volumeafx = volumesettingsfx.value;
        if (quality.captionText.text == "LOW")
        {
            lvquality = 1;
        }
        else if (quality.captionText.text == "MEDIUM")
        {
            lvquality = 2;
        }
        else if (quality.captionText.text == "HIGH")
        {
            lvquality = 3;
        }
        //for (int i = 0; i < quality.options.Count; i++)
        //{

        //}
        PlayerPrefs.SetInt("masterQuality", lvquality);
        QualitySettings.SetQualityLevel(lvquality);
    }
}