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

    public StageMakeController stageMake;
    void Start()
    {
        angle.text = "0";
        X.text = "1";
        Y.text = "1";
        name.text = stageMake.fileName;
    }
    private void Update()
    {
        stageMake.fileName= name.text;
    }
}
