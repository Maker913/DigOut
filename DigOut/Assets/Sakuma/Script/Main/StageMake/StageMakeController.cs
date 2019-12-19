using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System;
//using UnityEngine.SceneManagement;
public class StageMakeController : MonoBehaviour
{

    //ステージの親を入れる
    //[SerializeField]
    //private GameObject stageParent;
    //[SerializeField]
    //private GameObject cameraParent;
    [SerializeField]
    private GameObject cursor;
        [SerializeField ]
    private GameObject stageMother;


    //各設置物のプレハブ配置
    //[SerializeField]
    //private string workFileName;
    [SerializeField]
    StageObjNumList stageObjNumList;


    //保存名
    public string fileName = "a";
    //　ファイルストリーム
    private FileStream fileStream;
    //　バイナリフォーマッター
    private BinaryFormatter bf;

    
    public GameObject cameraTestObj;
    [SerializeField]
    private bool MainAction;

    [SerializeField]
    StageCreate stageCreate;
    [SerializeField]
    GoHomeSelect goHome;
    [SerializeField]
    stageSelect  stage;

    [SerializeField]
    GameObject startPos;
    [SerializeField]
    GameObject cameraPos;
    [SerializeField]
    int nowArea;


    void Start()
    {
    }

    void Update()
    {
        nowArea = MainStateInstance.mainStateInstance.mainState.nowArea;
    }




    public void StageSave()
    {
        //オブジェ座標以外の情報書き出し

        Data data = new Data();

        data.Set(stageMother.transform.childCount);
        
        data.name = fileName;

        for (int j = 0; j < stageMother.transform.childCount; j++)
        {

            GameObject areaParent = stageMother.transform.GetChild(j).gameObject;
            GameObject stageParent = areaParent.transform.GetChild(0).gameObject;
            GameObject cameraParent = areaParent.transform.GetChild(1).gameObject;

            string text = "";
            //StageListの子のtagと座標の取得と書き出し
            for (int i = 0; i < stageParent.transform.childCount; i++)
            {
                text += stageParent.transform.GetChild(i).transform.tag + ",";
                text += stageParent.transform.GetChild(i).transform.position.x.ToString() + ",";
                text += stageParent.transform.GetChild(i).transform.position.y.ToString() + ",";
                text += (stageParent.transform.GetChild(i).transform.localEulerAngles.z).ToString() + ",";
                text += stageParent.transform.GetChild(i).transform.localScale.x.ToString() + ",";
                text += stageParent.transform.GetChild(i).transform.localScale.y.ToString();

                switch (int.Parse(stageParent.transform.GetChild(i).transform.tag))
                {
                    case 2:
                        GameObject dat2 = stageParent.transform.GetChild(i).gameObject;
                        Vector3 dat = dat2.GetComponent<StageChange>().target;
                        text += "," + dat.x.ToString() + ",";
                        text += stageParent.transform.GetChild(i).GetComponent<StageChange>().target.y.ToString() + ",";
                        text += dat2.GetComponent<StageChange  >().changeArea.ToString() + ",";
                        text += dat2.GetComponent<StageChange>().thisArea.ToString();
                        break;
                }


                //Debug.Log(stageParent.transform.GetChild(i).transform.localRotation.z.ToString());
                if (i != stageParent.transform.childCount - 1)
                {
                    text += "\n";
                }

            }

            data.areaDatas[j].stageData = text;
            // text += "\n[Next]\n";

            text = "";
            //カメラ用のオブジェの書き出し
            for (int i = 0; i < cameraParent.transform.childCount; i++)
            {
                text += cameraParent.transform.GetChild(i).transform.tag + ",";
                text += cameraParent.transform.GetChild(i).transform.position.x.ToString() + ",";
                text += cameraParent.transform.GetChild(i).transform.position.y.ToString() + ",";
                text += (cameraParent.transform.GetChild(i).transform.localEulerAngles.z).ToString() + ",";
                text += cameraParent.transform.GetChild(i).transform.localScale.x.ToString() + ",";
                text += cameraParent.transform.GetChild(i).transform.localScale.y.ToString();






                //Debug.Log(stageParent.transform.GetChild(i).transform.localRotation.z.ToString());
                if (i != cameraParent.transform.childCount - 1)
                {
                    text += "\n";
                }

            }
            data.areaDatas[j].cameraData = text;

            //txtファイルの位置と書き出し設定
            //StreamWriter sw = new StreamWriter("Assets/Resources/Scenarios/"+ workFileName + ".txt", false); //true = 追記  false or 無し　= 上書き
            //sw.WriteLine(text);
            //sw.Flush();
            //sw.Close();

        }

        data.startPosx = startPos.transform.position.x;
        data.startPosy = startPos.transform.position.y;
        data.cameraPosx = cameraPos.transform.position.x;
        data.cameraPosy = cameraPos.transform.position.y;
        
        Save(data);
        Debug.Log(fileName + "にセーブしたで(*^^)v");
    }


    //public GameObject lockobj;

