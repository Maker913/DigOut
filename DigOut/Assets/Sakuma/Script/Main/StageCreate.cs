using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageCreate : MonoBehaviour
{

    //ステージの親を入れる
    [SerializeField]
    private GameObject stageParent;
    [SerializeField]
    private GameObject cameraParent;
    //各設置物のプレハブ配置
    [SerializeField]
    private string workFileName;
    [SerializeField]
    StageObjNumList stageObjNumList;
    [SerializeField]
    int LodeNum = 1;
    [SerializeField]
    GameObject PlayerPre;
    [SerializeField]
    GameObject cameraPre;
    [SerializeField]
    GameObject camera;

    [SerializeField]
    StageMakeController stageMake;



    float dataz = -20;
    // Start is called before the first frame update
    void Start()
    {
        stageMake.fileName = "test1";
        
        SaveDataLode();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SaveDataLode()
    {
        var scenarioText = Resources.Load<TextAsset>("SaveData/"+LodeNum .ToString ());
        if (scenarioText == null)
        {
            Debug.LogError("シナリオファイルが見つかりません。");
            return;
        }

        string text = scenarioText.text;
        Resources.UnloadAsset(scenarioText);

        string[] m_scenarios = text.Split(new string[] { "\n" }, System.StringSplitOptions.None);

        //Debug.Log(m_scenarios[0]);
        string[] pass = m_scenarios[0].Split(new string[] { "," }, System.StringSplitOptions.None);
        GameObject data2 = Instantiate(PlayerPre, new Vector3(int.Parse(pass[0]), int.Parse(pass[1])+0.5f, 0), Quaternion.identity);
        pass = m_scenarios[1].Split(new string[] { "," }, System.StringSplitOptions.None);
        GameObject data= Instantiate(cameraPre, new Vector3(int.Parse(pass[0]), int.Parse(pass[1]) + 0.5f, dataz), Quaternion.identity);
        camera.transform.parent= data.transform.GetChild(0);
        camera.transform.localPosition =new Vector3 (0,0, 10);
        data.transform .GetChild (0). GetComponent<CameraTest>().targetObj=data2.transform.GetChild (0).gameObject;
        camera.GetComponent<CameraSize>().cameraTest = data.transform.GetChild(0).GetComponent<CameraTest>();

        stageMake.cameraTestObj = data.transform.GetChild (0).gameObject ;

        stageMake.StageLode();
    }



}
