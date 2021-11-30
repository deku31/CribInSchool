using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PesawatScript : MonoBehaviour
{
    
    public player playermanager;
    public Gamemanager gamemanager;
    public GameObject _endPanel;
    /*
     * jika terkena tag player maka posisi nya akan berubah ke posisi ditentukan
     * jika terkena tag enemy bakal keluar panel end
     */
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "player2")
        {
            print("a");
            playermanager.pesawatpos.position = playermanager.targetpostransfer.position;
            playermanager.pesawat.SetActive(false);
            playermanager.postransferawal.position = playermanager.targetpostransfer.position;
            playermanager._transfer = false;
        }
        else if (other.transform.tag =="enemy")
        {
            Destroy(playermanager.pesawat);
            _endPanel.SetActive(true);
        }
    }
}
