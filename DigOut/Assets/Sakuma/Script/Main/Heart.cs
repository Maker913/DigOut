using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    [SerializeField]
    GameObject[] image;

    public int mode;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (mode)
        {
            case 0:
                image[0].SetActive(false);
                image[1].SetActive(false);
                image[2].SetActive(true);
                break;
            case 1:
                image[0].SetActive(true);
                image[1].SetActive(true);
                image[2].SetActive(false);
                break;
            case 2:
                image[0].SetActive(true);
                image[1].SetActive(false);
                image[2].SetActive(false);
                break;
        }
    }

    public void LifeModeChange()
    {
        switch (mode)
        {
            case 0:
                image[0].SetActive(false);
                image[1].SetActive(false);
                image[2].SetActive(true);
                break;
            case 1:
                image[0].SetActive(true);
                image[1].SetActive(true);
                image[2].SetActive(false);
                break;
            case 2:
                image[0].SetActive(true);
                image[1].SetActive(false);
                image[2].SetActive(false);
                break;
        }
    }
}
