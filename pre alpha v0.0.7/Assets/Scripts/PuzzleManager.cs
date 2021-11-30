using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    //mengambil dari script player
    public player player;
    //untuk menentukan kamera puzzle
    public Camera cam;

    /*kamera gamepalay 
     * yang atas tag main camera bertujuan untuk select player
     * yang bawah tag default berfungsi agar puzzle yang menggunakan sistem kamera dapat digunakan
    */
    public GameObject gamePlayCamera;
    public GameObject gamePlaycamera2;

    //setiap puzzle yang diselesaikan akan menambah skor atau dengan katalain jumlah puzzle yang telah diselesaikan dengan benar
    public int score = 0;

    //bertujuan mengambil prefab sliding puzzle
    /*
     * menggunakan array bertujuan jika ingin menggunakan sliding puzzle dengan jumlah selain 3x3 dapat memasukan prefab kesini
     */
    public GameObject[] SlidingpuzzlePrefabs;
    public slidingpuzzlescript[] slidingscript;

    public GameObject[] _WordScramble;
    public QuizManager[] wordScrambleScript;

    public GameObject[] wordSearchingPref;
    public WordChecker[] WordSearchingScript;

    public Transform perent;/*berfungsi tempan instance atau tempat munculnya puzzle*/
    //nomor puzzle
    public int PuzzleNUmber;
    public int jumlahPuzzle;
    //nomor urutan cabang puzzle
    public int urutanPuzzle;

    public bool munculpuzzle;
    //fungsi dimana hitung score dapat digunakan
    public bool hitungScore;

    public Animator puzzleanim;

    //memunculkan btn popup
    public GameObject btnPopuppuzzle;

    //menghitung jumlah soal seluruh puzzle
    public int jumlahSoal;
    public int jumlahseluruhpuzzle=3;

    //end game
    public bool solvedPuzzle;
    public GameObject EndPanel;
    public endManager end;

    private void Start()
    {
        solvedPuzzle = false;
        jumlahSoal = 0;
        puzzleanim = GetComponent<Animator>();/*mengambil komponen animator*/
        PuzzleNUmber = Random.Range(0,jumlahPuzzle);
        SlidingpuzzlePrefabs[urutanPuzzle].SetActive(true);
        munculpuzzle = true;
        hitungScore = false;
    }
    private void Update()
    {
        if (PuzzleNUmber == 0)
        {
            cam.enabled = false;
            slidingPuzzle();
        }
        else if (PuzzleNUmber == 1)
        {
            cam.enabled = true;
            WordScramble();

        }
        else if (PuzzleNUmber == 2)
        {
            cam.enabled = false;
            WordSearching();
        }
        else
        {
            if (jumlahseluruhpuzzle==0)
            {
                keluar();
            }
            else if(jumlahseluruhpuzzle==1)
            {
                PuzzleNUmber=0;
            }
           
        }
        if (player.munculPuzzle == true)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                keluar();
            }
        }
    }
    //=============================================================================================================================
    private void WordScramble()
    {
        wordScrambleScript[urutanPuzzle].pzm = GetComponent<PuzzleManager>();
        if (munculpuzzle == true)
        {
            munculpuzzle = false;
            instance(_WordScramble);
        }
        if (GameObject.Find(_WordScramble[urutanPuzzle].name + "(Clone)") == null)
        {
            jumlahseluruhpuzzle -= 1;

            munculpuzzle = true;
            PuzzleNUmber += 1;
        }
    }    
    //=============================================================================================================================
    private void slidingPuzzle()
    {
        slidingscript[urutanPuzzle].pzm = GetComponent<PuzzleManager>();
        if (munculpuzzle == true)
        {

            munculpuzzle = false;
            instance(SlidingpuzzlePrefabs);

        }
        if (GameObject.Find(SlidingpuzzlePrefabs[urutanPuzzle].name + "(Clone)") == null)
        {
            //score += 1;
            jumlahseluruhpuzzle -= 1;
            if (jumlahseluruhpuzzle > 1)
            {
                PuzzleNUmber += 1;
            }
            else if (jumlahseluruhpuzzle < 1)
            {
                PuzzleNUmber += jumlahPuzzle + 1;
            }
            munculpuzzle = true;
            
        }
      
    }
    //=============================================================================================================================
    private void WordSearching()
    {
        WordSearchingScript[urutanPuzzle].pzm = GetComponent<PuzzleManager>();
        if (munculpuzzle == true)
        {
            munculpuzzle = false;
            instance(wordSearchingPref);

        }
        if (GameObject.Find(wordSearchingPref[urutanPuzzle].name + "(Clone)") == null)
        {
            jumlahseluruhpuzzle -= 1;

            //score += 1;
            munculpuzzle = true;
            PuzzleNUmber += 1;
        }
      
    }
    private void instance(GameObject[] jenis)
    {
        Instantiate(jenis[urutanPuzzle], perent);
    }
    public void keluar()
    {
        gamePlaycamera2.SetActive(false);
        gamePlayCamera.SetActive(true);
        gameObject.SetActive(false);
        btnPopuppuzzle.SetActive(true);
        player.munculPuzzle = false;
    }
    public void solved()
    {
        solvedPuzzle = true;
        end.nilaitertinggi = jumlahSoal;
        end.jawabanBenar = score;
        EndPanel.SetActive(true);
        gamePlaycamera2.SetActive(false);
        gamePlayCamera.SetActive(true);
        gameObject.SetActive(false);
        btnPopuppuzzle.SetActive(true);
        player.munculPuzzle = false;
    }
}
