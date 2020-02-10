using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoguMogu : MonoBehaviour
{
    [SerializeField]
    Material material;
    bool text = false;
    float a = 0;
    [SerializeField]
    int mogunum;
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
                a += Time.deltaTime * 4;
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
                a -= Time.deltaTime * 4;
            }
            else
            {
                a = 0;
            }
        }
        material.SetColor("_Color", new Color(1, 1, 1, a));


        if (MainStateInstance.mainStateInstance.mainState.gameMode == MainStateInstance.GameMode.Play && PS4ControllerInput.pS4ControllerInput.contorollerState.singleCircle)
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
        if (collision.gameObject.tag.ToString() == "Player" && MainStateInstance.mainStateInstance.mainState.gameMode == MainStateInstance.GameMode.Play)
        {
            if (PS4ControllerInput.pS4ControllerInput.contorollerState.Circle && !sw)
            {
                sw = true;
                switch (mogunum)
                {
                    case 1:
                        if (MainStateInstance.mainStateInstance.moguFlg[0])
                        {
                            StoryManager.storyManager.StoryLoad("Mogu1b");
                        }
                        else
                        {
                            StoryManager.storyManager.StoryLoad("Mogu1f");
                            MainStateInstance.mainStateInstance.moguFlg[0] = true;
                            MainStateInstance.mainStateInstance.maxLife += 2;
                            MainStateInstance.mainStateInstance.Life += 2;
                        }
                        break;
                    case 2:
                        if (MainStateInstance.mainStateInstance.moguFlg[1])
                        {
                            StoryManager.storyManager.StoryLoad("Mogu2b");
                        }
                        else
                        {
                            StoryManager.storyManager.StoryLoad("Mogu2f");
                            MainStateInstance.mainStateInstance.moguFlg[1] = true;
                            MainStateInstance.mainStateInstance.maxLife += 2;
                            MainStateInstance.mainStateInstance.Life += 2;
                        }
                        break;
                    case 3:
                        if (MainStateInstance.mainStateInstance.moguFlg[2])
                        {
                            StoryManager.storyManager.StoryLoad("Mogu3b");
                        }
                        else
                        {
                            StoryManager.storyManager.StoryLoad("Mogu3f");
                            MainStateInstance.mainStateInstance.moguFlg[2] = true;
                            ItemList.itemList.copper  += 2;
                            ItemList.itemList.silver  += 2;
                            ItemList.itemList.gold += 2;
                        }
                        break;
                }
                
            }
        }
    }
}
