using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GANGAN : MonoBehaviour
{
    public float dy;

    bool Turn = false;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "0")
        {
            Turn = !Turn;
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }


    void Update()
    {
        if (Turn == false)
        {
            this.transform.position += new Vector3(0, dy * Time.deltaTime, 0);
        }
        if (Turn == true)
        {
            this.transform.position -= new Vector3(0, dy * Time.deltaTime, 0);
        }
    }
}
