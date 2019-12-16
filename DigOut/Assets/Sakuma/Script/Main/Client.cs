using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision .gameObject.tag .ToString() == "Player"&&MainStateInstance.mainStateInstance.mainState.gameMode==MainStateInstance.GameMode.Play)
        {
            if(Input.GetKeyDown(KeyCode.Z))
            {
                switch (Progression .progression.num)
                {
                    case 0:
                        break;
                    case 1:
                        StoryManager.storyManager.StoryLoad("FirstRequest");
                        break;
                    case 2:
                        if(ItemList.itemList.gold >= 3)
                        {
                            ItemList.itemList.gold -= 3;
                            StoryManager.storyManager.StoryLoad("FirstRequestClear");
                        }
                        else
                        {
                            StoryManager.storyManager.StoryLoad("FirstRequestAfter");
                        }

                        break;


                }
            }
        }
    }


}
