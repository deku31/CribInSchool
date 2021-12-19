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
    public Transform transformBatu;
    public GameObject plane;

    public Image darkMaskCooldown;
    public Image activedMaskSkill;

    public Text textCooldownActived; //text cooldown saat skill telah aktif
    public Text textCooldownSpawn; //text cooldown durasi skill

    public float timeDistractDefault = 10f;
    private float timeDistract;

    public float durasispawnDefault = 15;
    private float durasispawn;

    [SerializeField]
    private GameObject batu;

    public bool skillAktif;
    public bool distractSkill;

    private bool _distracted;
    public bool spawnObject = false;
    public GameObject spawnGameObject;

    public void Awake()
    {
        //agentGuru = GameObject.FindGameObjectWithTag("Guru(Clone)").GetComponent<NavMeshAgent>();
        gm = FindObjectOfType<Gamemanager>();
    }

    public void Start()
    {
        textCooldownActived.enabled = false;
        if (gm != null)
        {
            skillAktif = true;
            timeDistract = timeDistractDefault;
            durasispawn = durasispawnDefault;
            textCooldownActived.enabled = false;
        }
        //OnDistraction += ThrowCoin;
        OnDistraction += ThrowCoin;
        AktifSkill_2.OnDistraction += GetDistracted;
    }

    public void Update()
    {
        //AktifSkill_2.OnDistraction += GetDistracted;

        gm = FindObjectOfType<Gamemanager>();

        if (distractSkill == true)
        {
            //textCooldownSpawn.gameObject.SetActive(false);
            darkMaskCooldown.gameObject.SetActive(false);

            agentGuru = FindInActiveObjectByName("Guru(Clone)").GetComponent<NavMeshAgent>();

            if (timeDistract > 0.1f)
            {
                timeDistract -= Time.deltaTime;
                float roundedCd = Mathf.Round(timeDistract);
                //textCooldownActived.text = roundedCd.ToString();

                activedMaskSkill.gameObject.SetActive(true);
                activedMaskSkill.enabled = true;
                activedMaskSkill.fillAmount = (timeDistract / timeDistractDefault);

                if (Input.GetMouseButtonDown(0))
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    if (Physics.Raycast(ray, out RaycastHit hitInfo))
                    {
                        if (hitInfo.collider.tag == "Plane")
                        {
                            transformBatu = FindInActiveObjectByTag("Batu").GetComponent<Transform>();

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
                spawnGameObject = FindInActiveObjectByTag("Batu");
                Destroy(spawnGameObject, 20);
                //textCooldownActived.enabled = false;
                //textCooldownSpawn.gameObject.SetActive(true);

                activedMaskSkill.gameObject.SetActive(false);
                activedMaskSkill.rectTransform.sizeDelta = new Vector2(79f, 67f);

                darkMaskCooldown.gameObject.SetActive(true);
                darkMaskCooldown.rectTransform.sizeDelta = new Vector2(79f, 67f);
            }
        }

        if (skillAktif == false)
        {
            if (durasispawn > 0.1f)
            {
                durasispawn -= Time.deltaTime;

                //textCooldownSpawn.enabled = true;
                float roundedCd = Mathf.Round(durasispawn);
                //textCooldownSpawn.text = roundedCd.ToString();

                darkMaskCooldown.enabled = true;
                darkMaskCooldown.fillAmount = (durasispawn / durasispawnDefault);
            }
            else
            {
                skillAktif = true;
                darkMaskCooldown.enabled = false;
                durasispawn = durasispawnDefault;
                spawnObject = false;
                
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
                
                //textCooldownActived.enabled = true;
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

    public void ThrowCoin(Vector3 pos)
    {
        if(spawnObject == false)
        {
            Instantiate(batu, pos, Quaternion.identity);
            spawnObject = true;
            //return;
        }
        

        
    }

    public void OnDestroy()
    {
        AktifSkill_2.OnDistraction -= GetDistracted;
        OnDistraction -= ThrowCoin;
    }

    public void OnTriggerEnter(Collider other)
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

    public IEnumerator FollowDistraction(Vector3 pos)
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
