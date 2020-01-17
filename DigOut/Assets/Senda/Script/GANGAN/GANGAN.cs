using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GANGAN : MonoBehaviour
{
    public float dy;

    bool Turn = false;
    [SerializeField]
    Rigidbody2D rigidbody2;
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


    void FixedUpdate()
    {
        if (!Turn)
        {
            rigidbody2.transform.position += new Vector3(0, dy * Time.fixedDeltaTime, 0);
        }
        if (Turn)
        {
            rigidbody2.transform.position -= new Vector3(0, dy * Time.fixedDeltaTime, 0);
        }
    }
}
