using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterscript : MonoBehaviour
{
    public bool tukangcontek;
    public GameObject tanda;
    private void Start()
    {
        tanda.SetActive(false);
        manager();
    }
    private void manager()
    {
        if (tukangcontek==true)
        {
            transform.gameObject.tag = "player";
        }
        else
        {
            transform.gameObject.tag = "Untagged";
        }
    }
    private void Update()
    {
        if (tukangcontek==true)
        {
            tanda.SetActive(true);
        }
        else
        {
            tanda.SetActive(false);
        }
    }
}
