using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{

    [SerializeField]
    public GameObject player;
    public float oldtrans;

     public  float late;

    public float leng =0;
    Material material;

    public float d;
    private void Start()
    {
        material = GetComponent<Renderer>().material;
        oldtrans = player.transform.position.x;
    }



    private void FixedUpdate()
    {
        float data= oldtrans - player.transform.position.x;
        //transform.Translate(data/late, 0, 0);
        leng += data / late;
        d = leng - (int)leng;
        material.SetFloat("_Rim",Mathf.Abs( leng - (int)leng));
        oldtrans = player.transform.position.x;
    }

}
