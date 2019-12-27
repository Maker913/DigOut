using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTest : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    Rigidbody2D popRigidbody2D;
    public GameObject targetObj;
    [SerializeField]
    LayerMask cameraFrame;
    [SerializeField]
    float spead=0.1f;

    public LayerMask mask;


    // Update is called once per frame

    void Start() {
        rigidbody2D = GetComponent<Rigidbody2D>();
        popRigidbody2D = popObj.GetComponent<Rigidbody2D>(); 
    }

    private float refSpead=0;
    private float refSpead2 = 0;
    private float refSpead3 = 0;
    public float cameradis = 2;
    public float dis=0;

    public bool stepMove = false;

    [SerializeField]
    GameObject popObj;


    private void FixedUpdate()
    {


        


        if (!stepMove) {
            Vector2 move = (targetObj.transform.position - transform.position);
            move = move.normalized;

            dis = Vector2.Distance(targetObj.transform.position, transform.position);
            if (Mathf.Abs(dis) < cameradis) {
                dis = 0;
            }
            else {
                dis -= dis < 0 ? -cameradis : cameradis;
            }

            dis = Mathf.SmoothDamp(0, dis, ref refSpead3, spead);

            if (!Physics2D.CircleCast(transform.position, 0.45f, new Vector2(move.x, 0), dis, mask)) {
                rigidbody2D.transform.Translate(new Vector2(move.x, 0) * dis);
            }
            else
            {
                float cont = 10f;
                bool flg = true;
                do
                {
                    cont -= 1f;
                    if (!Physics2D.CircleCast(transform.position, 0.45f, new Vector2(move.x, 0), dis * (cont / 10f), mask))
                    {
                        flg = false;
                    }
                    if (cont <= 0)
                    {
                        break;
                    }
                } while (flg);


                rigidbody2D.transform.Translate(new Vector2(move.x, 0) * dis * (cont / 10));
                //Debug.Log(cont);
            }

            if (!Physics2D.CircleCast(transform.position, 0.45f, new Vector2(0, move.y), dis, mask)) {
                rigidbody2D.transform.Translate(new Vector2(0, move.y) * dis);
            }
            else
            {
                float cont = 10f;
                bool flg = true;
                do
                {
                    cont -= 1f;
                    if (!Physics2D.CircleCast(transform.position, 0.45f, new Vector2(0, move.y), dis * (cont / 10f), mask))
                    {
                        flg = false;
                    }
                    if (cont <= 0)
                    {
                        break;
                    }
                } while (flg);

                //Debug.Log(cont);
                rigidbody2D.transform.Translate(new Vector2(0, move.y) * dis * (cont / 10));

            }






        }
        else {



            ////////////

            Vector2  move = (targetObj.transform.position - popObj.transform.position);
            move = move.normalized;

            dis = Vector2.Distance(targetObj.transform.position, popObj.transform.position);
            if (Mathf.Abs(dis) < cameradis) {
                dis = 0;
            }
            else {
                dis -= dis < 0 ? -cameradis : cameradis;
            }

            dis = Mathf.SmoothDamp(0, dis, ref refSpead2, spead);

            if (!Physics2D.CircleCast(popObj.transform.position, 0.45f, new Vector2(move.x, 0), dis, mask)) {
                popRigidbody2D.transform.Translate(new Vector2(move.x, 0) * dis);
            }

            if (!Physics2D.CircleCast(popObj.transform.position, 0.45f, new Vector2(0, move.y), dis, mask)) {
                popRigidbody2D.transform.Translate(new Vector2(0, move.y) * dis);
            }





            move = (popObj.transform.position - transform.position);
            move = move.normalized;

            dis = Vector2.Distance(popObj.transform.position, transform.position);
            //if (Mathf.Abs(dis) < cameradis) {
            //    dis = 0;
            //}
            //else {
            //    dis -= dis < 0 ? -cameradis : cameradis;
            //}

            dis = Mathf.SmoothDamp(0, dis, ref refSpead, spead);

            rigidbody2D.transform.Translate(move * dis);



            dis = 100;

            if (Vector2.Distance(popObj.transform.position, transform.position) < 0.0001f)
            {
                transform.position = popObj.transform.position;

                stepMove = false;
            }



        }









    }



}
