using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class shopCan : MonoBehaviour
{
    static public bool shop=false;
    [SerializeField]
    GameObject can;
    [SerializeField]
    GameObject sUI;
    float ktime=0;
    [SerializeField]
    Image image;
    bool sw = false;
    // Start is called before the first frame update
    void Start()
    {
        can.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {



        if (shopCan.shop)
        {
            
            if (ktime > 0.5f)
            {
                can.SetActive(true);
            }
            else
            {
                image.color = new Color(0, 0, 0, ktime);
                ktime += Time.deltaTime;
            }


        }
        else
        {
            if (ktime < 0f)
            {
                if (sw)
                {
                    sw = false;
                    sUI.SetActive(true);
                    MainStateInstance.mainStateInstance.mainState.gameMode = MainStateInstance.GameMode.Play;
                }
                ktime = 0;
                
                image.color = new Color(0, 0, 0, 0);
            }
            else
            {
                image.color = new Color(0, 0, 0, ktime);
                ktime -= Time.deltaTime;
            }
        }
        if (shopCan.shop)
        {
            sUI.SetActive(false);
            if (PS4ControllerInput.pS4ControllerInput.contorollerState.Jump)
            {
                sw = true;
                
                shopCan.shop = false;
                can.SetActive(false);
                
            }
            
        }
    }
}
