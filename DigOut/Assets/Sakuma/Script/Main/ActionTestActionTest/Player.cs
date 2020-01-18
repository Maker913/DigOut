using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Controller2D))]
public class Player : MonoBehaviour
{
    //ジャンプの最高到達点
    public float jumpHeight = 4;
    //ジャンプの最高到達点までにかかる時間
    public float timeToJumpApex = .4f;


    //最高速度、停止
    //空中
    public float accelerationTimeAirborne = .2f;
    //地上
    public float accelerationTimeGrounded = .1f;



    //移動速度
    public float moveSpeed = 6;


    //重力はジャンプの到達点、到達までにかかる時間から計算
    float gravity;
    //ジャンプ時の初速
    float jumpVelocity;
    //このオブジェクトの慣性保管場所
    Vector3 velocity;
    Vector3 damageVelocity=Vector3.zero;
    //謎
    float velocityXSmoothing;
    //コントローラー保存先
    Controller2D controller;


    //改造要素
    [SerializeField]
    PlayerAnimeController playerAnime;

    [SerializeField]
    Material material1;
    [SerializeField]
    Material material2;

    bool left = false;
    bool atk = false;
    float atkTime = 0;

    float DamageTime=0;
    [SerializeField]
    GameObject atkCol;
    static public bool Atk = false;

    bool atkHold = false;
    bool Jump;
    int jumpTime;
    bool atkTik = false;

    float pustPos;

    int ActionNumber;

    [SerializeField]
    LayerMask nomalMask;
    [SerializeField]
    LayerMask upMask;

    [SerializeField]
    LayerMask Mask;
    bool footFlg=false;

    [SerializeField]
    public GameObject Midboss;
    public Midboss Sc;
    public Vector2 PlayerMove = Vector2.zero;

