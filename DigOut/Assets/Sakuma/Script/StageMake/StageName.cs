using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StageName : MonoBehaviour
{
    InputField inputField;

    public Text stagename;
    // Start is called before the first frame update
    void Start()
    {
        inputField = GetComponent<InputField>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayText()
    {
        stagename.GetComponent<Text>().text = inputField.text;
    }
}
