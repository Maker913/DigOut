using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GANGAN : MonoBehaviour
{
    public float dy;

    bool Turn = false;
    [SerializeField]
    Rigidbody2D rigidbody2;
    [SerializeField]
    LayerMask layerMask;
    // Start is called before the first frame update
    void Start()
    {

    }


    void FixedUpdate()
    {
        if(Physics2D.Raycast (transform.position,!Turn ? Vector2.up: Vector2.down, 2, layerMask))
        {
            Turn = !Turn;
        }







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
