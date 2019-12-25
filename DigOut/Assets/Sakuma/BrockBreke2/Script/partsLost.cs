using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class partsLost : MonoBehaviour
{



    bool Lost=false;
    float lostTime = 0;

    public Material material;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Lost)
        {
            lostTime -= Time.deltaTime;
            if (lostTime < 0.5f)
            {
                material.SetFloat("_Fade", (1f/0.5f)*lostTime);
            }
            
            if(lostTime < 0)
            {
                Destroy(gameObject);
            }

        }
    }


    public void LostSet()
    {
        Lost = true;
        lostTime = Random.Range(0.6f, 2f);
    }


}
