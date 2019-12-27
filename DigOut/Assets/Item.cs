using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    public int itemNum;     //0:銅 1:銀 2:金
    [SerializeField]
    float time;

    bool itemGet = false;

    // Start is called before the first frame update
    void Start()
    {
        if (itemNum == 3&&!MainStateInstance.mainStateInstance .toolBox )
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!itemGet)
        {
            time -= Time.deltaTime;
            if (time < 0)
            {
                itemGet = true;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag.ToString() == "Player" && itemGet == true)
        {
            switch (itemNum)
            {
                case 0:
                    ItemList.itemList.copper += 1;
                    Destroy(transform.parent.gameObject);
                    break;
                case 1:
                    ItemList.itemList.silver += 1;
                    Destroy(transform.parent.gameObject);
                    break;
                case 2:
                    ItemList.itemList.gold += 1;
                    Destroy(transform.parent.gameObject);
                    break;
                case 3:
                    StoryManager.storyManager.StoryLoad("ItemGet");
                    MainStateInstance.mainStateInstance.toolBox = false;
                    Destroy(gameObject);
                    break;
            }
        }
    }
}
