using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Gamemanager : MonoBehaviour
{
    public player _PlayerManager;
    public guruMangaer _GuruManger;
    public PuzzleManager _PuzzleManager;
    public JarakPandang _JarakPandang;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_PlayerManager.munculPuzzle==false)
            {
                Application.Quit();
            }
            else if (_PlayerManager.puzzle==true)
            {
                _PuzzleManager.keluar();
            }
        }
    }
}
