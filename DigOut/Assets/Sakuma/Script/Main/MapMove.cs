using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMove : MonoBehaviour
{
    public 
    RectTransform rect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rect.localPosition += new Vector3(-MainStateInstance.mainStateInstance.PlayerMove.x * 8.01f, -MainStateInstance.mainStateInstance.PlayerMove.y*9.2f, 0);
    }
}
