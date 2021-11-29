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
    [SerializeField] private string selecttag = "player2";

    [Header("Player")]
    public characterscript[]playerpref;
    public Transform[] posisi;
    public int[] nomorKursi;

    public int jumlahPlayer;
    public int PencontekAwal;
    public int temanPencontek;


    // int depan,tengah,acak;
    //public cekposisi[] cekpos;

    public bool munculPuzzle;//kondisi memunculkan puzzle
    //untuk transfer contekan
    public bool _transfer;
    public Transform targetpostransfer;//target player yang akan di bagikan contekan
    public Transform posisibar;//membaca posisi bar kalo mau ganti objek tambahin function transform baru
    private void Start()
    {
        temanPencontek = PencontekAwal;
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
            if (_transfer == true)//jika transfer bernilai true maka dapat pindah posisi
            {
                transfer(targetpostransfer);
            }
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
                            _transfer=true;//jika posisi player tidak sama maka transfer true
                            targetpostransfer = selection;//mengubah posisi target sesuai player yang di klik
                        }
                    }
                    _slection = selection;
                }
            }

        }
    }

    //function atau method untuk script tranfer
    void transfer(Transform postransfer)
    {
        /*
         * catatan 
         * itu kecepatan nya blm ku atur agar balance
         * jika z atau x sampai lebih dulu pada posisi objek nya akan goyang goyang
         * coba perbaikin
         * 
         * posisibar.position bisa diubah sesuai transform yang dibuatuntuk pesawat
         */

        float speedX=1.5f*Time.deltaTime;
        float speedz=1f*Time.deltaTime;
        //kondisi posisi x jika tidak sama dengan posisi target maka berikut pengaturannya
        if (posisibar.position!=postransfer.position)
        {
            if ((posisibar.position.x < postransfer.position.x - 0.01f))
            {
                speedX *= 1;
            }
            else if ((posisibar.position.x > postransfer.position.x + 0.01f))
            {
                speedX *= -1;
            }
            else
            {
                _transfer = false;
            }
            //kondisi posisi z jika tidak sama dengan posisi target maka berikut pengaturannya
            if ((posisibar.position.z < postransfer.position.z - 0.01f))
            {
                speedz *= 1;
            }
            else if ((posisibar.position.z > postransfer.position.z + 0.01f))
            {
                speedz *= -1;
            }
        }
        else
        {
            _transfer = false;
        }
        posisibar.position = new Vector3(posisibar.position.x + speedX, posisibar.position.y, posisibar.position.z + speedz);

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
