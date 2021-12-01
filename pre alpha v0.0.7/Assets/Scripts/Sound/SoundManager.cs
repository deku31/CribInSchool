using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    public AudioClip[] bgmclip;//kusus bgm game
    private AudioSource bgm;

    public AudioClip[] popupclip;
    private AudioSource popup;

    public AudioClip clickbuttonClip;
    private AudioSource clickButton;

    private void Awake()
    {
        bgm = GetComponent<AudioSource>();
        popup = GetComponent<AudioSource>();
        clickButton = GetComponent<AudioSource>();
    }
    public void bgmMethod(int nomorbgm)
    {
        /*keterangan :
        *nomorbgm 0 bgm class
        * nomorbgm 1 blm dimasukan 
        */
        bgm.PlayOneShot(bgmclip[nomorbgm], 0.7f);
        bgm.loop = true;
    }
    public void popupMetohod(int nomorPopup)
    {
        /*keterangan :
        *nomorpopup 0 popup keluar
        * nomorpopup 1 popup muncul 
        */
        popup.PlayOneShot(popupclip[nomorPopup],0.8f);
    }
    public void buttonclickMethod()
    {
        clickButton.PlayOneShot(clickbuttonClip,0.8f);
    }
}
