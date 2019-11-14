using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Cursor : MonoBehaviour
{
    [SerializeField]
    private GameObject stageMother;


    [SerializeField]
    private StageObjNumList stageObjNumList;
    [SerializeField]
    private  SerectPre serectPre;
    //[SerializeField]
    //private GameObject stageParent;
    //[SerializeField]
    //private GameObject cameraParent;
    [SerializeField]
    private GameObject camera;

    [SerializeField]
    GameObject selectObj;

    [SerializeField]
    LayerMask StageMask;
    [SerializeField]
    LayerMask CameraMask;

    public InputField angleInput;
    public InputField scaleXInput;
    public InputField scaleYInput;

    public InputField changeXInput;
    public InputField changeYInput;

    public InputField areaInput;
    private int area;



    public float angle=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float scaleX;
        float scaleY;
        try
        {
            angle = (float)Convert.ToDouble(angleInput.text);
            scaleX = (float)Convert.ToDouble(scaleXInput.text);
            scaleY = (float)Convert.ToDouble(scaleYInput.text);
        }
        catch
        {
            Debug.Log("ちゃんと入力するっちゃ");
            return;
        }


        try
        {
            area=Convert.ToInt16(areaInput.text);
        }
        catch
        {
            Debug.Log("そんなエリアないで？");
            return;
        }
        if(area> stageMother.transform .childCount-1)
        {
            Debug.Log("そんなエリアないで？");
            return;
        }

        GameObject stageParent = stageMother.transform.GetChild(area).GetChild(0).gameObject;
        GameObject cameraParent = stageMother.transform.GetChild(area).GetChild(1).gameObject;



        selectObj.transform.localEulerAngles = new Vector3(0, 0, angle);

        if (Input.GetKeyDown (KeyCode.UpArrow)) { transform.Translate(new Vector3(0, 1, 0)); if (transform.position.y > camera.transform.position.y + 4) { camera.transform.Translate(new Vector3(0, 1, 0)); } }
        if (Input.GetKeyDown(KeyCode.DownArrow )) { transform.Translate(new Vector3(0, -1, 0)); if (transform.position.y < camera.transform.position.y - 4) { camera.transform.Translate(new Vector3(0, -1, 0)); } }
        if (Input.GetKeyDown(KeyCode.RightArrow )) { transform.Translate(new Vector3(1, 0, 0)); if (transform.position.x > camera.transform.position.x + 6) { camera.transform.Translate(new Vector3(1, 0, 0)); } }
        if (Input.GetKeyDown(KeyCode.LeftArrow)) { transform.Translate(new Vector3(-1, 0, 0)); if (transform.position.x < camera.transform.position.x - 6) { camera.transform.Translate(new Vector3(-1, 0, 0)); } }

        //if (Input.GetKeyDown(KeyCode.C)) { angle += 90;if (angle >= 360) { angle=0; }selectObj.transform.localEulerAngles = new Vector3 (0, 0, angle); }



        if (Input.GetKey(KeyCode.X))
        {

            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.forward,1,stageObjNumList . CameraPre ?CameraMask:StageMask);
            if (hit.collider)
            {
                Destroy(hit.collider.gameObject);
            }


        }
        if (Input.GetKey(KeyCode.Z))
        {

            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.forward,1, stageObjNumList.CameraPre ? CameraMask : StageMask);
            if (!hit.collider)
            {
                GameObject test= Instantiate(stageObjNumList.CameraPre ? stageObjNumList.CameraPreList[serectPre.serectPreNum] : stageObjNumList.PreList[serectPre.serectPreNum],
                    Vector3.zero,Quaternion .Euler (0,0,angle),
                    stageObjNumList.CameraPre ?cameraParent .transform : stageParent.transform );
                    test.transform.localScale = new Vector3(scaleX,scaleY ,1);
                test.transform.localPosition = new Vector3(transform.position.x + ((scaleX - 1) * 0.5f), transform.position.y + ((scaleY - 1) * 0.5f), (stageObjNumList.CameraPre ? -1 : 0));
                switch (serectPre.serectPreNum)
                {
                    case 29:
                        test.GetComponent<StageChange>().target = new Vector3((float)Convert.ToDouble(changeXInput.text), (float)Convert.ToDouble(changeYInput.text),0);
                        break;
                }
                
            }


        }

    }



    public void AddArea()
    {
        GameObject area = new GameObject();
        area.name = stageMother.transform.childCount.ToString();
        area.transform.parent =stageMother.transform ;
        //GameObject areaPl = Instantiate(area, Vector3.zero, Quaternion.identity, stageMother.transform);

        GameObject area2 = new GameObject();
        area2.name = "StageData";
        area2.transform.parent = area.transform;
        //Instantiate(area, Vector3.zero, Quaternion.identity, areaPl.transform);

        area2 = new GameObject();
        area2.name = "CameraData";
        area2.transform.parent = area.transform;
        //Instantiate(area, Vector3.zero, Quaternion.identity, areaPl.transform);
    }
}
