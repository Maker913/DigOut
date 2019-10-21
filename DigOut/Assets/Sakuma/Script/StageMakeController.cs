using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class StageMakeController : MonoBehaviour
{

    //ステージの親を入れる
    [SerializeField]
    private GameObject stageParent;
    //各設置物のプレハブ配置
    [SerializeField]
    private string workFileName;
    [SerializeField]
    StageObjNumList stageObjNumList;

    public string BrockData;
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
        string text = "";
        //オブジェ座標以外の情報書き出し
        //text += "わあああああああああああ";



        //text += "\n[BrockData]\n";

        //StageListの子のtagと座標の取得と書き出し
        for (int i = 0; i < stageParent.transform.GetChildCount(); i++)
        {
            text += stageParent.transform.GetChild(i).transform.tag + ",";
            text += stageParent.transform.GetChild(i).transform.position.x.ToString() + ",";
            text += stageParent.transform.GetChild(i).transform.position.y.ToString();
            if (i!=stageParent.transform.GetChildCount() - 1)
            {
                text += "\n";
            }
            
        }
        //txtファイルの位置と書き出し設定
        StreamWriter sw = new StreamWriter("Assets/Resources/Scenarios/"+ workFileName + ".txt", false); //true = 追記  false or 無し　= 上書き
        sw.WriteLine(text);
        sw.Flush();
        sw.Close();

        Debug.Log(workFileName+"にセーブしたで(*^^)v");
    }

    public void StageLode()
    {
        foreach (Transform child in stageParent.transform)
        {
            Destroy(child.gameObject);
        }

        var scenarioText = Resources.Load<TextAsset>("Scenarios/" + workFileName);
        if (scenarioText == null)
        {
            Debug.LogError("シナリオファイルが見つかりません。");
            return;
        }

        string text = scenarioText.text;
        Resources.UnloadAsset(scenarioText);

        //BrockData= text.Split(new string[] { "\n[BrockData]\n" }, System.StringSplitOptions.None)[1];

        //Scenariosに;で区切って表示
        string[] m_scenarios = text.Split(new string[] { "\n" }, System.StringSplitOptions.None);
        for (int i = 0; i < m_scenarios.Length - 1; i++)
        {
            //passに,で区切った数値を入れる
            string[] pass = m_scenarios[i].Split(new string[] { "," }, System.StringSplitOptions.None);
            //tagを参照し、preList内部のプレハブを各座標に配置
            Instantiate(stageObjNumList.PreList[int.Parse(pass[0])], new Vector3(float.Parse(pass[1]), float.Parse(pass[2]), 0), Quaternion.identity, stageParent.transform);
        }
        Debug.Log(workFileName + "をロードしたで(*^-^*)");
    }


}
