using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmManager : MonoBehaviour
{
    public AudioClip[] bgmclip;//kusus bgm game
    public AudioSource bgm;

    // Start is called before the first frame update
    private void Awake()
    {
        bgm = GetComponent<AudioSource>();
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
