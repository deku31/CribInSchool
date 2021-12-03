using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PesawatScript : MonoBehaviour
{
    public player playermanager;
    public Gamemanager gamemanager;
    public GameObject _endPanel;

    public ProgressBarPlayer pemaininti;
    public ProgressBarPlayer[] pemainlain;

    //audio manager
    [SerializeField] private SoundManager audiomanager;

    private void Awake()
    {
        audiomanager = FindObjectOfType<SoundManager>();
    }
    void endpanelMethod()
    {
        _endPanel.SetActive(true);
        audiomanager.resultMethod(2);
    }
    /*
     * jika terkena tag player maka posisi nya akan berubah ke posisi ditentukan
     * jika terkena tag enemy bakal keluar panel end
     */
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "player2")
        {
            pemainlain[0].current=pemaininti.current;
            playermanager.pesawatpos.position = playermanager.targetpostransfer.position;
            playermanager.pesawat.SetActive(false);
            playermanager.postransferawal.position = playermanager.targetpostransfer.position;
            playermanager._transfer = false;
            audiomanager.transferMethod(1);
            Invoke("endpanelMethod",0.5f);
        }

        else if (other.transform.tag =="enemy")
        {
            Destroy(playermanager.pesawat);
            _endPanel.SetActive(true);
        }
        if (other.transform.tag == "umpan")
        {
            playermanager.pesawatpos.position = playermanager.targetpostransfer.position;
            playermanager.postransferawal.position = playermanager.targetpostransfer.position;
            playermanager._transfer = false;
        }
    }
}
