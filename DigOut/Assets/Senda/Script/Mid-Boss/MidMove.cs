using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidMove : MonoBehaviour
{
    public GameObject Quad;

    public Player sc;

    bool te = false;

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
    //謎
    float velocityXSmoothing;
    //コントローラー保存先
    Controller2D controller;

    [SerializeField]
    public LayerMask layer;

    float Turnspeed = 180f;



    float angle;

    bool Turn;


    //中ボス
    //GameObject MidBoss;


    void Start()
    {


        //コントローラー取得
        controller = GetComponent<Controller2D>();

        //重力計算
        gravity = -(2 * jumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        //ジャンプ初速算出
        jumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;


        //上二つを表示
        //print("Gravity: " + gravity + "  Jump Velocity: " + jumpVelocity);

        //MidBoss = GameObject.Find("Mid-Boss");
    }

    void HitRay()
    {
        Ray ray = new Ray(transform.position, new Vector3(1, 2, 0));

        RaycastHit2D hit;

        float range = 1.2f;

        Debug.DrawLine(new Vector3(0, 0.9f) + transform.position, new Vector3(0, 0.9f) + transform.position + (Turn == true ? Vector3.right : Vector3.left) * range, Color.red);

        if (Physics2D.Raycast(new Vector2(0, 0.9f) + (Vector2)transform.position, Turn == true ? Vector2.right : Vector2.left, range, layer))
        {
            //Debug.Log("a");
            Turn = !Turn;
        }
    }

    public void MidJump()
    {
        te = true;
    }

    void FixedUpdate()
    {
        if (MainStateInstance.mainStateInstance.mainState.gameMode == MainStateInstance.GameMode.Play)
        {

            if (controller.collisions.above || controller.collisions.below)
            {
                velocity.y = 0;
            }

            Vector2 input = new Vector2(0, 0);

            HitRay();

            float step = Turnspeed * Time.deltaTime;

            if (Turn == true)
            {
                if (transform.localEulerAngles.y >= 0f)
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


            if (te == true && controller.collisions.below)
            {
                velocity.y = jumpVelocity;
                te = false;
                //playerAnime.animeMode = PlayerAnimeController.AnimeMode.Fall;
            }

            if (te == true && velocity.y != 0)
            {
                te = false;
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
            }
            catch
            {
                return;
            }

        }
    }
}