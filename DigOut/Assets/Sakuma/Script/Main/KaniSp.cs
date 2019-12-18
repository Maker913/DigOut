using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class KaniSp : MonoBehaviour
{
    [SerializeField]
    GameObject kaniPre;
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "MainAction")
        {
            Instantiate(kaniPre,transform.position ,Quaternion.identity);
            gameObject.SetActive(false);
        }



    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
