using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField]
    private GameObject stageList;
    [SerializeField]
    private GameObject[] preList;


    // Start is called before the first frame update
    void Start()
    {
        string text="";

        for(int i=0;i<stageList.transform.GetChildCount(); i++)
        {
            text += stageList.transform.GetChild(i).transform.tag+",";
            text += stageList.transform.GetChild(i).transform.position.x.ToString ()+",";
            text += stageList.transform.GetChild(i).transform.position.y.ToString() ;
            text += ";";
        }

        textSave(text);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void textSave(string txt)
    {
        StreamWriter sw = new StreamWriter("Assets/Resources/Scenarios/LogData.txt", false ); 
        sw.WriteLine(txt);
        sw.Flush();
        sw.Close();
    }

}
