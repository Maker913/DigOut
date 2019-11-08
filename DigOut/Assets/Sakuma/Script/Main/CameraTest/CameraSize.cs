using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSize : MonoBehaviour
{
    Camera camera;
    public CameraTest cameraTest;
    public float baseSize=7;
    public float baseSizelim = 8;
    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        //(i%3==0?Pos.x:(i % 3 == 1? Pos.y:Pos.z))
        camera.orthographicSize =(baseSize + cameraTest.dis * 4< baseSizelim? baseSize + cameraTest.dis*4: baseSizelim);
    }
}
