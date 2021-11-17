using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class player : MonoBehaviour
{
    [SerializeField]public Material material,defaultmaterial;
    private Transform _slection;

    [SerializeField] private string selecttag = "player";

    [Header("palayer")]
    public characterscript[]playerpref;
    public Transform[] posisi;
    public int[] nomorKursi;

    public int jumlahPlayer;
    public int PencontekAwal;

    private void Start()
    {
        Invoke("addplayer", 0.9f);
    }
    void addplayer() 
    {
        for (int i = 0; i < playerpref.Length; i++)
        {

            if (i == PencontekAwal)
            {
                playerpref[i].tukangcontek = true;
            }
            else
            {
                playerpref[i].tukangcontek = false;
            }
            if (nomorKursi.Length==posisi.Length)
            {
                Instantiate(playerpref[i], posisi[nomorKursi[i]]);
            }
            else
            {
                Debug.Log("jumlah nomor kurang");
            }
            //depan= Random.Range(0,posisi.Length/3);
            //tengah= Random.Range(posisi.Length / 3, posisi.Length);
            //acak= Random.Range(depan,tengah);
            //playerpref[i].name = "player" + i.ToString();

            //if (cekpos[acak].cek==false)
            //{
            //    cekpos[acak].cek = true;
            //    j = acak;
            //}
            //else
            //{
            //    acak = tengah;
            //    j = acak;
            //}
        }
    }
}
