using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class loadingscane : MonoBehaviour
{
    public Image loadingFill;
    // Start is called before the first frame update
    void Start()
    {
        loadingFill.fillAmount = 0;
        StartCoroutine(Loading());
    }
    IEnumerator Loading()
    {
        AsyncOperation loading = SceneManager.LoadSceneAsync("Level 1");
        while (!loading.isDone)
        {
            loadingFill.fillAmount = loading.progress/0.9f;
            yield return null;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
