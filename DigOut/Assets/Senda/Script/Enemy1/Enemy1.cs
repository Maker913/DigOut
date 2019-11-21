using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    public GameObject chi;

    public Material Search;

    public Material Wait;

    public Material Move;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
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
        Destroy(chi);

    }
}
