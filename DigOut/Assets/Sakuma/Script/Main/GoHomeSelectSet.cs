using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoHomeSelectSet : MonoBehaviour
{

    public GoHomeSelect goHome;

    [SerializeField]
    Material material;
    bool text;
    float a = 0;
    bool sw = false;

    private void Start()
    {
        Mainc.animeC = false;
    }

    private void Update()
    {
        if(text)
        {
            if (a < 1)
            {
                a += Time.deltaTime * 4;
            }
            else
            {
                a = 1;
            }
        }
        else
        {
            if (a > 0)
            {
                a -= Time.deltaTime * 4;
            }
            else
            {
                a = 0;
            }
        }
        material.SetColor("_Color", new Color(1, 1, 1, a));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 12 && !Mainc.animeC && MainStateInstance.mainStateInstance.stageName == "洞窟へ1")
        {
            //goHome.On();
            text = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 12 && MainStateInstance.mainStateInstance.stageName == "洞窟へ1")
        {
            text = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 12 && MainStateInstance.mainStateInstance.stageName == "洞窟へ1")
        {
            if (PS4ControllerInput.pS4ControllerInput.contorollerState.Circle && !sw)
            {
                sw = true;
                goHome.On();
            }
        }
    }

}
