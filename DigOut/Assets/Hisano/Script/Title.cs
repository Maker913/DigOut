﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PS4ControllerInput.pS4ControllerInput.contorollerState.singleCircle)
        {
            Scene.sceneManagerPr.SceneLoad("MainAction");
        }

    }
}
