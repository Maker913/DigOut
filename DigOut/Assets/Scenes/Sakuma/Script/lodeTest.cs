using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class lodeTest : MonoBehaviour
{
    public string text;
    public string[] m_scenarios;

    public GameObject[] preList;
    [SerializeField]
    private GameObject p;
    // Start is called before the first frame update
    void Start()
    {
        ReadText("LogData");
        m_scenarios=text.Split(new string[] { ";" }, System.StringSplitOptions.None);
        for (int i = 0; i < m_scenarios.Length -1; i++)
        {
            string[] pass= m_scenarios[i].Split(new string[] { "," }, System.StringSplitOptions.None);
            Instantiate(preList[int.Parse(pass[0])],new Vector3 (float.Parse(pass[1]), float.Parse(pass[2]),0),Quaternion.identity ,p.transform );
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ReadText(string fileName)
    {
        var scenarioText = Resources.Load<TextAsset>("Scenarios/" + fileName);
        if (scenarioText == null)
        {
            Debug.LogError("シナリオファイルが見つかりません。");
            return;
        }

        text = scenarioText.text;//.Split(new string[] { "\n" }, System.StringSplitOptions.None);
        Resources.UnloadAsset(scenarioText);
    }

}
