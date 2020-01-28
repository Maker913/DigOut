using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointMake : MonoBehaviour
{
    [SerializeField]
    int pow;
    [SerializeField]
    GameObject[] Brock;
    [SerializeField]
    Shader BreakShader;
    [SerializeField]
    Texture texture;

    Material[] Break=new Material[9] ;


    Vector2[] Pos=new Vector2[9];
    [SerializeField]
    PolygonCollider2D[] collider2Ds;
    [SerializeField]
    Rigidbody2D[] rigidbody;
    [SerializeField]
    partsLost[] partsLosts; 
    public int[] kado = new int[9];
    public float power;
    public float anglePower;

    [SerializeField]
    Collider2D collider2D;

    [SerializeField]
    GameObject[] Item;

    bool flg = false;
    float flgTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 9; i++)
        {
            Break[i] = new Material(BreakShader);
            Break[i].SetInt("_target", i);
            Break[i].SetTexture("_MainTex",texture);
            Brock[i].GetComponent<Renderer>().material = Break[i];
            partsLosts[i].material = Break[i];
        }
        Point();
        
    }

    // Update is called once per frame
    void Update()
    {


        if (flg)
        {
            flgTime -= Time.deltaTime;
            if(flgTime < 0)
            {
                Destroy(gameObject);
            }
        }






    }



    private void OnTriggerStay2D(Collider2D collision)
    {


        if (LayerMask.LayerToName(collision.gameObject.layer) == "Atk" && Player.Atk&&pow<=MainStateInstance.mainStateInstance.Pow)
        {

            Bom();
        }


    }

    public void Bom()
    {
        if (!flg)
        {
            Destroy(collider2D);
            if (Random.Range(0,10)  >= 6) {
                GameObject data = Instantiate(Item[Random.Range(0, 3)], transform.position + new Vector3(0.5f, 0.5f, 0), Quaternion.identity);
                Rigidbody2D rigidbody2D = data.GetComponent<Rigidbody2D>();
                rigidbody2D.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
            }

            for (int i = 0; i < 9; i++)
            {
                rigidbody[i].constraints = RigidbodyConstraints2D.None;
                rigidbody[i].gravityScale = 1;
                Vector2 vec = (Pos[i] - new Vector2(0.5f, 0.5f)).normalized;
                rigidbody[i].AddForce(vec * power);
                rigidbody[i].AddTorque(Random.Range(-anglePower, anglePower));
                partsLosts[i].LostSet();
            }
            flg = true;
            flgTime = 3;
        }



    }
    void Point()
    {
        for(int i = 0; i < 9; i++)
        {
            Vector4 setData = new Vector4(Random.Range(0f,1f), Random.Range(0f, 1f), 0,0);
            Pos[i] = setData;
            for (int j = 0; j < 9; j++)
            {
                Break[j].SetVector("_pt" + (i + 1).ToString(), setData);
            }
        }

        for(int i = 0; i < 9; i++)
        {
            Vector2[] brockPos = new Vector2[20];
            int[,] element = new int[20,3];
            kado[i] = 0;
            int cont = 0;
            for(int x = 0; x < 9; x++)
            {
                for(int y = x+1; y < 9; y++)
                {
                    if (i != x && i != y)
                    {
                        cont++;

                        Vector2 Cpoint = calcCircleOf2Point(Pos[i],Pos [x],Pos[y]);

 


                        float dis = Vector2.Distance(Cpoint, Pos[i]);
                        bool ok = true;


                        if (Cpoint.x > 1 || Cpoint.x < 0 || Cpoint.y > 1 || Cpoint.y < 0)
                        {
                            ok = false;
                        }


                        for (int z = 0; z < 9; z++)
                        {
                            if (z != i && z != x && z != y)
                            {
                                if (dis > Vector2.Distance(Cpoint, Pos[z]))
                                {
                                    ok = false;
                                }
                            }
                        }

                        if (ok)
                        {
                            brockPos[kado[i]] = Cpoint;
                            element[kado[i], 0] = i;
                            element[kado[i], 1] = x;
                            element[kado[i], 2] = y;
                            kado[i]++;
                            
                        }

                        

                    }
                }

                if (i != x)
                {
                    float angle =-1/( (Pos[i].y - Pos[x].y) / (Pos[i].x - Pos[x].x));
                    Vector2 tyu = (Pos[i] + Pos[x]) / 2;
                    float sep = tyu.y - angle * tyu.x;


                    for (int z = 0; z < 4; z++)
                    {

                        Vector2 kadoPos = new Vector2(0, 0);
                        bool ok = true;
                        switch (z)
                        {
                            case 0:
                                kadoPos = new Vector2(0, sep);
                                break;
                            case 1:
                                kadoPos = new Vector2(1, angle +sep);
                                break;
                            case 2:
                                kadoPos = new Vector2((-1*sep)/angle, 0);
                                break;
                            case 3:
                                kadoPos = new Vector2((1-sep)/angle, 1);
                                break;
                        }
                        float dis = Vector2.Distance(kadoPos, Pos[i]);



                        if (kadoPos.x > 1 || kadoPos.x < 0 || kadoPos.y > 1 || kadoPos.y < 0)
                        {
                            ok = false;
                        }



                        for (int a = 0; a < 9; a++)
                        {
                            if (a != i&&a!=x)
                            {
                                if (dis > Vector2.Distance(kadoPos, Pos[a]))
                                {
                                    ok = false;
                                }
                            }
                        }

                        if (ok)
                        {
                            brockPos[kado[i]] = kadoPos;
                            element[kado[i], 0] = i;
                            element[kado[i], 1] = x;
                            element[kado[i], 2] = z+9;
                            kado[i]++;
                        }

                    }



                }




            }

            //Debug.Log(cont);



            for (int z = 0; z < 4; z++)
            {

                Vector2 kadoPos = new Vector2(0, 0);
                bool ok = true;
                switch (z)
                {
                    case 0:
                        kadoPos = new Vector2(0, 0);
                        break;
                    case 1:
                        kadoPos = new Vector2(1, 0);
                        break;
                    case 2:
                        kadoPos = new Vector2(0, 1);
                        break;
                    case 3:
                        kadoPos = new Vector2(1, 1);
                        break;
                }
                float dis = Vector2.Distance(kadoPos, Pos[i]);
                for (int a = 0; a < 9; a++)
                {
                    if (a != i)
                    {
                        if (dis > Vector2.Distance(kadoPos, Pos[a]))
                        {
                            ok = false;
                        }
                    }
                }

                if (ok)
                {
                    brockPos[kado[i]] = kadoPos;
                    element[kado[i], 0] = i;
                    switch (z)
                    {
                        case 0:
                            element[kado[i], 1] = 9;
                            element[kado[i], 2] = 11;
                            break;
                        case 1:
                            element[kado[i], 1] = 10;
                            element[kado[i], 2] = 11;
                            break;
                        case 2:
                            element[kado[i], 1] = 9;
                            element[kado[i], 2] = 12;
                            break;
                        case 3:
                            element[kado[i], 1] = 10;
                            element[kado[i], 2] = 12;
                            break;
                    }
                    kado[i]++;
                }

            }







            ///



            Vector2[] brockPos2 = new Vector2[kado[i]];
            for (int a = 0; a < kado[i]; a++)
            {
                brockPos2[a] = brockPos[a]-new Vector2(0.5f,0.5f) ;
            }
            Vector2[] brockPos3 = new Vector2[kado[i]];


            brockPos3[0] = brockPos2[0];
            int next = 0;
            int back = next;
            for(int b=0;b< kado[i]-1; b++)
            {
                for (int c = 0; c < kado[i]; c++)
                {
                    if (c != next&&c!=back )
                    {
                        int cnt = 0;
                        if (element[next, 0] == element[c, 0] || element[next, 0] == element[c, 1] || element[next, 0] == element[c, 2])
                        {
                            cnt++;
                        }
                        if (element[next, 1] == element[c, 0] || element[next, 1] == element[c, 1] || element[next, 1] == element[c, 2])
                        {
                            cnt++;
                        }
                        if (element[next, 2] == element[c, 0] || element[next, 2] == element[c, 1] || element[next, 2] == element[c, 2])
                        {
                            cnt++;
                        }

                        if (cnt >= 2)
                        {
                            brockPos3[b + 1] = brockPos2[c];
                            back = next;
                            next = c;
                            break;
                        }


                    }

                }




            }
            
            collider2Ds[i].points = brockPos3;




        }



    }

    

    Vector2 calcCircleOf2Point(Vector2 pt1, Vector2 pt2, Vector2 pt3)
    {
        float x1 = pt1.x;
        float y1 = pt1.y;
        float x2 = pt2.x;
        float y2 = pt2.y;
        float x3 = pt3.x;
        float y3 = pt3.y;

        float ox, oy, a, b, c, d;

        a = x2 - x1;
        b = y2 - y1;
        c = x3 - x1;
        d = y3 - y1;


        ox = x1 + (d * (a * a + b * b) - b * (c * c + d * d)) / (a * d - b * c) / 2f;
        oy = (c * (x1 + x3 - ox - ox) + d * (y1 + y3)) / d / 2f;


        

        return new Vector2(ox,oy);
    }

}
