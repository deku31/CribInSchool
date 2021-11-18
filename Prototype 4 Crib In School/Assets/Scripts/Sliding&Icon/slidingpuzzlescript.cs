﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class slidingpuzzlescript : MonoBehaviour
{
    [Header("ProgressBar")]
    public progressBarScript progressbar;
    //==============================================================
    [Header("camera")]
    //mendeteksi camera
    private Camera _Camera;

    //sliding puzzle script
    public GameObject progressbarpuzzle;
    public GameObject progressbarTime;
    [Header("tiles")]
    public GameObject slidingpuzzleobj;
    //tiles atau kotak yang ada di dalam permainan
    [SerializeField] private Transform emptyspace = null;
    [SerializeField] public Tiles[] tiles;
    public float jarak;

    //iconsearching script
    public GameObject iconsearchingObj;
    public SpriteRenderer[] Box;
    public Transform[] poskotak;
    public int poskotakbenar;
    public Sprite kotakbenar, kotaksalah, kotakdefault;
    public  bool lihatKotak;

    private float spawniconsearching = 1f;
    //icon searcing
    public float gantikotak=3f;
    //==============================================================
    public bool _pause;
    //==============================================================

    //jika selesai;
    //public GameObject imgend;
    public GameObject empty;
    public bool solved;
    //===============================================================
    [Header("managerPuzzle")]
    public bool slidingPuzzle;
    public GameObject EndPanel;
    public endManager end;


    private void Start()
    {
        poskotakbenar = Random.Range(0, poskotak.Length);
        EndPanel.SetActive(false);
        lihatKotak = false;
        slidingPuzzle = true;

        _Camera = Camera.main;
        // imgend.SetActive(false);
        empty.SetActive(true);
        solved = false;
        _pause = false;
        //back = false;
        //fungsi acak tiles ketika mulai
        shuffle();
    }
    private void Update()
    {
        /*icon searching script*/
        //menghitung waktu kembali kotak ke default
        if (lihatKotak==true)
        {
            if (gantikotak>=0.1f)
            {
                gantikotak -= Time.deltaTime;
            }
            else
            {
                lihatKotak = false;
                gantikotak = 3f;
            }
        }
        //fungsi mengembalikan kotak default
        else
        {
            for (int i = 0; i < Box.Length; i++)
            {
                Box[i].sprite = kotakdefault;
                print("kembali" + i);
                lihatKotak = false;
            }
        }
        /*endiconsearching script*/

        //ketika solved bernilai true maka kotak tidak bisa dipindahkan lagi
        if (solved == false)
        {
            gantipuzzle();
            int posbenar = 0;
            progressbar.current = 0;
            foreach (var i in tiles)
            {
                if (i != null)
                {
                    if (i.benar == true)
                    {
                        posbenar++;
                        progressbar.current = posbenar * 10;
                    }
                }
            }
         
            if (posbenar == tiles.Length )
            {
                if (slidingPuzzle==true)
                {
                    end.jawabanBenar++;
                    slidingPuzzle = false;
                }
                progressbarpuzzle.SetActive(false);
            }

            if (Input.GetMouseButtonDown(0))
            {
                manager();
            }
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            keluarPuzzle();
        }

    }

    //ganti puzzle
    private void gantipuzzle()
    {
        if (slidingPuzzle==true)
        {
            slidingpuzzleobj.SetActive(true);
            iconsearchingObj.SetActive(false);
        }
        else
        {
            slidingpuzzleobj.SetActive(false);
            iconsearchingObj.SetActive(true);
        }
    }

    //manager gerak puzzle
    private void manager()
    {
        Ray ray = _Camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
        if (hit)
        {
            if (slidingPuzzle == true)
            {
                if (Vector2.Distance(emptyspace.position, hit.transform.position) < jarak)
                {
                    Vector3 lastPosition = emptyspace.position;
                    Tiles tile = hit.transform.GetComponent<Tiles>();
                    emptyspace.position = tile.posisitarget;
                    tile.posisitarget = lastPosition;
                }
            }
            //icon searching script

            else
            {
                SpriteRenderer box = hit.transform.GetComponent<SpriteRenderer>();
                if (hit.transform.position == poskotak[poskotakbenar].position)
                {
                    for (int i = 0; i < Box.Length; i++)
                    {
                        if (lihatKotak == true && Box[i].sprite != kotakdefault)
                        {
                            Box[i].sprite = kotakdefault;
                            lihatKotak = false;
                        }
                        if (lihatKotak == false || box.transform.position == poskotak[i].transform.position)
                        {
                            box.sprite = kotakbenar;
                            lihatKotak = true;

                            if (solved==false)
                            {
                                end.jawabanBenar++;
                                solved = true;
                            }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < Box.Length; i++)
                    {
                        if (lihatKotak == true&&Box[i].sprite!=kotakdefault)
                        {
                            Box[i].sprite = kotakdefault;
                            print("kembali" + i);
                            lihatKotak = false;
                        }
                        if (lihatKotak == false || box.transform.position == poskotak[i].transform.position)
                        {
                            print("salah");
                            box.sprite = kotaksalah;
                            gantikotak = 3f;
                            lihatKotak = true;
                        }
                    }
                }
            }
        }
    }
    //untuk keluar aplikasi. bisa juga dibuat untuk menghilangkan puzzle nya
    public void keluarPuzzle()
    {
        Application.Quit();
    }
    //tombol pause dan resume
    public void pause()
    {
        if (_pause == false)
        {
            _pause = true;

        }
        else
        {
            _pause = false;

        }
    }
    // method ketika puzzle selesai
    private void EndGame()
    {
        EndPanel.SetActive(true);
    }



    public void shuffle() //merandom posisi kotak diawal
    {
        //jika jumlah i lebih kecil dari pada jumlah tiles(kotak) maka akan terjadi perulangan
        for (int i = 0; i < tiles.Length - 1; i++)
        {
            //jika koak yang bernilai i tidak null maka akan terjadi pengacakan
            if (tiles[i] != null)
            {
                int random = Random.Range(1, 2);
                int rand = Random.Range(2, 4);
                var lastpos = tiles[i].posisitarget;
                if (rand < tiles.Length - 1)
                {
                    if (random != i + 1 && rand != i + 1 && random != i && rand != i)
                    {
                        tiles[i].posisitarget = tiles[rand].posisitarget;
                        tiles[rand].posisitarget = tiles[random].posisitarget;
                        tiles[random].posisitarget = lastpos;
                    }

                }
                else
                {
                    tiles[i].posisitarget = tiles[random].posisitarget;
                    tiles[random].posisitarget = lastpos;
                }
                var tile = tiles[i];
                tiles[i] = tiles[rand];
                tiles[rand] = tiles[random];
                tiles[random] = tile;

            }
        }
    }

    public int findindex(Tiles ts)
    {
        for (int i = 0; i < tiles.Length; i++)
        {
            if (tiles[i] != null)
            {
                if (tiles[i] == ts)
                {
                    return i;
                }
            }
        }
        return -1;
    }
}