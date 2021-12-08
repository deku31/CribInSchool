using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setting : MonoBehaviour
{
    public Slider volumesetting;
    public Slider volumesettingsfx;
    public BgmManager bgm;
    public SoundManager sfx;
    public GameObject panel;
    private void Awake()
    {
       bgm = FindObjectOfType<BgmManager>();
       sfx = FindObjectOfType<SoundManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        volumesetting.value = bgm.maxvol; 
        volumesetting.maxValue = bgm.maxvol;
        volumesettingsfx.value = sfx.maxvol; 
        volumesettingsfx.maxValue = sfx.maxvol;
    }
    public void optionex()
    {
        sfx.buttonclickMethod();
        panel.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        bgm.volume = volumesetting.value;
    }
}
