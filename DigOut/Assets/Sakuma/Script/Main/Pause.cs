using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{

    [SerializeField]
    GameObject PauseObj;
    bool pauseBool = false;

    // Start is called before the first frame update
    void Start()
    {
        pauseBool = false;
        PauseObj.SetActive(false);
    }

    void bgm()
    {
        if (pauseBool == false)
        {
            SoundController.Instance.PlaySE(SoundController.SeName.Option_Open);
        }else if (pauseBool == true)
        {
            SoundController.Instance.PlaySE(SoundController.SeName.Option_Close);
        }
        else
        {
            return;
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        if (PS4ControllerInput.pS4ControllerInput.contorollerState.singleOptions)
        {
            if (pauseBool)
            {
                Debug.Log("オプション閉じる");
                bgm();
                pauseBool = false;
                PauseObj.SetActive(false);
                MainStateInstance.mainStateInstance.mainState.gameMode = MainStateInstance.GameMode.Play;

            }
            else
            {
                if (MainStateInstance.mainStateInstance.mainState.gameMode == MainStateInstance.GameMode.Play)
                {
                    Debug.Log("オプション開く");
                    bgm();
                    pauseBool = true;
                    PauseObj.SetActive(true);
                    MainStateInstance.mainStateInstance.mainState.gameMode = MainStateInstance.GameMode.Pause;
                }
            }
        }

    }
}
