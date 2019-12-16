using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Info : MonoBehaviour
{
    Vector3 mainPos;
    Vector3 backPos;
    [SerializeField]
    string[] infoText;
    Text info;
    // Start is called before the first frame update
    void Start()
    {
        mainPos = transform.position;
        backPos = mainPos + new Vector3 (-600,0,0);

        info = GetComponent<Text>();
        backNum = Progression.progression.num;
        InfoSet();
    }


    float nows=0;
    int backNum=0;
    
    // Update is called once per frame
    void Update()
    {

        if (MainStateInstance.mainStateInstance.mainState.gameMode == MainStateInstance.GameMode.Play) {
            float movex = Mathf.SmoothDamp(info.color.a, 1.0f, ref nows, 1f);
            //transform.position = new Vector3(movex, transform.position.y, transform.position.z);
            info.color = new Color (1,1,1, movex);
            if (Input.GetKeyDown(KeyCode.F)) {
                InfoSet();
            }

            if(backNum != Progression.progression.num) {
                InfoSet();
            }

            backNum = Progression.progression.num;

        }
        else {
            info.color = new Color(1, 1, 1, 0);
        }





    }

    void InfoSet() {
        //transform.position = backPos;
        info.color = new Color(1, 1, 1, 0);
        info.text = infoText[Progression.progression.num];
    }



}
