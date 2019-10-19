using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class SaveTest : MonoBehaviour
{
    //ステージの親を入れる
    [SerializeField]
    private GameObject stageList;
    //各設置物のプレハブ配置
    [SerializeField]
    private GameObject[] preList;


    // Start is called before the first frame update
    void Start()
    {
        string text="";
        //StageListの子のtagと座標の取得と書き出し
        for(int i=0;i<stageList.transform.GetChildCount(); i++)
        {
            text += stageList.transform.GetChild(i).transform.tag+",";
            text += stageList.transform.GetChild(i).transform.position.x.ToString()+",";
            text += stageList.transform.GetChild(i).transform.position.y.ToString();
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
        //txtファイルの位置と書き出し設定
        StreamWriter sw = new StreamWriter("Assets/Resources/Scenarios/LogData.txt", false ); //true = 追記  false or 無し　= 上書き
        //改行して保存
        sw.WriteLine(txt);
        //バッファを強制的に書き出す
        sw.Flush();
        //開放
        sw.Close();
    }

}