    private void OnTriggerStay2D(Collider2D collision)
    {



        if (LayerMask.LayerToName(collision.gameObject.layer) == "Damage" && DamageTime < 0)
        {
            Debug.Log("ダメージ受けた");
            SoundController.Instance.PlaySE(SoundController.SeName.Damage);
            damageVelocity = ((Vector2)collision.gameObject.transform.position - (Vector2)transform.position).normalized;
            damageVelocity *= -1 * 20;
            damageVelocity.y = 5;
            DamageTime = 2;
            MainStateInstance.mainStateInstance.Life--;
        }


    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Penet")
        {
            footFlg = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Penet")
        {
            if (!Physics2D.BoxCast(transform.position, new Vector2(0.75f, 0.975f * 2), 0, Vector2.up, 0, Mask))
            {
                footFlg = false;
            }

            
        }
    }

    void Start()
    {
        //コントローラー取得
        controller = GetComponent<Controller2D>();

        //重力計算
        gravity = -(2 * jumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        //ジャンプ初速算出
        jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;

        atk = false;
        Jump = false;
        jumpTime = 0;

        pustPos = transform.position.y;

        MainStateInstance.mainStateInstance.footPos = transform.position.y;
        //上二つを表示
        //print("Gravity: " + gravity + "  Jump Velocity: " + jumpVelocity);
        PlayerMove = transform.position;
    }

    private void BGM()
    {
        if (ActionNumber == 0)
        {
            SoundController.Instance.PlaySE(SoundController.SeName.Attack);
        }
        if(ActionNumber == 1)
        {
            SoundController.Instance.PlaySE(SoundController.SeName.Jump);
        }
    }

    void FixedUpdate()
    {
        Debug.DrawLine(transform.position + new Vector3(0, (0.975f ), -10), transform.position + new Vector3(0, -1 * (0.975f ), -10));
        Debug.DrawLine(transform.position + new Vector3((0.75f / 2f), 0, -10), transform.position + new Vector3(-1 * (0.75f / 2f), 0, -10));
        if (pustPos - transform.position.y<-0.01f)
        {
            controller.collisionMask = upMask;
        }
        if (pustPos - transform.position.y > 0f&&!footFlg )
        {
            controller.collisionMask = nomalMask;
        }
        if (PS4ControllerInput.pS4ControllerInput.contorollerState.downButton) { controller.collisionMask = upMask; }
        //Debug.Log(footFlg);

        pustPos = transform.position.y;


        if (left)
        {
            atkCol.transform.localPosition = new Vector3(-1.75f,0.1f,0);
        }
        else
        {
            atkCol.transform.localPosition = new Vector3(1.75f, 0.1f, 0);
        }
        if (PS4ControllerInput.pS4ControllerInput.contorollerState.downButton)
        {
            atkCol.transform.localPosition = new Vector3(0, -1f, 0);
        }
        if (PS4ControllerInput.pS4ControllerInput.contorollerState.upButton)
        {
            atkCol.transform.localPosition = new Vector3(0, 1f, 0);
        }

        DamageTime -= Time.fixedDeltaTime;

        if(DamageTime > 0)
        {
            material1.SetColor("_Color", new Color(1, 1, 1, (Mathf.Sin((DamageTime * 360)*4 * Mathf.PI / 180)+1)/2));
            material2.SetColor("_Color", new Color(1, 1, 1, (Mathf.Sin((DamageTime * 360)*4 * Mathf.PI / 180) + 1) / 2));
        }
        if (DamageTime < 0)
        {
            material1.SetColor("_Color", new Color(1, 1, 1, 1));
            material2.SetColor("_Color", new Color(1, 1, 1, 1));
        }








        if (MainStateInstance.mainStateInstance.mainState.gameMode == MainStateInstance.GameMode.Play)
        {

            MainStateInstance.mainStateInstance.PlayerMove = (Vector2)transform.position - PlayerMove;
            PlayerMove = (Vector2)transform.position;

            MainStateInstance.mainStateInstance.footPos = transform.position.y;
            Vector2 input = new Vector2(0, 0);

            if (!atk)
            {
                if (controller.collisions.above || controller.collisions.below)
                {
                    velocity.y = 0;
                }

                //プレイヤーの移動方向
                //コントローラー等のスティックのベクトル取得
                //Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
                

                //キーボードからの入力取得
                if (PS4ControllerInput.pS4ControllerInput.contorollerState.leftWalk) { input.x = -1; }
                if (PS4ControllerInput.pS4ControllerInput.contorollerState.rightWalk) { input.x = 1; }

                //改造要素
                //アニメモードを送る


                if(PS4ControllerInput.pS4ControllerInput.contorollerState.Jump)
                {
                    jumpTime  += 1;
                }
                else
                {
                    jumpTime = 0;
                }

                if (jumpTime == 1)
                {
                    Jump = true;
                }
                else
                {
                    Jump = false ;
                }

                //ジャンプ
                if (Jump && controller.collisions.below&& playerAnime.animeMode != PlayerAnimeController.AnimeMode.Fall)
                {
                    velocity.y = jumpVelocity;
                    playerAnime.animeMode = PlayerAnimeController.AnimeMode.Fall;
                    Debug.Log("飛んだ");
                    ActionNumber = 1;
                    BGM();
                    //sc.MidJump();
                }
                else if (controller.collisions.below)
                {
                    if (PS4ControllerInput.pS4ControllerInput.contorollerState.leftWalk ^ PS4ControllerInput.pS4ControllerInput.contorollerState.rightWalk)
                    {
                        if (PS4ControllerInput.pS4ControllerInput.contorollerState.leftWalk) { playerAnime.animeMode = PlayerAnimeController.AnimeMode.LWork; left = true; }
                        if (PS4ControllerInput.pS4ControllerInput.contorollerState.rightWalk) { playerAnime.animeMode = PlayerAnimeController.AnimeMode.RWork; left = false; }
                    }
                    else
                    {
                        playerAnime.animeMode = PlayerAnimeController.AnimeMode.Idole;
                    }

                }




                    

                if (PS4ControllerInput.pS4ControllerInput.contorollerState.Circle&&!atk  && !atkHold)
                {
                    Debug.Log("攻撃");
                    atk = true;
                    atkTime = 0;
                    atkTik = true;
                    ActionNumber = 0;
                    BGM();
                    if (left)
                    {
                        playerAnime.animeMode = PlayerAnimeController.AnimeMode.LAtk;
                    }
                    else
                    {
                        playerAnime.animeMode = PlayerAnimeController.AnimeMode.RAtk;
                    }




                }
                else
                {
                    Atk = false ;
                }



            }
            else
            {
                Atk = false;
                
                if (atkTime > 0.1f&& atkTik)
                {
                    Atk = true;
                    atkTik = false;
                }
                



                atkTime += Time.deltaTime;
                if (atkTime > 0.5f)
                {
                    atk = false ;
                }





            }
            if (Atk)
            {
                Debug.Log("aaaaaa");
            }

            if(Input.GetKey(KeyCode.X))
            {

            }

            atkHold = PS4ControllerInput.pS4ControllerInput.contorollerState.Circle;

            //damageVelocity *= 0.5f;
            if (damageVelocity!=Vector3.zero)
            {
                velocity = damageVelocity;
                damageVelocity = Vector3.zero;

            }

            //x軸の慣性計算
            //現在目標の速度を計算、それを目的地とする
            float targetVelocityX = input.x * moveSpeed;
            //加速の計算
            velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below) ? accelerationTimeGrounded : accelerationTimeAirborne);
            //
            velocity.y += gravity * Time.fixedDeltaTime;

            //Debug.Log();



            try
            {
                controller.Move(velocity * Time.fixedDeltaTime);
            }catch
            {
                return;
            }
            
        }
    }
}