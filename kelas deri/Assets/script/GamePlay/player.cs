using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class player : MonoBehaviour
{
    
    public GameObject maincamera;
    public GameObject camera;
    //variabel btn popup puzzle
    public GameObject btnPopuppuzzle;

    [SerializeField]public Material material,defaultmaterial;
    private Transform _slection;
    public GameObject puzzle;
    [SerializeField] private string selecttag = "player";

    [Header("palayer")]
    public characterscript[]playerpref;
    public Transform[] posisi;
    public int[] nomorKursi;

    public int jumlahPlayer;
    public int PencontekAwal;

    // int depan,tengah,acak;
    //public cekposisi[] cekpos;

    public bool munculPuzzle;

    private void Start()
    {
        munculPuzzle = false;
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
    // Update is called once per frame
    void Update()
    {
        if (_slection!=null)
        {
            var selectionrenderer = _slection.GetComponent<Renderer>();
            selectionrenderer.material = defaultmaterial;
            _slection = null;
        }
        if (munculPuzzle ==false)
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                var selection = hit.transform;
                if (selection.CompareTag(selecttag))
                {
                    var selectionrenderer = selection.GetComponent<Renderer>();
                    if (selectionrenderer != null)
                    {
                        selectionrenderer.material = material;
                       
                        if (Input.GetKey(KeyCode.Mouse0))
                        {
                            //openPuzzle();
                        }
                    }
                    _slection = selection;
                }
            }

        }
    }
    public void openPuzzle()
    {
        maincamera.SetActive(false);
        camera.SetActive(true);
        puzzle.SetActive(true);
        btnPopuppuzzle.SetActive(false);
        munculPuzzle = true;
    }
}
