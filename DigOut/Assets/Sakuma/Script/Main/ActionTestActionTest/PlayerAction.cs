using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;

    //プレイヤーの慣性
    [System.Serializable]
    public struct PlayerVector
    {
        public float x;
        public float y;

        public void VectorSet()
        {
            x = 0;
            y = 0;
        }

    }
    public PlayerVector playerVector;
    //操縦時の入力
    [System.Serializable]
    public struct PlayerInput
    {
        public bool Lwalk;
        public bool Rwalk;
        public bool Jump;
        public void Set()
        {
            Lwalk = false;
            Rwalk = false;
            Jump = false;
        }

    }
    public PlayerInput playerInput;


    [HeaderAttribute("横移動減衰率"),SerializeField]
    private float decrease;
    [HeaderAttribute("最高速度 m/s")]
    [SerializeField]
    private float topSpeed;
    [HeaderAttribute("最高速度までの到達時間")]
    [SerializeField]
    private float topSpeedDelayTime;

    [HeaderAttribute("ジャンプの最高到達点")]
    [SerializeField]
    private float jumpTop;
    [HeaderAttribute("ジャンプの最高到達点までにかかる時間")]
    [SerializeField]
    private float jumpTopTime;


    [Header("降下最高速度")]
    [SerializeField]
    private float gravityTop;
    [Header("降下最高速度までにかかる時間")]
    [SerializeField]
    private float gravityTopTime;
    private float gravity;



    public LayerMask layer;
    public LayerMask saka;
    public LayerMask nonsaka;
    public bool ska;
    public bool jpt;
    public bool tests;

    // Start is called before the first frame update
    void Start()
    {
        //rigidbody2D = GetComponent<Rigidbody2D>();
        playerVector.VectorSet();
        playerInput.Set();

        gravity = gravityTop * (1 / gravityTopTime);

    }

    // Update is called once per frame
    void Update()
    {
        //入力取得部分
        //のちps4コンに変更
        playerInput.Lwalk = Input.GetKey(KeyCode.LeftArrow);
        playerInput.Rwalk = Input.GetKey(KeyCode.RightArrow);
        playerInput.Jump = Input.GetKeyDown(KeyCode.Space);
        //横移動慣性計算

        if(playerInput.Lwalk^ playerInput.Rwalk)
        {
            if (playerInput.Lwalk) { playerVector.x -= topSpeed * (1 / topSpeedDelayTime) * Time.deltaTime; }
            if (playerVector.x < -topSpeed) { playerVector.x = -topSpeed; }
            
            if (playerInput.Rwalk) { playerVector.x += topSpeed * (1 / topSpeedDelayTime) * Time.deltaTime; }
            if (playerVector.x > topSpeed) { playerVector.x = topSpeed; }
        }
        else
        {
            //入力無しor左右同時入力で慣性のみ計算

            playerVector.x *= decrease;
            if (Mathf.Abs(playerVector.x) < 0.01f)
            {
                playerVector.x = 0;
            }
        }






        float height = 0.8f;
        float wide = 0.95f;



        //ここから異形
        ska = Physics2D.BoxCast(transform.position, new Vector2(height, 1), 0, Vector2.up, -0.1f, saka) ;

        bool jp = false;
        jpt = Physics2D.BoxCast(transform.position, new Vector2(1, 1), 0, Vector2.up, -0.1f, layer);



        tests = Physics2D.BoxCast(transform.position, new Vector2(1, height), 0, Vector2.right, playerVector.x * Time.deltaTime, nonsaka);


        //Debug.box
        if (playerVector.x != 0)
        {
            if (Physics2D.BoxCast(transform.position+new Vector3(playerVector.x * Time.deltaTime,0,0), new Vector2(1, height), 0, Vector2.right, 0, layer))
            {
                if(Physics2D.BoxCast(transform.position+new Vector3 (playerVector.x * Time.deltaTime,0,0), new Vector2(1, height), 0, Vector2.right,0 , saka)
                    && !Physics2D.BoxCast(transform.position+ new Vector3(playerVector.x * Time.deltaTime,0,0), new Vector2(1, height), 0, Vector2.right,0,nonsaka) )
                {
                    //Debug.Log("sss");
                    float angle;
                    bool right;
                    bool non = false;
                    if (playerVector.x > 0) { angle = -5f;right = true; } else { angle =185f; right = false; }
                    bool next = false;
                    do
                    {
                        if (right) { angle += 5f; } else { angle -= 5f; }
                        if (!Physics2D.BoxCast(transform.position+ new Vector3 (Mathf.Cos(angle * Mathf.PI / 180f), Mathf.Sin(angle * Mathf.PI / 180f),0) * Mathf.Abs(playerVector.x) * Time.deltaTime, new Vector2(1, height), 0, new Vector2 (Mathf.Cos(angle*Mathf.PI /180f), Mathf.Sin(angle * Mathf.PI / 180f)),0, layer))
                        {
                            next = true;
                        }
                        if (angle>=80&&right ) { non = true; break; }
                        if (angle <= 110 && !right) { non = true; break; }
                    } while (!next);
                    //Debug.Log(angle);

                    if (non)
                    {
                        Debug.Log(angle);
                        float late = 10f;
                        bool next3 = false;
                        do
                        {
                            late -= 1f;
                            if (!Physics2D.BoxCast(transform.position+new Vector3 (playerVector.x * Time.deltaTime * (late / 10f), 0,0), new Vector2(1, height), 0, Vector2.right, 0, layer))
                            {

                                next3 = true;
                            }
                            if (late <= 0) { break; }
                        } while (!next);

                        transform.Translate(new Vector2(playerVector.x, 0) * Time.deltaTime * (late / 10f));
                        playerVector.x = 0;
                        //Debug.Log("but");
                    }
                    else
                    {
                        //坂中の壁
                        if (Physics2D.BoxCast(transform.position+new Vector3 (Mathf.Cos(angle * Mathf.PI / 180f), Mathf.Sin(angle * Mathf.PI / 180f),0)* Mathf.Abs(playerVector.x) * Time.deltaTime, new Vector2(1, height-0.1f), 0,  Vector2.down , 0, layer))
                        {
                            float late = 10f;
                            bool next2 = false;
                            do
                            {
                                late -= 1f;
                                if (!Physics2D.BoxCast(transform.position + new Vector3(Mathf.Cos(angle * Mathf.PI / 180f), Mathf.Sin(angle * Mathf.PI / 180f), 0)*Mathf.Abs(playerVector.x) * Time.deltaTime * (late / 10f), new Vector2(1, height - 0.1f), 0, Vector2.down, 0, layer))
                                {

                                    next2 = true;
                                }
                                if (late <= 0) { break; }
                            } while (!next2);
                            
                            transform.Translate(new Vector2(Mathf.Abs(playerVector.x) * Mathf.Cos(angle * Mathf.PI / 180f), Mathf.Abs(playerVector.x) * Mathf.Sin(angle * Mathf.PI / 180f)) * Time.deltaTime * (late / 10f));
                            playerVector.x = 0;
                            //Debug.Log("butsaka");


                        }
                        else
                        {
                            transform.Translate(new Vector2(Mathf.Abs(playerVector.x) * Mathf.Cos(angle * Mathf.PI / 180f), Mathf.Abs(playerVector.x) * Mathf.Sin(angle * Mathf.PI / 180f)) * Time.deltaTime);
                        }
                    }





                }
                else
                {
                    float late = 10f;
                    bool next = false;
                    do
                    {
                        late -= 1f;
                        if (!Physics2D.BoxCast(transform.position, new Vector2(1, height), 0, Vector2.right, playerVector.x * Time.deltaTime * (late / 10f), layer))
                        {

                            next = true;
                        }
                        if (late <= 0) { break; }
                    } while (!next);

                    transform.Translate(new Vector2(playerVector.x, 0) * Time.deltaTime * (late / 10f));
                    playerVector.x = 0;
                    Debug.Log("通常壁");
                }

            }
            else
            {
                //斜面
                if (ska)
                {

                    //ここではない

                    Debug.Log("下り");

                    float angle;
                    bool right;
                    bool net = true;
                    if (playerVector.x > 0) { angle = 5f; right = true; } else { angle = 175f; right = false; }
                    bool next = false;
                    do
                    {
                        if (right) { angle -= 5f; } else { angle += 5f; }
                        if (Physics2D.BoxCast(transform.position, new Vector2(1, height), 0, new Vector2(Mathf.Cos(angle * Mathf.PI / 180f), Mathf.Sin(angle * Mathf.PI / 180f)), Mathf.Abs(playerVector.x) * Time.deltaTime, layer))
                        {
                            next = true;
                        }
                        if (angle <= -80 && right)
                        {
                            net = false;
                            break;
                        }
                        if (angle >= 260 && !right)
                        {
                            net = false;
                            break;
                        }
                    } while (!next);
                    if (right) { angle += 5f; } else { angle -= 5f; }
                    //Debug.Log(angle);



                    if (net)
                    {
                        transform.Translate(new Vector2(Mathf.Abs(playerVector.x) * Mathf.Cos(angle * Mathf.PI / 180f), Mathf.Abs(playerVector.x) * Mathf.Sin(angle * Mathf.PI / 180f)) * Time.deltaTime);
                    }
                    //transform.Translate(new Vector2(playerVector.x, 0) * Time.deltaTime);
                }
                else
                {
                    transform.Translate(new Vector2(playerVector.x, 0) * Time.deltaTime);
                }
                


            }


        }

        if (jpt && playerInput.Jump)
        {
            Debug.Log("飛べ");
            playerVector.y = 30;
            jp = true;

            //if(Physics2D.BoxCast(transform.position+new Vector3 (0,playerVector.y * Time.deltaTime,0), new Vector2(0.95f, 1), 0, Vector2.up, 0, layer))

        }





        if (Physics2D.BoxCast(transform.position + new Vector3(0, playerVector.y * Time.deltaTime, 0), new Vector2(wide, height + 0.05f), 0, Vector2.up, 0, layer))
        {
            float late = 10f;
            bool next = false;
            do
            {
                late -= 1f;
                if (!Physics2D.BoxCast(transform.position + new Vector3(0, playerVector.y * Time.deltaTime * (late / 10f), 0), new Vector2(wide, height+0.05f), 0, Vector2.up, 0, layer))
                {

                    next = true;
                }
                if (late <= 0) { break; }
            } while (!next);

            transform.Translate(new Vector2(0, playerVector.y) * Time.deltaTime * (late / 10.0f));
            if (!jp)
            {
                playerVector.y = -0.1f;
            }

            
            //Debug.Log(late);
        }
        else
        {
            
            transform.Translate(new Vector2(0, playerVector.y) * Time.deltaTime);
            playerVector.y -= 2;
            if (playerVector.y <= -gravityTop) { playerVector.y = -gravityTop; }
        }

        //




        //強制脱出装置









    }



    private void FixedUpdate()
    {
        //rigidbody2D.transform.Translate(new Vector2(playerVector.x, playerVector.y) * Time.deltaTime);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        float angle = 185;
        //Gizmos.DrawCube(transform.position+ new Vector3(0,playerVector.y * Time.deltaTime, 0), new Vector3(1,1f,1));
        Gizmos.color = Color.red;
        //Gizmos.DrawCube(transform.position + new Vector3(playerVector.x, 0, 0) * Time.deltaTime+new Vector3 (0,-0.4f,0), new Vector3(0.9f, 0.2f, 1));
    }


}
