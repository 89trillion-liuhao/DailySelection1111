using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class FloatGold : MonoBehaviour
{
    //GameObject
    int buyCount ;
    GameObject allCanvas ;
    // Start is called before the first frame update
    void Start()
    {
        buyCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //点击事件

    public void OnClick()
    {
        buyCount++;
        int loop = buyCount * 5;
        if ( loop >= 15) loop = 15;
        for (int i = 0 ; i < loop ;i++)
        {
            //createFloat();
            Invoke("createFloat", 0.1f);
        }
        
        //StartCoroutine(createFloat());
    }

    void createFloat()
    {
       
        allCanvas = GameObject.Find("AllCanvas");
        Transform transform = allCanvas.transform.Find("Canvas");
        // GameObject gm = transform.gameObject;
        // Animator goldAn = gm.GetComponent<Animator>();
        // goldAn.Play(1);
        // System.Threading.Thread.Sleep(300);
        //StartCoroutine(waiting());
        GameObject goldFloat = Instantiate(Resources.Load("GoldFloat")) as GameObject;
       
        goldFloat.GetComponent<Transform>().SetParent(transform);
        Animator animator = goldFloat.GetComponent<Animator>();
    }

    public void destroy()
    {
        Destroy(gameObject);
    }
}
