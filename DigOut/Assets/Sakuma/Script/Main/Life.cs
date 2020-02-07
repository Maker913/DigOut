using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    [SerializeField]
    Heart[] hearts;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (MainStateInstance.mainStateInstance.Life)
        {
            case 0:
                hearts[0].mode = 0;
                break;
            case 1:
                hearts[0].mode = 1;
                break;
            default:
                hearts[0].mode = 2;
                break;

        }

        if (MainStateInstance.mainStateInstance.Life <= 2)
        {
            hearts[1].mode = 0;
        }
        else if(MainStateInstance.mainStateInstance.Life >= 4)
        {
            hearts[1].mode = 2;
        }
        else
        {
            hearts[1].mode = 1;
        }

        if (MainStateInstance.mainStateInstance.Life <= 4)
        {
            hearts[2].mode = 0;
        }
        else if (MainStateInstance.mainStateInstance.Life >= 6)
        {
            hearts[2].mode = 2;
        }
        else
        {
            hearts[2].mode = 1;
        }

        if(MainStateInstance.mainStateInstance.maxLife > 6)
        {
            hearts[3].gameObject.SetActive(true);
            if (MainStateInstance.mainStateInstance.Life <= 6)
            {
                hearts[3].mode = 0;
            }else if(MainStateInstance.mainStateInstance.Life >= 8)
            {
                hearts[3].mode = 2;
            }
            else
            {
                hearts[3].mode = 1;
            }
            hearts[3].LifeModeChange();
        }
        else
        {
            hearts[3].gameObject.SetActive(false);
        }

        if (MainStateInstance.mainStateInstance.maxLife > 8)
        {
            hearts[4].gameObject.SetActive(true);
            if (MainStateInstance.mainStateInstance.Life <= 8)
            {
                hearts[4].mode = 0;
            }
            else if (MainStateInstance.mainStateInstance.Life >= 10)
            {
                hearts[4].mode = 2;
            }
            else
            {
                hearts[4].mode = 1;
            }
            hearts[4].LifeModeChange();
        }
        else
        {
            hearts[4].gameObject.SetActive(false);
        }

        //if(Input.GetKeyDown (KeyCode.UpArrow))
        //{
        //    MainStateInstance.mainStateInstance.Life++;
        //}
        //if (Input.GetKeyDown(KeyCode.DownArrow ))
        //{
        //    MainStateInstance.mainStateInstance.Life--;
        //}

    }
}
