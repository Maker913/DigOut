using System.Collections;
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
            Instantiate(stageObjNumList.PreList[i],transform );
        }
        serect();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) { serectPreNum++; if (serectPreNum >= stageObjNumList.PreList.Length) { serectPreNum = 0; } }
        if (Input.GetKeyDown(KeyCode.S)) { serectPreNum--; if (serectPreNum < 0) { serectPreNum = stageObjNumList.PreList.Length - 1; } }

        serect();
    }

    void serect()
    {
        for (int i = 0; i < stageObjNumList.PreList.Length; i++)
        {
           transform.GetChild(i).gameObject.SetActive(i.Equals(serectPreNum));

        }
    }
}
