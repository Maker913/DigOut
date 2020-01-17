using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageCreate : MonoBehaviour
{

    //ステージの親を入れる

    //各設置物のプレハブ配置

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



    public Vector2 startPos;
    public Vector2 cameraPos;
    float dataz = -20;
    // Start is called before the first frame update
    void Start()
    {
        stageMake.fileName = MainStateInstance .mainStateInstance .   stageName;

        SaveDataLode();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SaveDataLode()
    {
        MainStateInstance.mainStateInstance.mainState.nowArea = 0;


        GameObject data2 = Instantiate(PlayerPre, Vector3.zero, Quaternion.identity);
        GameObject data = Instantiate(cameraPre, Vector3.zero, Quaternion.identity);
        camera.transform.parent = data.transform.GetChild(0);
        camera.transform.localPosition = new Vector3(0, 0, 10);
        data.transform.GetChild(0).GetComponent<CameraTest>().targetObj = data2.transform.GetChild(0).gameObject;
        camera.GetComponent<CameraSize>().player = data2;

        stageMake.cameraTestObj = data.transform.GetChild(0).gameObject;

            stageMake.StageLode();
        data2.transform.position = new Vector3(startPos.x, startPos.y + 0.5f, 0);
        data.transform.position = new Vector3(cameraPos.x, cameraPos.y, dataz);


    }



}
