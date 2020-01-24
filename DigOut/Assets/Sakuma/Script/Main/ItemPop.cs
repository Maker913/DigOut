using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItemPop : MonoBehaviour
{
    [SerializeField]
    Text dy;
    [SerializeField]
    Text heel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(MainStateInstance.mainStateInstance.mainState.gameMode ==MainStateInstance.GameMode.Play)
        {
            dy.text = ItemList.itemList.dynamite.ToString();
            heel.text = ItemList.itemList.heel.ToString();
        }
    }
}
