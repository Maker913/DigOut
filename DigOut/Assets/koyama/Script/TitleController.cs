using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleController : MonoBehaviour
{
    [SerializeField]
    private SceneController.SceneName scene;
    void Start()
    {
        
    }
    public void Button()
    {
        SceneController.Instance.SceneChange(scene);
    }
}
