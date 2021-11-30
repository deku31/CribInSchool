using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PesawatScript : MonoBehaviour
{
    public int progres; // score yang dihasilkan dari puzzle manager
    public double hasilProgres; //hasil scroe dikali 80% / 0.8

    public player playermanager;
    public Gamemanager gamemanager;
    public GameObject _endPanel;

    public PuzzleManager puzzleManager;

    public void Start()
    {

    }

    public void Update()
    {
        progres = puzzleManager.score;
        hasilProgres = progres * 0.8;
    }
    /*
     * jika terkena tag player maka posisi nya akan berubah ke posisi ditentukan
     * jika terkena tag enemy bakal keluar panel end
     */
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "player2")
        {
            print("Sampai Tujuan");
            playermanager.pesawatpos.position = playermanager.targetpostransfer.position;
            playermanager.pesawat.SetActive(false);
            playermanager.postransferawal.position = playermanager.targetpostransfer.position;
            playermanager._transfer = false;


        }

        else if (other.transform.tag == "player3")
        {
            print("On The Way");
            playermanager.pesawatpos.position = playermanager.targetpostransfer.position;
            //playermanager.pesawat.SetActive(false);
            playermanager.postransferawal.position = playermanager.targetpostransfer.position;
            playermanager._transfer = true;
        }

        else if (other.transform.tag =="enemy")
        {
            Destroy(playermanager.pesawat);
            _endPanel.SetActive(true);
        }
    }
}
