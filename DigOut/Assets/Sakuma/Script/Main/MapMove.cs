using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMove : MonoBehaviour
{
    public 
    RectTransform rect;

    [SerializeField]
    Vector3 stagePos;
    [SerializeField]
    Vector3 mapPos;
    [SerializeField]
    Vector3 mapPos2;
    [SerializeField]
    Vector3 late=Vector3.zero;


    [SerializeField]
    PixAccess pixAccess;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = stagePos - (Vector3)MainStateInstance.mainStateInstance.PlayerMove;


        Vector3 wa = new Vector3(pos.x * late.x, pos.y * late.y, pos.z * late.z) + mapPos;
        rect.localPosition =wa;
        Vector3 wa2 = new Vector3(pos.x * late.x, pos.y * late.y, pos.z * late.z) + mapPos2;
        wa2 *= 1/260f;
        wa2.x *= -1;
        pixAccess.Draw(wa2 * 256);
        //ダンジョン潜入
        SoundController.Instance.PlayBGM(SoundController.BgmName.Stage);
        Debug.Log(wa2);
    }


    void OnDrawGizmosSelected() {
        Gizmos.color = Color.green;
        Gizmos.DrawCube(stagePos,new Vector3 (1,1,1));
    }
}
