using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class lodeTest : MonoBehaviour
{
    public string text;
    //Text内容表記
    public string[] m_scenarios;
    //各設置物のプレハブ配置
    public GameObject[] preList;
    //ステージの親を入れる
    [SerializeField]
    private GameObject p;
    // Start is called before the first frame update
    void Start()
    {
        //Text読み込み
        ReadText("LogData");
        //Scenariosに;で区切って表示
        m_scenarios=text.Split(new string[] { ";" }, System.StringSplitOptions.None);
        for (int i = 0; i < m_scenarios.Length -1; i++)
        {
            //passに,で区切った数値を入れる
            string[] pass= m_scenarios[i].Split(new string[] { "," }, System.StringSplitOptions.None);
            //tagを参照し、preList内部のプレハブを各座標に配置
            Instantiate(preList[int.Parse(pass[0])],new Vector3 (float.Parse(pass[1]), float.Parse(pass[2]),0),Quaternion.identity ,p.transform );
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ReadText(string fileName)
    {
        var scenarioText = Resources.Load<TextAsset>("Scenarios/" + fileName);
        if (scenarioText == null)
        {
            Debug.LogError("シナリオファイルが見つかりません。");
            return;
        }

        text = scenarioText.text;//.Split(new string[] { "\n" }, System.StringSplitOptions.None);
        Resources.UnloadAsset(scenarioText);
    }

}
