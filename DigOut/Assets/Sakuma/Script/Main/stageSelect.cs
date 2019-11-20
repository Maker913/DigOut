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

    string[] stagelist;


    public bool windowOn;
    [SerializeField]
    int nowpas = 0;
    [SerializeField]
    RectTransform rectTransform;
    Vector3 homePos;
    // Start is called before the first frame update
    void Start()
    {
        ListOn();
        windowOn = false;
        gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {

        if (windowOn)
        {

            rectTransform.localPosition = homePos + new Vector3(0,-50*nowpas ,0);
            if (Input.GetKeyDown(KeyCode.UpArrow )&&nowpas>0)
            {
                nowpas--;
            }
            if (Input.GetKeyDown(KeyCode.DownArrow ) && nowpas < stagelist.Length-1)
            {
                nowpas++;
            }

            if (Input.GetKeyDown(KeyCode.Z))
            {


                    MainStateInstance.mainStateInstance.stageName = stagelist[nowpas];
                    Scene.sceneManagerPr.SceneLoad("MainAction");


                Off();

            }




        }
    }


    void ListOn()
    {
        listOn = true;
        textParent.SetActive(true);
        DirectoryInfo dir = new DirectoryInfo(Application.dataPath + "/StreamingAssets/StageData");
        FileInfo[] info = dir.GetFiles("*.dat");
        int i = 0;
        stagelist =new string [info.Length ]; 
        foreach (FileInfo f in info)
        {

            //Debug.Log(f.Name);

            GameObject test= Instantiate(textobj, textParent.transform );
            test.transform.Translate(0, i*-50, 0);
            test.GetComponent<Text>().text = f.Name.Split(new string[] { ".dat" }, System.StringSplitOptions.None)[0];
            if (i == 0)
            {
                rectTransform.localPosition = test.GetComponent<RectTransform>().localPosition;
                homePos = rectTransform.localPosition;
            }
            stagelist[i] = f.Name.Split(new string[] { ".dat" }, System.StringSplitOptions.None)[0];


            i++;
        }


        
        //Debug.Log(stagelist . Length );



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



    public void On()
    {
        windowOn = true;
        gameObject.SetActive(true);
        MainStateInstance.mainStateInstance.mainState.gameMode = MainStateInstance.GameMode.Pause;
    }


    public void Off()
    {
        windowOn = false;
        gameObject.SetActive(false);
        MainStateInstance.mainStateInstance.mainState.gameMode = MainStateInstance.GameMode.Play;
    }



}
