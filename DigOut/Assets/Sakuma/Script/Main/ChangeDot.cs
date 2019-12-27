using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDot : MonoBehaviour
{
    [SerializeField]
    GameObject gameObject;
    [SerializeField]
    GameObject gameObject2;

    bool a=true;


    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Q))
        {
            a = !a;

            gameObject.SetActive(a);
            gameObject2.SetActive(!a);




        }






    }
}
