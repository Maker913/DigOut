using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneController : MonoBehaviour
{
    public static SceneController Instance;
    //遷移テクスチャ
    private Texture2D blackTexture;
    private float fadeAlpha = 0;
    private bool isFading = false;
    public bool IsFading { get { return isFading; } }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            if (blackTexture == null)
            {
                //黒テクスチャを生成
                blackTexture = new Texture2D(32, 32, TextureFormat.RGB24, false);
                blackTexture.ReadPixels(new Rect(0, 0, 32, 32), 0, 0, false);
                blackTexture.SetPixel(0, 0, Color.white);
                blackTexture.Apply();
            }
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void OnGUI()
    {
        if (!isFading || blackTexture == null) return;
        //黒テクスチャを描画
        GUI.color = new Color(0, 0, 0, fadeAlpha);
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), blackTexture);
    }

    private IEnumerator SceneChange(SceneName scene, bool isFade,
        float interval, UnityEngine.Events.UnityAction unityAction)
    {
        #region 非フェード時
        if (!isFade || interval <= 0)
        {
            SceneManager.LoadScene((int)scene);
            yield break;
        }
        #endregion

        #region フェード時
        isFading = true;

        float halfInterval = interval / 2;
        //暗転
        float time = 0;
        while (time <= halfInterval)
        {
            fadeAlpha = Mathf.Lerp(0f, 1f, time / halfInterval);
            time += Time.deltaTime;
            yield return 0;
        }

        //遷移
        SceneManager.LoadScene((int)scene);

        //明転
        time = 0;
        while (time <= halfInterval)
        {
            fadeAlpha = Mathf.Lerp(1f, 0f, time / halfInterval);
            time += Time.deltaTime;
            yield return 0;
        }
        isFading = false;
        #endregion
    }
    /// <summary>
    /// <para>ゲーム、デバッグ終了 :SceneControl.Instance.Quit();</para>
    /// </summary>
    public void Quit()
    {
        //開発環境で実行時
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        //exeで起動しているとき
#elif UNITY_STANDALONE
        UnityEngine.Application.Quit();
#endif
    }
    private void Update()
    {
        if (PS4ControllerInput.pS4ControllerInput.contorollerState.Circle||
            Input.GetMouseButtonDown(1))
        {
            //if(SceneManager.GetActiveScene().name == "Main")
            //{
            //    LoadScene(SceneController.SceneName.Result,true);
            //}
            if (SceneManager.GetActiveScene().name == "Title")
            {
                LoadScene(SceneController.SceneName.Main, true);
            }
            //if(SceneManager.GetActiveScene().name == "Result")
            //{
            //    LoadScene(SceneController.SceneName.Title, true);
            //}
            return;
        }
        //if (Input.GetKey(KeyCode.Escape)) SceneController.Instance.Quit();
        //if (Input.GetKey(KeyCode.Space))
        //{
        //    if (SceneManager.GetActiveScene().name == "Title")
        //    {
        //        LoadScene(SceneController.SceneName.Main, true);
        //    }
        //    return;
        //}
    }
    /// <summary>
    /// <para>シーン遷移</para>
    /// <para>フェードなし: LoadScene(SceneControl.SceneName.シーン名); </para>
    /// <para>1秒間のフェードあり: LoadScene(SceneControl.SceneName.シーン名, true); </para>
    /// <para>2秒間のフェードあり: LoadScene(SceneControl.SceneName.シーン名, true, 2.0f); </para>
    /// </summary>
    /// <param name="scene">遷移先のシーン</param>
    /// <param name="isFade">フェードを実行する場合はtrue</param>
    /// <param name="interval">フェード開始から終了までの時間(秒)<para>0秒以下ならフェードなしとして実行</para></param>
    /// <param name="unityAction">画面が完全に暗くなったタイミングで実行したい処理<para>フェードを実行した場合のみ有効</para></param>
    public void LoadScene(SceneName scene, bool isFade = false, float interval = 1.0f,
        UnityEngine.Events.UnityAction unityAction = null)
    {
        if (isFading) return;
        StartCoroutine(SceneChange(scene, isFade, interval, unityAction));
    }
    public enum SceneName
    {
        Title = 0,
        Main,
        Result
    }
}