using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pesawatKetahuan : MonoBehaviour
{
    public player playermanager;
    public GameObject _endPanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag=="guru")
        {
            print("ketahuan");
            Destroy(playermanager.pesawat);
            _endPanel.SetActive(true);
        }
    }
}
