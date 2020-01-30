using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UIsw : MonoBehaviour
{
    [SerializeField]
    GameObject gameObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.SetActive(SceneManager.GetActiveScene().name == "MainAction");
    }
}
