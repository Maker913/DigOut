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
    private void Update()
    {
        if (PS4ControllerInput.pS4ControllerInput.contorollerState.Circle)
        {
            Debug.Log("行けた");
            StartButton();
        }
        if (Input.GetMouseButtonDown(1))
        {
            SoundController.Instance.PlayBGM(0);
            Debug.Log("流れ");
        }
    }
    public void StartButton()
    {
        SceneController.Instance.LoadScene(SceneController.SceneName.Main,true);
    }
    /*
    public void Button()
    {
        SceneController.Instance.SceneChange(SceneController.SceneName.Main);
    }*/
}
