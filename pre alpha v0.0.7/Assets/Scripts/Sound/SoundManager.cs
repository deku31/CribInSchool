using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    [Header("classroom")]
    public AudioClip[] bgmclip;//kusus bgm game
    private AudioSource bgm;

    public AudioClip[] popupclip;//kusus popup sfx
    private AudioSource popup;

    public AudioClip clickbuttonClip;//sfx seluruh tombol
    private AudioSource clickButton;

    public AudioClip guruWalkClip;//sfx suara guru jalan
    private AudioSource guruWalk;

    [Header("Puzzle manager")]
    public AudioClip[] SlidingPuzzleClip;
    private AudioSource sfxSlidingPuzzle;

    public AudioClip[] WordScrambleClip;
    private AudioSource WordScramble;

    private void Awake()
    {
        bgm = GetComponent<AudioSource>();
        popup = GetComponent<AudioSource>();
        clickButton = GetComponent<AudioSource>();
        guruWalk = GetComponent<AudioSource>();
        //puzzle sfx
        sfxSlidingPuzzle = GetComponent<AudioSource>();
        WordScramble = GetComponent<AudioSource>();
    }
    public void bgmMethod(int nomorbgm)
    {
        /*keterangan :
        *nomorbgm 0 bgm class
        * nomorbgm 1 blm dimasukan 
        */
        bgm.PlayOneShot(bgmclip[nomorbgm], 0.4f);
        bgm.loop = true;
    }
    public void popupMetohod(int nomorPopup)
    {
        /*keterangan :
        * nomorpopup 0 popup keluar
        * nomorpopup 1 popup muncul 
        * nomorpopup 2 popup jawaban benar 
        * nomorpopup 3 popup jawaban salah 
        * nomorpopup 4 popup times up
        */
        popup.PlayOneShot(popupclip[nomorPopup],0.8f);
    }
    public void buttonclickMethod()
    {
        clickButton.PlayOneShot(clickbuttonClip,0.8f);
    }

    public void guruWalkMethod(float volume, float pitch)//dapat mengatur suara volume ketika mendekati player
    {
        guruWalk.PlayOneShot(guruWalkClip,volume);
        guruWalk.pitch = pitch;
    }

    //puzzle method
    public void slidingPuzzleMetohod(int nomorPuzzle)
    {
        /*keterangan
         * nomor 0 suara klik kotak
         * nomor 0 suara kotak selesai
         */
        sfxSlidingPuzzle.PlayOneShot(SlidingPuzzleClip[nomorPuzzle],0.7f);
    }
    public void WordScrambleMethod(int nomorPuzzle)
    {
        /*keterangan
         * nomor 0 suara klik huruf
         * nomor 1 suara puzzle selesai
         */
        WordScramble.PlayOneShot(WordScrambleClip[nomorPuzzle],0.7f);
    }
}
