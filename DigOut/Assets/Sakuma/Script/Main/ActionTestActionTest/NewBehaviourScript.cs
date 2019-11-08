using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    Controller2D controller2;
    // Start is called before the first frame update
    void Start()
    {
        controller2 = GetComponent<Controller2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKey (KeyCode.LeftArrow)) { controller2.Move(new Vector3(-1*Time.deltaTime, 0, 0)); }
    }
}
