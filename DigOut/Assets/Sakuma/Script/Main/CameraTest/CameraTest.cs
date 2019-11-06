using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTest : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    
    public GameObject targetObj;
    [SerializeField]
    LayerMask cameraFrame;
    [SerializeField]
    float spead=0.1f;
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKey (KeyCode.UpArrow)){ rigidbody2D.transform.Translate(0, 3*Time.deltaTime , 0); }
        //if (Input.GetKey(KeyCode.DownArrow )) { rigidbody2D.transform.Translate(0, -3 * Time.deltaTime, 0); }
        //if (Input.GetKey(KeyCode.RightArrow )) { rigidbody2D.transform.Translate(3 * Time.deltaTime, 0, 0); }
        //if (Input.GetKey(KeyCode.LeftArrow )) { rigidbody2D.transform.Translate(-3 * Time.deltaTime, 0, 0); }












    }

    private float refSpead=0;
    public float cameradis = 2;
    public float dis=0;
    private void FixedUpdate()
    {


        Vector2 move = (targetObj.transform.position - transform.position) ;

        move = move.normalized;

        dis = Vector2.Distance(targetObj.transform.position, transform.position);
        if (Mathf.Abs(dis) < cameradis)
        {
            dis = 0;
        }
        else
        {
            dis -= dis < 0 ? -cameradis : cameradis;
        }
        //if (dis > spead)
        //{
        //    dis = spead;
        //}
        dis=Mathf.SmoothDamp(0,dis,ref refSpead ,spead);
        rigidbody2D.transform.Translate(move*dis);


        //if (Physics2D.CircleCast(transform.position, 0.5f, Vector2.right, move.x, cameraFrame))
        //{
        //    //Debug.Log(move.x);
        //    float cont = 30f;
        //    bool next = false;
        //    do
        //    {
        //        cont -= 1f;

        //        if (!Physics2D.CircleCast(transform.position, 0.5f, Vector2.right, move.x * (cont / 30f), cameraFrame))
        //        {
        //            next = true;
        //        }

        //        if (cont <= 0) { break; }

        //    } while (!next);
        //    Debug.Log(cont);
        //    rigidbody2D. transform.Translate(move.x * (cont / 30f), 0, 0);
        //}
        //else
        //{
        //    rigidbody2D.transform.Translate(move.x, 0, 0);
        //}

        //if (Physics2D.CircleCast(transform.position, 0.5f, Vector2.up, move.y, cameraFrame))
        //{
        //    //Debug.Log(move.x);
        //    float cont = 30f;
        //    bool next = false;
        //    do
        //    {
        //        cont -= 1f;

        //        if (!Physics2D.CircleCast(transform.position, 0.5f, Vector2.up, move.y * (cont / 30f), cameraFrame))
        //        {
        //            next = true;
        //        }

        //        if (cont <= 0) { break; }

        //    } while (!next);
        //    Debug.Log(cont);
        //    rigidbody2D.transform.Translate(0, move.y * (cont / 30f), 0);
        //}
        //else
        //{
        //    rigidbody2D.transform.Translate(0, move.y, 0);
        //}






    }



}
