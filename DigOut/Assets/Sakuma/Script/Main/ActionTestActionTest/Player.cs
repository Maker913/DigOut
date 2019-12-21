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

    bool Jump;
    int jumpTime;
    private void OnTriggerStay2D(Collider2D collision)
    {
        
       
        if (LayerMask.LayerToName(collision.gameObject.layer) == "Damage"&& DamageTime<0)
        {

            damageVelocity = ((Vector2 )collision.gameObject.transform.position- (Vector2)transform.position ).normalized;
            damageVelocity *=-1* 20;
            damageVelocity.y = 5;
            DamageTime = 2;
            MainStateInstance.mainStateInstance.Life--;
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

        //上二つを表示
        //print("Gravity: " + gravity + "  Jump Velocity: " + jumpVelocity);
    }

    void FixedUpdate()
    {

        if (left)
        {
            atkCol.transform.localPosition = new Vector3(-2,0.15f,0);
        }
        else
        {
            atkCol.transform.localPosition = new Vector3(2, 0.15f, 0);
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

                if (PS4ControllerInput.pS4ControllerInput.contorollerState.Circle  )
                {
                    Debug.Log("asa");
                    atk = true;
                    atkTime = 0;
                    Atk = true;
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
                atkTime += Time.deltaTime;
                if (atkTime > 0.5f)
                {
                    atk = false ;
                }





            }



            //damageVelocity *= 0.5f;
            if(damageVelocity!=Vector3.zero)
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