using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    private BgmManager bgm;
    private SoundManager sfx;
    public GameObject bgmo;

    private void Awake()
    {
        bgm = FindObjectOfType<BgmManager>();
        sfx = FindObjectOfType<SoundManager>();
    }
    private void Start()
    {
        bgm.bgmMethod(1);
    }
    public void LoadScene(string screenName)
    {
        SceneManager.LoadScene(screenName);
        DontDestroyOnLoad(bgmo);
        bgm.bgm.Stop();
    }
    public void home(string screenName)
    {
        SceneManager.LoadScene(screenName);
        bgm.bgm.Stop();
    }
    public void start(string screenName)
    {
        SceneManager.LoadScene(screenName);
        bgm.bgm.Stop();
    }

    public void Exit()
    {
        Application.Quit();

    }
}
