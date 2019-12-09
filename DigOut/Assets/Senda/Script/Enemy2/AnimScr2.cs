using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimScr2 : MonoBehaviour
{
    public GameObject Enemy2;

    Enemy2 script;

    // Start is called before the first frame update
    void Start()
    {
        script = Enemy2.GetComponent<Enemy2>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.tag == "Player")
        {

            script.Searching();
            Debug.Log("Hit");
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        
        if (other.tag == "Player")
        {
            script.Waiting();
            Debug.Log("Out");
        }
    }
}
