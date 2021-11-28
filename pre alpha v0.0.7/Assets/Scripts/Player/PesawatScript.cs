using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PesawatScript : MonoBehaviour
{
    public ProgressBarPlayer progresPlayer;
    public int _progresPlayer;

    private void Awake()
    {
        progresPlayer = GameObject.Find("gameplaymanager").GetComponent<ProgressBarPlayer>();
    }

    void Start()
    {
        _progresPlayer = progresPlayer.current;
    }

    public void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 20), "Score : " + _progresPlayer);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.name == "TargetPesawat")
        {
            _progresPlayer++;
            progresPlayer.current = _progresPlayer;
            //Destroy(gameObject);
            Debug.Log("Sudah Transfer");
        }
    }
}