    public void StageLode()
    {
        foreach (Transform child in stageMother.transform)
        {
            Destroy(child.gameObject);
        }



        Data data = Load();


        try
        {
            stageCreate.startPos = new Vector2(data.startPosx, data.startPosy);
            stageCreate.cameraPos = new Vector2(data.cameraPosx, data.cameraPosy);
        }
        catch
        {
            Debug.Log("きゃっちゃー");
        }


        //Debug.Log(data.startPosx+":"+ data.startPosy);
        //Debug.Log(stageMother.transform.childCount);

        int delayLeng = stageMother.transform.childCount;


        for (int i = 0; i < data.areaLeng; i++)
        {

            GameObject area = new GameObject();
            area.name = i.ToString();
            area.transform.parent = stageMother.transform;
            //GameObject areaPl = Instantiate(area, Vector3.zero, Quaternion.identity, stageMother.transform);

            GameObject area2 = new GameObject();
            area2.name = "StageData";
            area2.transform.parent = area.transform;
            //Instantiate(area, Vector3.zero, Quaternion.identity, areaPl.transform);

            area2 = new GameObject();
            area2.name = "CameraData";
            area2.transform.parent = area.transform;
        }


        



        //areaLeng = stageMother.transform.childCount;
        for (int j = 0; j < data.areaLeng; j++)
        {

            GameObject areaParent = stageMother.transform.GetChild(j+ delayLeng).gameObject;
            GameObject stageParent = areaParent.transform.GetChild(0).gameObject;
            GameObject cameraParent = areaParent.transform.GetChild(1).gameObject;


            string text = data.areaDatas[j].stageData;

            //Debug.Log(text);

            //Scenariosに;で区切って表示
            string[] m_scenarios = text.Split(new string[] { "\n" }, System.StringSplitOptions.None);

            for (int i = 0; i < m_scenarios.Length; i++)
            {
                //Debug.Log(m_scenarios[i]);
                //passに,で区切った数値を入れる
                string[] pass = m_scenarios[i].Split(new string[] { "," }, System.StringSplitOptions.None);
                //tagを参照し、preList内部のプレハブを各座標に配置
                GameObject brockdata = Instantiate(stageObjNumList.PreList[int.Parse(pass[0])], new Vector3(float.Parse(pass[1]), float.Parse(pass[2]), 0), Quaternion.Euler(0, 0, float.Parse(pass[3])), stageParent.transform);
                brockdata.transform.localScale = new Vector3(float.Parse(pass[4]), float.Parse(pass[5]), 1);


                switch (int.Parse(pass[0]))
                {
                    case 2:
                        brockdata.GetComponent<StageChange>().cameraTestObj = cameraTestObj;
                        brockdata.GetComponent<StageChange>().target = new Vector3(float.Parse(pass[6]), float.Parse(pass[7]), 0);
                        brockdata.transform.Translate(new Vector3(0, 0, -20));
                        brockdata.GetComponent<StageChange>().changeArea = int.Parse(pass[8]);
                        brockdata.GetComponent<StageChange>().thisArea = int.Parse(pass[9]);
                        break;
                    case 1:
                        brockdata.GetComponent<SceneLoad >().stageSelect  =stage ;
                        brockdata.transform.Translate(new Vector3(0, 0, -20));
                        break;
                    case 3:
                        brockdata.GetComponent<GoHomeSelectSet>().goHome = goHome;
                        break;

                }




            }


            //Debug.Log("a");
            text = data.areaDatas[j].cameraData;

            //Scenariosに;で区切って表示
            m_scenarios = text.Split(new string[] { "\n" }, System.StringSplitOptions.None);
            if (m_scenarios[0] == "") { return; }
            for (int i = 0; i < m_scenarios.Length; i++)
            {
                //Debug.Log(m_scenarios[i]);
                //passに,で区切った数値を入れる
                string[] pass = m_scenarios[i].Split(new string[] { "," }, System.StringSplitOptions.None);
                //tagを参照し、preList内部のプレハブを各座標に配置
                GameObject brockdata = Instantiate(stageObjNumList.CameraPreList[int.Parse(pass[0])], new Vector3(float.Parse(pass[1]), float.Parse(pass[2]), MainAction ?-20:- 1), Quaternion.Euler(0, 0, float.Parse(pass[3])), cameraParent.transform);

                brockdata.transform.localScale = new Vector3(float.Parse(pass[4]), float.Parse(pass[5]), 1);
            }
        }

        


        
        Debug.Log(fileName + "をロードしたで(*^-^*)");


        
    }






    public void Save(Data data)
    {
        bf = new BinaryFormatter();
        fileStream = null;

        try
        {
            //　ゲームフォルダにfiledata.datファイルを作成
            fileStream = File.Create(Application.dataPath + "/StreamingAssets/StageData/" + fileName + ".dat");
            bf.Serialize(fileStream, data);
        }
        catch (IOException e1)
        {
            Debug.Log("ファイルオープンエラー");
        }
        finally
        {
            if (fileStream != null)
            {
                fileStream.Close();
            }
        }
    }

    public Data Load()
    {
        if(fileName == "街に戻る")
        {
            MainStateInstance.mainStateInstance.Life = 6;
        }

        bf = new BinaryFormatter();
        fileStream = null;
        Data data = new Data() ;
        try
        {
            //　ファイルを読み込む
            fileStream = File.Open(Application.dataPath + "/StreamingAssets/StageData/" + fileName + ".dat", FileMode.Open);
            data = bf.Deserialize(fileStream) as Data;
        }
        catch (FileNotFoundException e1)
        {
            Debug.Log("ファイルがありません");
        }
        catch (IOException e2)
        {
            Debug.Log("ファイルオープンエラー");
        }
        finally
        {
            if (fileStream != null)
            {
                fileStream.Close();
            }
        }
        return data;
    }

    //　保存するデータクラス
    [Serializable]
    public class Data
    {
        public string dataText;
        public string name;
        public int areaLeng;
        public float startPosx;
        public float startPosy;
        public float cameraPosx;
        public float cameraPosy;
        [Serializable]
        public struct AreaData
        {
            public string stageData;
            public string cameraData;
            public int[] loadArea;
        }

        public AreaData[] areaDatas; 
        public void Set(int num)
        {
            areaLeng = num;
            areaDatas = new AreaData[num];
            for(int i=0;i< num; i++)
            {
                areaDatas[i].loadArea = new int[4];
            }
            
        }


    }



}
