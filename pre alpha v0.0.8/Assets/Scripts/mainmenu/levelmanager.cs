using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class levelmanager : MonoBehaviour
{
    public int nomorlv;
    public int urutanNumber;

    public bool[] lvUnlock;
    // Start is called before the first frame update
    void Start()
    {
        lvUnlock[0] = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
