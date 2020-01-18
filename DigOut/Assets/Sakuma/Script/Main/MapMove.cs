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
        
    }


    void OnDrawGizmosSelected() {
        Gizmos.color = Color.green;
        Gizmos.DrawCube(stagePos,new Vector3 (1,1,1));
    }
}
