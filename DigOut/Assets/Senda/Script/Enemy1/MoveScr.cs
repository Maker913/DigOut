using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScr : MonoBehaviour
{
    public GameObject Enemy1;

    Enemy1 script;
    // Start is called before the first frame update
    void Start()
    {
        script = Enemy1.GetComponent<Enemy1>();
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
