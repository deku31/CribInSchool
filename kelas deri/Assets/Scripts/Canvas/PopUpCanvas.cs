using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PopUpCanvas : MonoBehaviour
{
    public GameObject Panel;

    public GameObject popupButton;

    public void Start()
    {

    }

    public void OpenPanel()
    {
        if (Panel != null)
        {
            Panel.SetActive(true);
        }

        //GameObject popupButton = GameObject.FindWithTag("PopupButton");
        //popupButton.SetActive(false);
    }
    
    public void ClosePanel()
    {
        //GameObject puzzle = GameObject.FindWithTag("PuzzleManager");
        //puzzle.SetActive(false);

        //GameObject puzzle = GameObject.FindWithTag("MainCamera");
        //puzzle.SetActive(false);

        FindObjectOfType<PuzzleManager>().keluar();
    }
}
