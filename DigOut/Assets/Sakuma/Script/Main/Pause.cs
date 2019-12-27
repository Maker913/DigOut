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

    // Update is called once per frame
    void Update()
    {
        if (PS4ControllerInput.pS4ControllerInput.contorollerState.singleOptions)
        {
            if (pauseBool)
            {

                pauseBool = false;
                PauseObj.SetActive(false);
                MainStateInstance.mainStateInstance.mainState.gameMode = MainStateInstance.GameMode.Play;

            }
            else
            {
                if (MainStateInstance.mainStateInstance.mainState.gameMode == MainStateInstance.GameMode.Play)
                {
                    pauseBool = true;
                    PauseObj.SetActive(true);
                    MainStateInstance.mainStateInstance.mainState.gameMode = MainStateInstance.GameMode.Pause;
                }
            }
        }

    }
}
