using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
public class stageSelect : MonoBehaviour
{
    [SerializeField]
    GameObject textobj;
    [SerializeField]
    GameObject textParent;

    bool listOn=false ;

    // Start is called before the first frame update
    void Start()
    {
        //ListOn();
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            if (listOn)
            {
                ListOff();
            }
            else
            {
                ListOn();
            }
        }
    }


    void ListOn()
    {
        listOn = true;
        textParent.SetActive(true);
        MainStateInstance.mainStateInstance.mainState.gameMode = MainStateInstance.GameMode.Pause;

        DirectoryInfo dir = new DirectoryInfo(Application.dataPath + "/StageData");
        FileInfo[] info = dir.GetFiles("*.dat");
        int i = 0;
        foreach (FileInfo f in info)
        {
            Debug.Log(f.Name);

            if(MainStateInstance .mainStateInstance .stageName != f.Name)
            {
                GameObject test= Instantiate(textobj, textParent.transform );
                test.transform.Translate(0, i*-50, 0);
                test.GetComponent<Text>().text = f.Name.Split(new string[] { ".dat" }, System.StringSplitOptions.None)[0];
            }

            

            i++;
        }
    }

    void ListOff()
    {
        listOn = false;
        textParent.SetActive(false);
        MainStateInstance.mainStateInstance.mainState.gameMode = MainStateInstance.GameMode.Play;

        foreach (Transform n in textParent.transform)
        {
            GameObject.Destroy(n.gameObject);
        }
    }
}
