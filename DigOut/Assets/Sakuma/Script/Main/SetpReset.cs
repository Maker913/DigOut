using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetpReset : MonoBehaviour
{
    static public string bfName = "";
    // Start is called before the first frame update
    private void Awake()
    {
        if (bfName == "Title")
        {
            if (MainStateInstance.mainStateInstance != null)
            {
                MainStateInstance.mainStateInstance.Life = 6;
                MainStateInstance.mainStateInstance.toolBox = true;
            }
            if (Progression.progression != null)
            {
                Progression.progression.num = 0;
                Progression.progression.startC = true;
            }
            if (ItemList.itemList != null)
            {
                ItemList.itemList.copper = 0;
                ItemList.itemList.silver  = 0;
                ItemList.itemList.gold = 0;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
