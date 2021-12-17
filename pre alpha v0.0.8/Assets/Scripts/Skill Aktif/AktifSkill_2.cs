using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using System;

public class AktifSkill_2 : MonoBehaviour
{
    public static Action<Vector3> OnDistraction;

    public NavMeshAgent agentGuru;
    public Gamemanager gm;
    public GameObject plane;
    public Image darkMask;
    public Text textCooldownActived;
    public Text textCooldownSpawn;

    public float timeDistractDefault = 10f;
    private float timeDistract;

    public float durasispawnDefault = 120;
    private float durasispawn;

    [SerializeField]
    private GameObject batu;

    public bool skillAktif;
    public bool distractSkill;

    private bool _distracted;

    private void Awake()
    {
        //agentGuru = GameObject.FindGameObjectWithTag("Guru(Clone)").GetComponent<NavMeshAgent>();
        //gm = FindObjectOfType<Gamemanager>();
    }

    void Start()
    {
        textCooldownActived.enabled = false;
        if (gm != null)
        {
            skillAktif = true;
            timeDistract = timeDistractDefault;
            durasispawn = durasispawnDefault;
            textCooldownActived.enabled = false;
        }
        OnDistraction += ThrowCoin;
        OnDistraction += ThrowCoin;
        AktifSkill_2.OnDistraction += GetDistracted;
    }

    public void Update()
    {
        AktifSkill_2.OnDistraction += GetDistracted;

        gm = FindObjectOfType<Gamemanager>();

        if (distractSkill == true)
        {
            agentGuru = FindInActiveObjectByName("Guru(Clone)").GetComponent<NavMeshAgent>();

            if (timeDistract > 0.1f)
            {
                timeDistract -= Time.deltaTime;
                float roundedCd = Mathf.Round(timeDistract);
                textCooldownActived.text = roundedCd.ToString();

                if (Input.GetMouseButtonDown(0))
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    if (Physics.Raycast(ray, out RaycastHit hitInfo))
                    {
                        if (hitInfo.collider.tag == "Plane")
                        {
                            if (!(OnDistraction is null))
                                OnDistraction(hitInfo.point);
                        }
                    }
                }
            }
            else
            {
                distractSkill = false;
                timeDistract = timeDistractDefault;
                textCooldownActived.enabled = false;
            }
        }

        if (skillAktif == false)
        {
            if (durasispawn > 0.1f)
            {
                textCooldownSpawn.enabled = true;
                durasispawn -= Time.deltaTime;
                float roundedCd = Mathf.Round(durasispawn);
                textCooldownSpawn.text = roundedCd.ToString();
            }
            else
            {
                skillAktif = true;
                durasispawn = durasispawnDefault;
            }
        }
    }

    private void FixedUpdate()
    {

    }

    public void Distract()
    {

        if (gm != null)
        {
            if (skillAktif == true)
            {
                distractSkill = true;
                skillAktif = false;
                textCooldownActived.enabled = true;
            }
            else
            {
                print("proses");
            }
        }
        else
        {
            print("balm ada gm");
        }
    }

    void activeSkills()
    {
        distractSkill = false;
    }

    void activeButtonSkills()
    {
        skillAktif = true;
    }

    private void ThrowCoin(Vector3 pos)
    {
        Instantiate(batu, pos, Quaternion.identity);
    }

    private void OnDestroy()
    {
        AktifSkill_2.OnDistraction -= GetDistracted;
        OnDistraction -= ThrowCoin;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_distracted)
            return;
    }

    public void GetDistracted(Vector3 pos)
    {
        if (Vector3.Distance(transform.position, pos) <= 15f)
        {
            StopAllCoroutines();
            _distracted = true;
            agentGuru.SetDestination(pos);
            StartCoroutine(FollowDistraction(pos));
        }
    }

    private IEnumerator FollowDistraction(Vector3 pos)
    {
        while (Vector3.Distance(transform.position, pos) > 2f)
            yield return null;
        agentGuru.SetDestination(transform.position);
    }

    GameObject FindInActiveObjectByTag(string tag) //fungsi mencari object yang tidak aktif menggunakan tag
    {

        Transform[] objs = Resources.FindObjectsOfTypeAll<Transform>() as Transform[];
        for (int i = 0; i < objs.Length; i++)
        {
            if (objs[i].hideFlags == HideFlags.None)
            {
                if (objs[i].CompareTag(tag))
                {

                    return objs[i].gameObject;
                }
            }
        }
        return null;
    }

    GameObject FindInActiveObjectByName(string name) //fungsi mencari object yang tidak aktif menggunakan nama
    {
        Transform[] objs = Resources.FindObjectsOfTypeAll<Transform>() as Transform[];
        for (int i = 0; i < objs.Length; i++)
        {
            if (objs[i].hideFlags == HideFlags.None)
            {
                if (objs[i].name == name)
                {
                    return objs[i].gameObject;
                }
            }
        }
        return null;
    }
}
