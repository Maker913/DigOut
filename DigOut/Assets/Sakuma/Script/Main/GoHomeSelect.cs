using System.Collections;
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

            //rectTransform.localPosition  = new Vector3(yesNo?-100:100, -125, 0);


            //if(PS4ControllerInput.pS4ControllerInput.contorollerState.singleLeft|| PS4ControllerInput.pS4ControllerInput.contorollerState.singleRight)
            //{
            //    yesNo = !yesNo;
            //}


            //if(PS4ControllerInput.pS4ControllerInput.contorollerState.singleCircle)
            //{


                //if(yesNo)
                //{
                    Mainc.animeC = true;
                    MainStateInstance.mainStateInstance.stageName = "街に戻る";
                    Scene.sceneManagerPr.SceneLoad("MainAction");

                //}

                Off();

            //}




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
