using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScr2 : MonoBehaviour
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
            script.Moveing();
            script.Starting();
            Debug.Log("Hit2");
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {

        if (other.tag == "Player")
        {
            Debug.Log("Out2");
        }
    }
}
