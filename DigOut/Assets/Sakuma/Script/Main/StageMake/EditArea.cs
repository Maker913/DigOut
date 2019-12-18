using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class EditArea : MonoBehaviour
{

    public InputField areaInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int area=0;

        try
        {
            area = Convert.ToInt16(areaInput.text);
        }
        catch
        {
            Debug.Log("そんなエリアないで( ^)o(^ )");
            return;
        }
        if (area > transform.childCount - 1)
        {
            Debug.Log("そんなエリアないで(^_-)-☆");
            return;
        }


        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).position = new Vector3(0, 0, i==area?-5:0);
        }





    }
}
