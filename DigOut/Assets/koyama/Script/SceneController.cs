using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController Instance;
    public enum SceneName
    {
        Title = 0,
        Main,
        Result
    }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void SceneChange(SceneName scene)
    {
        SceneManager.LoadScene((int)scene);
    }
}