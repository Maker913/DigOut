﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerectPre : MonoBehaviour
{
    [SerializeField]
    private StageObjNumList stageObjNumList;
    public int serectPreNum = 0;
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0;i<stageObjNumList.PreList.Length; i++)
        {
<<<<<<< HEAD
            Instantiate(stageObjNumList.PreList[i],transform );
=======
            Instantiate(stageObjNumList.PreList[i],transform.GetChild (0) );
        }
        for (int i = 0; i < stageObjNumList.CameraPreList.Length; i++)
        {
            Instantiate(stageObjNumList.CameraPreList[i], transform.GetChild(1));
>>>>>>> 40914c70ff315d902e41bf2ad71a470ea459c9cd
        }
        serect();
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
        if (Input.GetKeyDown(KeyCode.A)) { serectPreNum++; if (serectPreNum >= stageObjNumList.PreList.Length) { serectPreNum = 0; } }
        if (Input.GetKeyDown(KeyCode.S)) { serectPreNum--; if (serectPreNum < 0) { serectPreNum = stageObjNumList.PreList.Length - 1; } }
=======
        if (Input.GetKeyDown(KeyCode.A)) { serectPreNum++; if (serectPreNum >= (stageObjNumList .CameraPre ? stageObjNumList.CameraPreList.Length: stageObjNumList.PreList.Length)) { serectPreNum = 0; } }
        if (Input.GetKeyDown(KeyCode.S)) { serectPreNum--; if (serectPreNum < 0) { serectPreNum = (stageObjNumList.CameraPre ? stageObjNumList.CameraPreList.Length : stageObjNumList.PreList.Length) - 1; } }

        if (Input.GetKeyDown(KeyCode.D))
        {
            serectPreNum = 0;
            stageObjNumList.CameraPre= !stageObjNumList.CameraPre;
        }
>>>>>>> 40914c70ff315d902e41bf2ad71a470ea459c9cd

        serect();
    }

    void serect()
    {
<<<<<<< HEAD
        for (int i = 0; i < stageObjNumList.PreList.Length; i++)
        {
           transform.GetChild(i).gameObject.SetActive(i.Equals(serectPreNum));

=======
        int data = (stageObjNumList .CameraPre ?1:0);
        
        for (int i = 0; i < transform.childCount; i++)
        {
            for (int j = 0; j <transform.GetChild (i).childCount ; j++)
            {
                transform.GetChild(i).GetChild(j).gameObject.SetActive(j.Equals(serectPreNum)&&data==i);
            }
>>>>>>> 40914c70ff315d902e41bf2ad71a470ea459c9cd
        }
    }
}
