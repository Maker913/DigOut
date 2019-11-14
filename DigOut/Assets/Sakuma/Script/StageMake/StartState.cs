using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartState : MonoBehaviour
{
    public InputField name;
    public InputField angle;
    public InputField X;
    public InputField Y;

    public InputField moveX;
    public InputField moveY;

    public InputField area;
    public StageMakeController stageMake;
    void Start()
    {
        angle.text = "0";
        X.text = "1";
        Y.text = "1";
        name.text = stageMake.fileName;
        moveX.text = "0";
        moveY.text = "0";
        area.text = "0";
    }
    private void Update()
    {
        stageMake.fileName= name.text;
    }
}
