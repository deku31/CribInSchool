using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    //panel
    public GameObject settingpannel;
    //audio
    private BgmManager bgm;
    private SoundManager sfx;
    public GameObject bgmo;
    public GameObject audiomanager;
    public setting settingmanager;
    public int nomorbgm;
    //about
    public GameObject about;
    //popip setting
    public GameObject popupPos;
    //help
    public GameObject help;

    private void Awake()
    {
        bgm = FindObjectOfType<BgmManager>();
        sfx = FindObjectOfType<SoundManager>();
        settingmanager = FindObjectOfType<setting>();
    }
    private void Start()
    {
        bgm.bgmMethod(nomorbgm);
        settingpannel.SetActive(false);

    }
    public void LoadScene(string screenName)
    {

        sfx.buttonclickMethod();
        SceneManager.LoadScene(screenName);
        //setting
        DontDestroyOnLoad(bgmo);
        DontDestroyOnLoad(about);
        DontDestroyOnLoad(audiomanager);
        DontDestroyOnLoad(settingmanager);
    }
    public void home(string screenName)
    {
        sfx.buttonclickMethod();
        SceneManager.LoadScene(screenName);
        bgm.bgm.Stop();
    }
    public void start(string screenName)
    {
        sfx.buttonclickMethod();
        SceneManager.LoadScene(screenName);
        bgm.bgm.Stop();
    }
    public void option()
    {
        sfx.buttonclickMethod();
        settingmanager.panel.SetActive(true);
    }
   
    public void Exit()
    {
        sfx.buttonclickMethod();
        Application.Quit();

    }
    void exitmethod()
    {
    }
}
