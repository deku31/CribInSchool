using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillSetting : MonoBehaviour
{
    public GameObject[] objectDrag;
    public DraggableComponent[] dragComponent;
    //public GameObject dragScript_1;
    //public GameObject dragScript_2;
    //public GameObject dragScript_3;
    //public GameObject dragScript_4;
    //public GameObject dragScript_5;

    //public DraggableComponent dragScript_1;
    //public DraggableComponent dragScript_2;
    //public DraggableComponent dragScript_3;
    //public DraggableComponent dragScript_4;
    //public DraggableComponent dragScript_5;

    //public GameObject objectSprite1;
    //public GameObject objectSprite2;
    //public GameObject objectSprite3;
    //public GameObject objectSprite4;
    //public GameObject objectSprite5;

    public GameObject[] objectImage;
    public Image[] image;

    public GameObject[] objectSkillButton;
    public SkillButton[] skillButton;

    public GameObject[] objectSkillManager;
    public SkillManager[] skillManager;

    public void Start()
    {


        //dragScript_1 = FindInActiveObjectByName("Skill1").GetComponent<DraggableComponent>();
        //dragScript_2 = FindInActiveObjectByName("Skill2").GetComponent<DraggableComponent>();
        //dragScript_3 = FindInActiveObjectByName("Skill3").GetComponent<DraggableComponent>();
        //dragScript_4 = FindInActiveObjectByName("Skill4").GetComponent<DraggableComponent>();
        //dragScript_5 = FindInActiveObjectByName("Skill5").GetComponent<DraggableComponent>();

        //objectSprite1 = FindInActiveObjectByName("Sprite Skill 1").GetComponent<Image>();
        //objectSprite2 = FindInActiveObjectByName("Sprite Skill 2").GetComponent<Image>();
        //objectSprite3 = FindInActiveObjectByName("Sprite Skill 3").GetComponent<Image>();
        //objectSprite4 = FindInActiveObjectByName("Sprite Skill 4").GetComponent<Image>();
        //objectSprite5 = FindInActiveObjectByName("Sprite Skill 5").GetComponent<Image>();

        //skillManager_1 = FindInActiveObjectByName("Skill Manager 1").GetComponent<SkillManager>();
        //skillManager_2 = FindInActiveObjectByName("Skill Manager 2").GetComponent<SkillManager>();

        //objectSkillManager = GameObject.FindGameObjectsWithTag("SkillManager");
        //skillManager = new SkillManager[objectSkillManager.Length];
        //for (int i = 0; i < objectSkillManager.Length; i++)
        //{
        //skillManager[i] = objectSkillManager[i].GetComponent<SkillManager>();
        //}

        

    }

    public void Update()
    {
        objectDrag = GameObject.FindGameObjectsWithTag("Skill");
        dragComponent = new DraggableComponent[objectDrag.Length];
        for (int i = 0; i < objectDrag.Length; i++)
        {
            dragComponent[i] = objectDrag[i].GetComponent<DraggableComponent>();
        }

        objectImage = GameObject.FindGameObjectsWithTag("Sprite");
        image = new Image[objectImage.Length];
        for (int i = 0; i < objectImage.Length; i++)
        {
            image[i] = objectImage[i].GetComponent<Image>();
        }

        objectSkillButton = GameObject.FindGameObjectsWithTag("Sprite");
        skillButton = new SkillButton[objectSkillButton.Length];
        for (int i = 0; i < objectSkillButton.Length; i++)
        {
            skillButton[i] = objectSkillButton[i].GetComponent<SkillButton>();
        }

        dragComponent[1].enabled = false;
        dragComponent[0].enabled = false;

        if (dragComponent[0].enabled == false)
        {
            //skillButton[0].enabled = false;
            image[0].sprite = dragComponent[0].spriteChange;
            image[0].rectTransform.sizeDelta = new Vector2(189f, 177f);
        }

        if (dragComponent[1].enabled == false)
        {
            //skillButton[1].enabled = false;
            image[1].sprite = dragComponent[1].spriteChange;
            image[1].rectTransform.sizeDelta = new Vector2(189f, 177f);
        }

        //objectSprite1 = FindInActiveObjectByName("Sprite Skill 1");
        //objectSprite2 = FindInActiveObjectByName("Sprite Skill 2");
        //objectSprite3 = FindInActiveObjectByName("Sprite Skill 3");
        //objectSprite4 = FindInActiveObjectByName("Sprite Skill 4");
        //objectSprite5 = FindInActiveObjectByName("Sprite Skill 5");

        //dragScript_1 = FindInActiveObjectByName("Skill1");
        //dragScript_2 = FindInActiveObjectByName("Skill2");
        //dragScript_3 = FindInActiveObjectByName("Skill3");
        //dragScript_4 = FindInActiveObjectByName("Skill4");
        //dragScript_5 = FindInActiveObjectByName("Skill5");


        //dragScript_1.GetComponent<DraggableComponent>().enabled = false;
        //if (dragScript_1.GetComponent<DraggableComponent>().enabled == false)
        //{
        //objectSprite1.gameObject.GetComponent<Image>().sprite = spriteS1;
        //}

        //dragScript_2.GetComponent<DraggableComponent>().enabled = false;
        //if (dragScript_2.GetComponent<DraggableComponent>().enabled == false)
        //{
        //objectSprite2.gameObject.GetComponent<Image>().sprite = spriteS2;
        //}
        //dragScript_3.GetComponent<DraggableComponent>().enabled = false;
        //dragScript_4.GetComponent<DraggableComponent>().enabled = false;
        //dragScript_5.GetComponent<DraggableComponent>().enabled = false;




        //ChangeSprite();
        //dragScript_1.transform.position = loadSkill.spawnPointSkill_1;
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
}
