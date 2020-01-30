using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastItem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (!MainStateInstance.mainStateInstance.lastItem)
        {
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag.ToString() == "Player" )
        {

            StoryManager.storyManager.StoryLoad("ItemGet");
            Progression.progression.num++;
            MainStateInstance.mainStateInstance.lastItem = false;
            Destroy(gameObject);

        }
    }
}
