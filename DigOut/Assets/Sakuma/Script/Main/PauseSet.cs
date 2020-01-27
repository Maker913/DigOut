using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PauseSet : MonoBehaviour
{

    [SerializeField]
    Text gold;
    [SerializeField]
    Text silver;
    [SerializeField]
    Text copper;
    [SerializeField]
    Text LV;
    [SerializeField]
    Text Pow;

    [SerializeField]
    Text dynamite;
    [SerializeField]
    GameObject drill;
    [SerializeField]
    Text heel;

    // Update is called once per frame
    void Update()
    {
        gold.text = ItemList.itemList.gold.ToString();
        silver .text = ItemList.itemList.silver .ToString();
        copper.text = ItemList.itemList.copper.ToString();
        LV.text = ItemList.itemList.iceaxLevel .ToString();
        Pow.text = MainStateInstance.mainStateInstance.Pow.ToString();
            dynamite.text = ItemList.itemList.dynamite.ToString();

        

        drill.SetActive(!ItemList.itemList.drill);
        heel.text = ItemList.itemList.heel.ToString();

    }
}
