﻿using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColliderText : MonoBehaviour
{
    public GameObject uiText;
    public GameObject countText;
    public static int count;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider it)
    {
        GameObject organelle = it.gameObject;
        MeshRenderer text = organelle.GetComponentInChildren<MeshRenderer>();

        text.enabled = true;

        TextMeshProUGUI tmpgui = uiText.GetComponent<TextMeshProUGUI>();
        if(!tmpgui.text.Contains(organelle.name))
        {
            tmpgui.text = tmpgui.text + "\n" + organelle.name;
            count++;
            countText.GetComponent<TextMeshProUGUI>().text = count + "/10";
        }
            
        if(count == 10)
        {
            //SceneManager.LoadScene("End");
            StartCoroutine(LoadSceneTimer());
        }
    }

    IEnumerator LoadSceneTimer()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("End");
    }

    private void OnTriggerExit(Collider it)
    {
        GameObject organelle = it.gameObject;
        MeshRenderer text = organelle.GetComponentInChildren<MeshRenderer>();

        text.enabled = false;
    }
}
