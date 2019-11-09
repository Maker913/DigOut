using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageChange : MonoBehaviour
{
    public LayerMask mask;
    [SerializeField]
    GameObject target;
    private CameraTest cameraTest;
    public GameObject cameraTestObj;


    private void Start() {
        cameraTest = cameraTestObj.GetComponent<CameraTest >();
    }

    private void OnTriggerEnter2D(Collider2D collision) 
        {
        
        
        if (collision.gameObject.layer == 12) {
            Debug.Log("sas");
            cameraTest.stepMove = true;
            cameraTestObj.transform.parent.GetChild(1).transform.position = new Vector3(target.transform.position.x, target.transform.position.y, -20) ;
            


        }
    }




}
