
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

public class SaveLoadFile : MonoBehaviour
{
    //保存名
    public string fileName="a";
    //　入力フィールド
    public InputField inputField;
    //　ファイルストリーム
    private FileStream fileStream;
    //　バイナリフォーマッター
    private BinaryFormatter bf;

    public void Save()
    {
        bf = new BinaryFormatter();
        fileStream = null;

        try
        {
            //　ゲームフォルダにfiledata.datファイルを作成
            fileStream = File.Create(Application.dataPath + "/StageData/"+fileName+".dat");
            //　クラスの作成
            Data data = new Data();
            data.name = "おれや";
            //　入力フィールドのテキストをクラスのデータに保存
            data.dataText = inputField.text;
            //　ファイルにクラスを保存
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

    public void Load()
    {
        bf = new BinaryFormatter();
        fileStream = null;

        try
        {
            //　ファイルを読み込む
            fileStream = File.Open(Application.dataPath + "/StageData/" + fileName + ".dat", FileMode.Open);
            //　読み込んだデータをデシリアライズ
            Data data = bf.Deserialize(fileStream) as Data;
            inputField.text = data.dataText;
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

    }

    //　保存するデータクラス
    [Serializable]
    class Data
    {
        public string dataText;
        public string name;
        public string stageData;
        public string cameraData;
    }
}

