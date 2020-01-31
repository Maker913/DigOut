using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client : MonoBehaviour
{
    [SerializeField]
    Material material;
    bool text=false;
    float a=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (text)
        {
            if (a < 1)
            {
                a += Time.deltaTime*4;
            }
            else
            {
                a = 1;
            }
        }
        else
        {
            if (a > 0)
            {
                a -= Time.deltaTime*4;
            }
            else
            {
                a = 0;
            }
        }
        material.SetColor("_Color", new Color(1, 1, 1, a));


        if(MainStateInstance.mainStateInstance.mainState.gameMode == MainStateInstance.GameMode.Play&&PS4ControllerInput.pS4ControllerInput.contorollerState.singleCircle)
        {
            sw = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.ToString() == "Player")
        {
            text = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.ToString() == "Player")
        {
            text = false;
        }
    }

    bool sw = false;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision .gameObject.tag .ToString() == "Player"&&MainStateInstance.mainStateInstance.mainState.gameMode==MainStateInstance.GameMode.Play)
        {
            if (PS4ControllerInput.pS4ControllerInput.contorollerState.Circle&& !sw)
            {
                sw = true;
                switch (Progression .progression.num)
                {
                    case 0:
                        break;
                    case 1:
                        StoryManager.storyManager.StoryLoad("Investigating");
                        break;
                    case 2:
                        StoryManager.storyManager.StoryLoad("GradeUP");
                        break;
                    case 3:
                        StoryManager.storyManager.StoryLoad("Next");
                        break;
                    case 4:
                        StoryManager.storyManager.StoryLoad("Investigating2");
                        break;
                    case 5:
                        StoryManager.storyManager.StoryLoad("EndStory");
                        break;


                }
            }
        }
    }


}
