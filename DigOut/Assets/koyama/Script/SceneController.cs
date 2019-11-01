using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController Instance;

    public enum SceneName
    {
        //タイトル
        Title = 0,
        //メイン
        Main,
        //リザルト
        Result
    }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    /// <summary>
    /// <para>シーン遷移<para>
    /// <para>LoadScene(SceneController.SceneName.シーン名)<para>
    /// </summary>
    /// <param>name="scene">遷移先のシーン<param>
    public void SceneChange(SceneName scene)
    {
        SceneManager.LoadScene((int)scene);
    }
}