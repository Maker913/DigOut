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
    //謎
    float velocityXSmoothing;
    //コントローラー保存先
    Controller2D controller;


    //改造要素
    [SerializeField]
    PlayerAnimeController playerAnime;


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
    }

    void FixedUpdate()
    {

        if (controller.collisions.above || controller.collisions.below)
        {
            velocity.y = 0;
        }

        //プレイヤーの移動方向
        //コントローラー等のスティックのベクトル取得
        //Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        Vector2 input = new Vector2(0,0);

        //キーボードからの入力取得
        if (PS4ControllerInput.pS4ControllerInput.contorollerState.leftWalk) { input.x = -1; }
        if (PS4ControllerInput.pS4ControllerInput.contorollerState.rightWalk) { input.x = 1; }

        //改造要素
        //アニメモードを送る
        if (controller.collisions.below)
        {
            if (PS4ControllerInput .pS4ControllerInput .contorollerState .leftWalk   ^ PS4ControllerInput.pS4ControllerInput.contorollerState.rightWalk )
            {
                if (PS4ControllerInput.pS4ControllerInput.contorollerState.leftWalk) { playerAnime.animeMode = PlayerAnimeController.AnimeMode.LWork; }
                if (PS4ControllerInput.pS4ControllerInput.contorollerState.rightWalk) { playerAnime.animeMode = PlayerAnimeController.AnimeMode.RWork; }
            }
            else
            {
                playerAnime.animeMode = PlayerAnimeController.AnimeMode.Idole;
            }
            
        }










        //ジャンプ
        if (PS4ControllerInput.pS4ControllerInput.contorollerState.Jump  && controller.collisions.below)
        {
            velocity.y = jumpVelocity;
            playerAnime.animeMode = PlayerAnimeController.AnimeMode.Fall ;
        }

        //x軸の慣性計算
        //現在目標の速度を計算、それを目的地とする
        float targetVelocityX = input.x * moveSpeed;
        //加速の計算
        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below) ? accelerationTimeGrounded : accelerationTimeAirborne);
        //
        velocity.y += gravity * Time.fixedDeltaTime ;
        controller.Move(velocity * Time.fixedDeltaTime);
    }
}