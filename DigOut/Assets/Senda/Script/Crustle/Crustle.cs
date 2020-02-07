using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Controller2D))]
public class Crustle : MonoBehaviour
{
    ////ジャンプの最高到達点
    public float jumpHeight = 4;
    ////ジャンプの最高到達点までにかかる時間
    public float timeToJumpApex = .4f;


    //最高速度、停止
    //空中
    public float accelerationTimeAirborne = .2f;
    //地上
    public float accelerationTimeGrounded = .1f;



    //移動速度
    public float moveSpeed = 6;


    ////重力はジャンプの到達点、到達までにかかる時間から計算
    float gravity;
    ////ジャンプ時の初速
    float jumpVelocity;
    //このオブジェクトの慣性保管場所
    Vector3 velocity;


    //謎
    float velocityXSmoothing;
    //コントローラー保存先
    Controller2D controller;

    [SerializeField]
    public LayerMask layer;

    float Turnspeed = 180f;

    [SerializeField]
    Material material1;

    float angle;

    bool Turn;
    [SerializeField]
    int crustleHP = 3;


    //佐久間追加分
    Vector3 damageVelocity = Vector3.zero;
    [SerializeField]
    float DamageTime = 0;
    [SerializeField]
    GameObject[] parts;
    [SerializeField]
    GameObject[] parts2;
    [SerializeField]
    Shader shader;
    [SerializeField]
    Texture2D texture2D;
    //

    //佐久間追加分
    private void OnTriggerStay2D(Collider2D collision)
    {


        if (LayerMask.LayerToName(collision.gameObject.layer) == "Atk" && DamageTime < 0&&Player .Atk )
        {
            SoundController.Instance.PlaySE(SoundController.SeName.metal02);
            damageVelocity = ((Vector2)collision.gameObject.transform.parent.gameObject.transform.position - (Vector2)transform.position).normalized;
            Debug.Log(damageVelocity);
            damageVelocity *= (Turn ?-1:1) * 20;
            damageVelocity.y = 5;
            DamageTime = 1;
            crustleHP-=MainStateInstance.mainStateInstance.Pow;
        }
    }
    //


    void Start()
    {
        //コントローラー取得
        controller = GetComponent<Controller2D>();

        ////重力計算
        gravity = -(2 * jumpHeight) / Mathf.Pow(timeToJumpApex, 2);

        Material mat = new Material (shader);
        mat.SetColor("_Color", new Color(1, 1, 1, 1));
        mat.SetTexture("_MainTex", texture2D);
        material1 = mat;
        for (int i = 0; i < parts.Length; i++)
        {
            parts[i].GetComponent<MeshRenderer>().material = mat;

        }
        for (int i = 0; i < parts2.Length; i++)
        {
            parts2[i].GetComponent<SkinnedMeshRenderer >().material = mat;

        }
        ////ジャンプ初速算出
        //jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;


        //上二つを表示
        //print("Gravity: " + gravity + "  Jump Velocity: " + jumpVelocity);
    }

    void HitRay()
    {
        Ray ray = new Ray(transform.position, new Vector3(1, 2, 0));

        RaycastHit2D hit;

        float range = 1.2f;

        Debug.DrawLine(new Vector3(0, 0.9f) +transform.position, new Vector3(0, 0.9f) + transform.position + (Turn == true ? Vector3.right  : Vector3.left )*range, Color.red);

        if (Physics2D.Raycast(new Vector2 (0, 0.9f) + (Vector2 )transform.position,Turn == true ? Vector2.right:Vector2.left,range,layer))
        {
            //Debug.Log("a");
            Turn = !Turn;
        }
    }

    void FixedUpdate()
    {
        
        DamageTime -= Time.fixedDeltaTime;
       

        if (DamageTime > 0)
        {
            material1.SetColor("_Color", new Color(1, 1, 1, (Mathf.Sin((DamageTime * 360) * 4 * Mathf.PI / 180) + 1) / 2));
            //material1.SetColor("_Color", new Color(1, 1, 1, 0));
        }
        if (DamageTime < 0)
        {
            material1.SetColor("_Color", new Color(1, 1, 1, 1));
        }


        if (MainStateInstance.mainStateInstance.mainState.gameMode == MainStateInstance.GameMode.Play)
        {

            if(crustleHP <= 0)
            {
                Destroy(gameObject);
            }

            if (controller.collisions.above || controller.collisions.below)
            {
                velocity.y = 0;
            }

            //プレイヤーの移動方向
            //コントローラー等のスティックのベクトル取得
            //Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            Vector2 input = new Vector2(0, 0);



            HitRay();

            float step = Turnspeed * Time.deltaTime;

            if (Turn == true)
            {
                if(transform.localEulerAngles.y >= 0f)
                {
                    input.x = 0;

                    transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0f, 0), step);

                    //angle = Mathf.LerpAngle(0.0f, 0.0f, Time.time);

                    //transform.eulerAngles = new Vector2(0, angle);

                    //Debug.Log("0A");
                }
                if (input.x == 0)
                {
                    input.x = 1;
                }
                //transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0f, 0), step);



                //Debug.Log("true");
            }

            if (Turn == false)
            {
                if (transform.localEulerAngles.y >= 0f)
                {
                    input.x = 0;

                    transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 180f, 0), step);

                    //angle = Mathf.LerpAngle(0.0f, 0.0f, Time.time);

                    //transform.eulerAngles = new Vector2(0, angle);

                    //Debug.Log("180A");
                }
                if (input.x == 0)
                {
                    input.x = 1;
                }
                //transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 180f, 0), step);

                //angle = Mathf.LerpAngle(0.0f, 180.0f, Time.time);

                //transform.eulerAngles = new Vector2(0, angle);

                //Debug.Log("false");
            }



            //改造要素
            //アニメモードを送る
            //if (controller.collisions.below)
            //{
            //    if (PS4ControllerInput.pS4ControllerInput.contorollerState.leftWalk ^ PS4ControllerInput.pS4ControllerInput.contorollerState.rightWalk)
            //    {
            //        if (PS4ControllerInput.pS4ControllerInput.contorollerState.leftWalk) { playerAnime.animeMode = PlayerAnimeController.AnimeMode.LWork; }
            //        if (PS4ControllerInput.pS4ControllerInput.contorollerState.rightWalk) { playerAnime.animeMode = PlayerAnimeController.AnimeMode.RWork; }
            //    }
            //    else
            //    {
            //        playerAnime.animeMode = PlayerAnimeController.AnimeMode.Idole;
            //    }

            //}










            //x軸の慣性計算
            //現在目標の速度を計算、それを目的地とする
            float targetVelocityX = input.x * moveSpeed;
            //加速の計算
            //Debug.Log(transform.localEulerAngles .y);
            if (transform.localEulerAngles.y==180|| transform.localEulerAngles.y ==0)
            {
                velocity.x = targetVelocityX;/*Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below) ? accelerationTimeGrounded : accelerationTimeAirborne)*/;
                //

            }
            else
            {
                velocity.x  =0;
            }
            if (damageVelocity != Vector3.zero)
            {
                velocity = damageVelocity;
                damageVelocity *= 0.75f;

            }


            velocity.y += gravity * Time.fixedDeltaTime;
            try
            {
                controller.Move(velocity * Time.fixedDeltaTime);
            }
            catch
            {
                return;
            }

        }
    }
}