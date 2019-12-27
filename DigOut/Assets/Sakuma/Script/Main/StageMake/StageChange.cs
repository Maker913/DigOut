using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageChange : MonoBehaviour
{
    public LayerMask mask;
    //[SerializeField]
    //GameObject target;
    [SerializeField]
    public Vector3 target;

    private CameraTest cameraTest;
    public GameObject cameraTestObj;

    public int changeArea;
    public int thisArea;
    private void Start() {
        cameraTest = cameraTestObj.GetComponent<CameraTest >();
    }

    private void OnTriggerEnter2D(Collider2D collision) 
        {
        
        
        if (collision.gameObject.layer == 12&&thisArea == MainStateInstance.mainStateInstance.mainState.nowArea) {
            
            cameraTest.stepMove = true;
            cameraTestObj.transform.parent.GetChild(1).transform.position = new Vector3(transform.position.x + target.x, transform.position.y + target.y, -20);
            MainStateInstance.mainStateInstance.mainState.nowArea = changeArea;
            //Debug.Log(MainStateInstance.mainStateInstance.mainState.nowArea);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(this.transform.position + target ,0.5f);
    }


}
