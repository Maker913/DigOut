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
    [SerializeField]
    private GameObject stageParent;
    [SerializeField]
    private GameObject cameraParent;
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


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }




    public void StageSave()
    {
        //オブジェ座標以外の情報書き出し

        Data data = new Data();

        data.name = fileName;


        string text = "";
        //StageListの子のtagと座標の取得と書き出し
        for (int i = 0; i < stageParent.transform.childCount; i++)
        {
            text += stageParent.transform.GetChild(i).transform.tag + ",";
            text += stageParent.transform.GetChild(i).transform.position.x.ToString() + ",";
            text += stageParent.transform.GetChild(i).transform.position.y.ToString() + ",";
            text += (stageParent.transform.GetChild(i).transform.localEulerAngles .z).ToString() + ",";
            text += stageParent.transform.GetChild(i).transform.localScale.x.ToString() + ",";
            text += stageParent.transform.GetChild(i).transform.localScale.y.ToString();
            //Debug.Log(stageParent.transform.GetChild(i).transform.localRotation.z.ToString());
            if (i!=stageParent.transform.childCount - 1)
            {
                text += "\n";
            }
            
        }

        data.stageData = text;
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
        data.cameraData  = text;

        //txtファイルの位置と書き出し設定
        //StreamWriter sw = new StreamWriter("Assets/Resources/Scenarios/"+ workFileName + ".txt", false); //true = 追記  false or 無し　= 上書き
        //sw.WriteLine(text);
        //sw.Flush();
        //sw.Close();




        Save(data);
        Debug.Log(data.cameraData);
        Debug.Log(fileName + "にセーブしたで(*^^)v");
    }

    public void StageLode()
    {
        foreach (Transform child in stageParent.transform)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in cameraParent.transform)
        {
            Destroy(child.gameObject);
        }
        //var scenarioText = Resources.Load<TextAsset>("Scenarios/" + fileName);
        //if (scenarioText == null)
        //{
        //    Debug.LogError("シナリオファイルが見つかりません。");
        //    return;
        //}

        //string text = scenarioText.text;
        //Resources.UnloadAsset(scenarioText);




        //string[] BrockData = text.Split(new string[] { "\n[Next]\n" }, System.StringSplitOptions.None);
        //text = BrockData[1];
        Data data = Load();
        string text = data.stageData;



        //Scenariosに;で区切って表示
        string[] m_scenarios = text.Split(new string[] { "\n" }, System.StringSplitOptions.None);

        for (int i = 0; i < m_scenarios.Length ; i++)
        {
            Debug.Log(m_scenarios[i]);
            //passに,で区切った数値を入れる
            string[] pass = m_scenarios[i].Split(new string[] { "," }, System.StringSplitOptions.None);
            //tagを参照し、preList内部のプレハブを各座標に配置
            GameObject  brockdata = Instantiate(stageObjNumList.PreList[int.Parse(pass[0])], new Vector3(float.Parse(pass[1]), float.Parse(pass[2]), 0), Quaternion.Euler (0,0, float.Parse(pass[3])), stageParent.transform);
            brockdata.transform.localScale = new Vector3(float.Parse(pass[4]), float.Parse(pass[5]), 1);
        }

        
        Debug.Log("a");
        text = data.cameraData;
        
        //Scenariosに;で区切って表示
        m_scenarios = text.Split(new string[] { "\n" }, System.StringSplitOptions.None);
        if (m_scenarios[0] == "") { return; }
        for (int i = 0; i < m_scenarios.Length; i++)
        {
            Debug.Log(m_scenarios[i]);
            //passに,で区切った数値を入れる
            string[] pass = m_scenarios[i].Split(new string[] { "," }, System.StringSplitOptions.None);
            //tagを参照し、preList内部のプレハブを各座標に配置
            GameObject brockdata = Instantiate(stageObjNumList.CameraPreList[int.Parse(pass[0])], new Vector3(float.Parse(pass[1]), float.Parse(pass[2]), -15), Quaternion.Euler(0, 0, float.Parse(pass[3])), cameraParent.transform);

            brockdata.transform.localScale = new Vector3(float.Parse(pass[4]), float.Parse(pass[5]), 1);
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
            fileStream = File.Create(Application.dataPath + "/StageData/" + fileName + ".dat");
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
        bf = new BinaryFormatter();
        fileStream = null;
        Data data = new Data() ;
        try
        {
            //　ファイルを読み込む
            fileStream = File.Open(Application.dataPath + "/StageData/" + fileName + ".dat", FileMode.Open);
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
        public string stageData;
        public string cameraData;
    }



}
