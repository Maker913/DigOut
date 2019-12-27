using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Scene : MonoBehaviour
{
    //インスタンス
    static public Scene sceneManagerPr;

    //画面暗転
    [SerializeField]
    float lostTime = 1;

    //暗転の画像
    Image backImage;

    //暗転するオブジェ
    GameObject backImageobj;

    //暗転をチェクするフラグ
    bool lostCheck;
    bool go;

    //経過時間の格納先
    float dTime;

    //遷移するシーンの名前
    string name;

    // Start is called before the first frame update
    void Start()
    {
        //Prefabが空の時の処理
        if (sceneManagerPr == null)
        {
            //暗転オブジェの取得
            backImage = transform.GetChild(0).GetChild(0).GetComponent<Image>();
            backImageobj = transform.GetChild(0).GetChild(0).gameObject;

            //シーンをまたぐ設定
            DontDestroyOnLoad(this.gameObject);
            sceneManagerPr = this;

            //開始のみ暗転オブジェの非表示化
            backImageobj.SetActive(false);
        }

    }




    private void Awake()
    {

    }


    public void SceneLoad(string scenename)
    {

        SetpReset.bfName = SceneManager.GetActiveScene().name;


        //Updateに渡すフラグの初期化
        lostCheck = true;
        go = true;
        dTime = 0;
        //名前格納
        name = scenename;
        //暗転オブジェの表示
        backImageobj.SetActive(true);
    }

    private void Update()
    {

        //暗転フラグが正の時のみ処理
        if (lostCheck)
        {

            if (go)
            {
                //暗転する処理

                //経過時間取得
                dTime += Time.deltaTime;
                //経過時間を参照しα値を計算、設定
                backImage.color = new Color(0, 0, 0, Mathf.Pow(dTime / lostTime, 2));

                if (dTime > lostTime)
                {
                    //Sceneの移動
                    SceneManager.LoadScene(name);
                    //暗転解除に移行
                    dTime = 0;
                    go = false;
                }
            }
            else
            {
                //暗転解除の処理

                //経過時間取得
                dTime += Time.deltaTime;
                //経過時間を参照しα値を計算、設定
                backImage.color = new Color(0, 0, 0, 1 - Mathf.Pow(dTime / lostTime, 2));

                if (dTime > lostTime)
                {
                    //暗転オブジェの非表示化
                    backImageobj.SetActive(false);
                    //フラグの初期化
                    lostCheck = false;
                    dTime = 0;
                }
            }
        }
    }



}