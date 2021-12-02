using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Gamemanager : MonoBehaviour
{
    public player _PlayerManager;
    public guruMangaer _GuruManger;
    public PuzzleManager _PuzzleManager;
    private PauseManager _PauseManager;
    [SerializeField]private SoundManager bgmkelas;
    [SerializeField] private int nomorAudio;
    private void Awake()
    {
        _PauseManager = GameObject.Find("gameplaymanager").GetComponent<PauseManager>();
        bgmkelas.bgmMethod(nomorAudio);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_PlayerManager.munculPuzzle==false)
            {
                _PauseManager.Pause();
            }
            else if (_PlayerManager.puzzle==true)
            {
                _PuzzleManager.keluar();
            }
        }
    }
}
