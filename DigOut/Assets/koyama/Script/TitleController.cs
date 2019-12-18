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
            SoundController.Instance.PlaySE(SoundController.SeName.Attack);
            Debug.Log("流れ");
        }
        if (Input.GetMouseButtonDown(2))
        {
            SoundController.Instance.PlaySE(SoundController.SeName.Damage);
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
