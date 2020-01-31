using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoHomeSelectSet : MonoBehaviour
{

    public GoHomeSelect goHome;


    private void Start()
    {
        Mainc.animeC = false;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.layer == 12 && !Mainc.animeC&&MainStateInstance.mainStateInstance.stageName =="洞窟へ1")
        {
            goHome.On();
            
        }
    }



}
