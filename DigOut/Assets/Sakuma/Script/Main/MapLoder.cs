using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLoder : MonoBehaviour
{
    [SerializeField]
    GameObject[] mapObj;

    RectTransform[] rectTransforms;
    RectTransform thistrans;
    int num;
    Vector3 movePos=Vector3.zero ;
    Vector3  spead;
    // Start is called before the first frame update
    void Start()
    {
        num = 0;
        thistrans = GetComponent<RectTransform>();
        rectTransforms = new RectTransform[mapObj.Length];
        for (int i = 0; i < mapObj.Length; i++)
        {
            rectTransforms[i] = mapObj[i].GetComponent<RectTransform>();
        }
        mapObj[MainStateInstance.mainStateInstance.mainState.nowArea].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(num != MainStateInstance.mainStateInstance.mainState.nowArea)
        {
            mapObj[MainStateInstance.mainStateInstance.mainState.nowArea].SetActive(true);
            Debug.Log(MainStateInstance.mainStateInstance.mainState.nowArea);
            movePos = -rectTransforms[MainStateInstance.mainStateInstance.mainState.nowArea].anchoredPosition3D;

        }

        thistrans.anchoredPosition3D =Vector3.SmoothDamp(thistrans.anchoredPosition3D, movePos, ref spead , 0.25f, 1000);

        num = MainStateInstance.mainStateInstance.mainState.nowArea;
    }
}
