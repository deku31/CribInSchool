using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterscript : MonoBehaviour
{
    public bool pencontekawal;
    public GameObject tanda;
    public Transform posisi;

    [SerializeField] private player playermanager;

    private void Start()
    {
        playermanager = FindObjectOfType<player>();
        //tanda.SetActive(false);
       // manager();
    }
    private void manager()
    {
        for (int i = 0; i < playermanager.jumlahPlayer; i++)
        {
            if (pencontekawal == true)
            {
                transform.gameObject.tag = "Player";
            }
        }
       
    }
    private void Update()
    {
        manager();
    }
}
