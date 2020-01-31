using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : MonoBehaviour
{
    bool Press = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if (!Press && PS4ControllerInput.pS4ControllerInput.contorollerState.singleCircle)
        {
            Press = true;
            Scene.sceneManagerPr.SceneLoad("MainAction");
        }

    }
}
