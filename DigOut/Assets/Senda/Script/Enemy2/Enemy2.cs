using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    public GameObject chi;

    public Material Search;

    public Material Wait;

    public Material Move;

    public float speed;

    public float gravity;

    public bool nonVisibleAct;

    private Rigidbody2D rb = null;

    private SpriteRenderer sr = null;

    private bool rightTF = false;

    private bool MoveS = false;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (MoveS)
        {
            int yVector = -2;
            if (rightTF)
            {
                yVector = 1;
                transform.localScale = new Vector3(1, -2, 1);
            }
            else
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            rb.velocity = new Vector2(0, yVector);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("EnemyHit");
        if(rightTF)
        {
            rightTF = false;
        }
        else
        {
            rightTF = true;
        }
    }

    public void Waiting()
    {
        this.GetComponent<Renderer>().material = Wait;
    }

    public void Searching()
    {
        this.GetComponent<Renderer>().material = Search;
    }

    public void Moveing()
    {
        this.GetComponent<Renderer>().material = Move;
    }

    public void Starting()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
        MoveS = true;
    }
}
