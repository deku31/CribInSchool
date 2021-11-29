using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterscript : MonoBehaviour
{
    public bool tukangcontek;
    public Transform tanda;
    public LayerMask layer;
    private void Start()
    {
        //tanda.SetActive(false);
        manager();
    }
    private void manager()
    {
        if (tukangcontek==true)
        {
            transform.gameObject.tag = "Player";
            transform.gameObject.layer = LayerMask.NameToLayer("Target");
        }
        else
        {
            //transform.gameObject.tag = "player2";
            //transform.gameObject.layer = LayerMask.NameToLayer("Default");
        }
    }
    private void Update()
    {
        //if (tukangcontek==true)
        //{
        //    tanda.SetActive(true);
        //}
        //else
        //{
        //    tanda.SetActive(false);
        //}
    }
}
