using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidMove : MonoBehaviour
{
    GameObject Quad;

    Player script;

    // Start is called before the first frame update
    void Start()
    {
        Quad = GameObject.Find("Quad");
        script = Quad.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MidJump()
    {
        
    }
}
