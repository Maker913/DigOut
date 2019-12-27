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
