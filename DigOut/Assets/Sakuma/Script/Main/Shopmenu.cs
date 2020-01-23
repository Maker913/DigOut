using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shopmenu : MonoBehaviour
{
    int select = 0;
    [SerializeField]
    RectTransform Casol;
    [SerializeField]
    Text[] texts;
    [SerializeField]
    Text comment;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        texts[0].text = ItemList.itemList.gold.ToString();
        texts[1].text = ItemList.itemList.silver.ToString();
        texts[2].text = ItemList.itemList.copper.ToString();
        texts[3].text = ItemList.itemList.dynamite.ToString();
        texts[4].text = ItemList.itemList.heel.ToString();

        switch (select)
        {
            case 0:
                Casol.localPosition = new Vector3(0, 250, 0);
                break;
            case 1:
                Casol.localPosition = new Vector3(0, 150, 0);
                break;
        }
        if (PS4ControllerInput.pS4ControllerInput.contorollerState.singleUp|| PS4ControllerInput.pS4ControllerInput.contorollerState.singleDown)
        {
            select += 1;
            if(select > 1)
            {
                select = 0;
            }
        }
        if (PS4ControllerInput.pS4ControllerInput.contorollerState.singleCircle)
        {
            switch (select)
            {
                case 0:
                    if(ItemList.itemList.gold >= 1 && ItemList.itemList.copper >= 1)
                    {
                        ItemList.itemList.gold--;
                        ItemList.itemList.copper--;
                        ItemList.itemList.dynamite+=5;
                        comment.text = "まいどあり！";
                    }
                    else
                    {
                        comment.text = "材料が足りないみたいだぜ？";
                    }
                    break;
                case 1:
                    if (ItemList.itemList.gold >= 1 && ItemList.itemList.silver >= 1)
                    {
                        ItemList.itemList.gold--;
                        ItemList.itemList.silver--;
                        ItemList.itemList.heel++;
                        comment.text = "まいどあり！";
                    }
                    else
                    {
                        comment.text = "材料が足りないみたいだぜ？";
                    }
                    break;
            }
        }

    }
}
