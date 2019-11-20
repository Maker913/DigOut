﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GoHomeSelect : MonoBehaviour
{

    public bool windowOn;
    bool yesNo;

    [SerializeField]
    RectTransform rectTransform;


    // Start is called before the first frame update
    void Start()
    {
        windowOn = false;
        gameObject.SetActive(false);
        yesNo = false;
    }

    // Update is called once per frame
    void Update()
    {
        


        if(windowOn)
        {

            rectTransform.localPosition  = new Vector3(yesNo?-100:100, -55,0);


            if(Input.GetKeyDown (KeyCode.LeftArrow )|| Input.GetKeyDown(KeyCode.RightArrow))
            {
                yesNo = !yesNo;
            }


            if(Input.GetKeyDown (KeyCode.Z))
            {


                if(yesNo)
                {

                    MainStateInstance.mainStateInstance.stageName = "towntest";
                    Scene.sceneManagerPr.SceneLoad("MainAction");

                }

                Off();

            }




        }



    }


    public void On()
    {
        windowOn = true;
        gameObject.SetActive(true);
        MainStateInstance.mainStateInstance.mainState.gameMode = MainStateInstance.GameMode.Pause;
    }


    public void Off()
    {
        windowOn = false ;
        gameObject.SetActive(false);
        MainStateInstance.mainStateInstance.mainState.gameMode = MainStateInstance.GameMode.Play;
    }


}
