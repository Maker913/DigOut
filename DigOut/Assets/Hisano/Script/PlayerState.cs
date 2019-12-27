using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerState : MonoBehaviour
{
    int playerNowHP;
    [SerializeField]
    int playerMaxHP = 100;

    int[] itemList = new int[3];
    [System.Serializable]
    public struct Item
    {
        public string name;
        public Sprite uiSprite;
    }
    
    public Item[] items;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Damage(int damageHP)
    {
        playerNowHP -= damageHP;
    }

}
