using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemList : MonoBehaviour
{

    public int copper;
    public int silver;
    public int gold;

    public int dynamite;
    public bool drill;
    public int heel;

    public int iceaxLevel;




    static public ItemList itemList;




    private void Awake()
    {
        if(itemList == null)
        {


            DontDestroyOnLoad(gameObject);
            itemList = this;

           itemList.StartSet();



        }
        else
        {
            Destroy(this);
        }
    }



    void StartSet()
    {
        copper=0;
        silver=0;
        gold=0;

        dynamite= 0;
        drill=false ;
        heel=0 ;

        iceaxLevel = 1;
    }




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
