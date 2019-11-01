using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class StageSave : MonoBehaviour
{
    public string text;

    public string[] m_scenarios;
    //ステージの親
    [SerializeField]
    GameObject Stage;
    //各設置物プレハブの配置
    [SerializeField]
    GameObject[] Prelist;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SaveStage();
        }
        if(Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            LoadStage();
        }
        if(Input.GetKeyDown(KeyCode.RightShift))
        {
            StageDestroy();
        }
    }

    public void SaveStage()
    {
        string text = "";
        //StageListの子のtagと座標の取得と書き出し
        for (int i = 0; i < Stage.transform.childCount; i++)
        {
            //tagを出力
            text += Stage.transform.GetChild(i).transform.tag + ",";
            //x座標を出力
            text += Stage.transform.GetChild(i).transform.position.x.ToString() + ",";
            //y座標を出力
            text += Stage.transform.GetChild(i).transform.position.y.ToString();
            text += "\r\n";
        }

        SaveText(text);
        
    }

    public void LoadStage()
    {
        //Text読み込み
        LeadText("LogData");
        //Scenariosに区切って表示

        for (int i = 0; i < m_scenarios.Length - 1; i++)
        {
            //passに,で区切った数値を入れる
            string[] pass = m_scenarios[i].Split(new string[] { "," }, System.StringSplitOptions.None);
            //tagを参照し、preList内部のプレハブを各座標に配置
            Instantiate(Prelist[int.Parse(pass[0])], new Vector3(float.Parse(pass[1]), float.Parse(pass[2]), 0), Quaternion.identity, Stage.transform);
        }
    }

    public void SaveText(string txt)
    {
        //txtファイルの位置と書き出し設定
        StreamWriter sw = new StreamWriter("Assets/Resources/Scenarios/LogData.txt", false); //true = 追記  false or 無し　= 上書き
        //改行して保存
        sw.WriteLine(txt);
        //バッファを強制的に書き出す
        sw.Flush();
        //開放
        sw.Close();

        //仮設置
        LeadText("LogData");
        Debug.Log("完了");
    }
    public void LeadText(string fileName)
    {
        //Resourcesフォルダの指定ファイルを参照
        var scenarioText = Resources.Load<TextAsset>("Scenarios/" + fileName);
        //見つからなかった場合
        if (scenarioText == null)
        {
            Debug.LogError("シナリオファイルが見つかりません。");
            return;
        }

        m_scenarios = text.Split(new string[] { "\r\n" }, System.StringSplitOptions.None);
        text = scenarioText.text;//.Split(new string[] { "\n" }, System.StringSplitOptions.None);
        Resources.UnloadAsset(scenarioText);
    }

    public void StageDestroy()
    {
        //Stageの子をすべて取得
        foreach (Transform n in Stage.transform)
        {
            //子をすべて削除
            Destroy(n.gameObject);
        }
    }
}
