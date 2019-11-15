using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSize : MonoBehaviour
{
    Camera camera;
    //public CameraTest cameraTest;
    public float baseSize=7;
    public float baseSizelim = 8;

    public GameObject player;






    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        
        float dis = Vector2.Distance(player.transform.position, transform.position);
        Debug.Log(dis);
        dis *= 0f;


        camera.orthographicSize =(dis > baseSizelim-baseSize? baseSizelim: baseSize + dis);
    }
}
