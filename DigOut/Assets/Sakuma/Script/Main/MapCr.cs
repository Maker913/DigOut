using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCr : MonoBehaviour
{
    [System.Serializable]
    public  struct MapData
    {
        public  string name;
        public  GameObject mapObj;

    }

    [SerializeField]
    MapData[] mapDatas;


    // Start is called before the first frame update
    void Start()
    {
        string stagename;
        stagename = MainStateInstance.mainStateInstance.stageName;

        for (int i=0; i < mapDatas.Length ; i++){

            if(mapDatas [i].name ==stagename)
            {
                Instantiate(mapDatas[i].mapObj, transform); 
            }

        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
