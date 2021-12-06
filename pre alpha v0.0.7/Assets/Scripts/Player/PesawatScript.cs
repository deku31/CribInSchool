using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PesawatScript : MonoBehaviour
{
    public player playermanager;
    public Gamemanager gamemanager;
    public GameObject _endPanel;

    public ProgressBarPlayer[] pemain;

    //audio manager
    [SerializeField] private SoundManager audiomanager;
    int urutan;
    private void Awake()
    {
        urutan = playermanager.acakpencontek;
        audiomanager = FindObjectOfType<SoundManager>();
    }
    void endpanelMethod()
    {
        _endPanel.SetActive(true);
        audiomanager.resultMethod(3);
    }
    void triggercallplayer(int pemain1, int pemain2)
    {
        var pemegangcontekan = pemain1;
        pemain[pemegangcontekan].current = pemain[pemain2].current;
        playermanager.pesawatpos.position = playermanager.targetpostransfer.position;
        playermanager.posisibar.position = playermanager.targetpostransfer.position;
        playermanager.pesawat.SetActive(false);
        playermanager.tanda.SetActive(true);
        playermanager.postransferawal.position = playermanager.targetpostransfer.position;
        playermanager._transfer = false;
        audiomanager.transferMethod(1);
        playermanager.nourut = urutan;
        if (playermanager.pzm.solvedPuzzle == true)
        {
            Invoke("endpanelMethod", 0.5f);
        }
    }
    /*
     * jika terkena tag player maka posisi nya akan berubah ke posisi ditentukan
     * jika terkena tag enemy bakal keluar panel end
     */
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            triggercallplayer( 0, 1);
            if (playermanager.stargame==true)
            {
                playermanager.nourut = 0;
            }
        }
        else if (other.transform.tag == "player2")
        {
            triggercallplayer( 1,0 );
            if (playermanager.stargame == true)
            {
                playermanager.nourut = 1;
            }
        }
        if (other.transform.tag == "enemy")//jika terkena murid cepu 
        {
            Destroy(playermanager.pesawat);
            _endPanel.SetActive(true);
        }

    }
}
