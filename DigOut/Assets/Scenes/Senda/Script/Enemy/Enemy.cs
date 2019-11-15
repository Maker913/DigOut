using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[ RequireComponent (typeof (NavMeshAgent))] public class Enemy : Controller2D
{
    public float DefMoveSpeed;

    public float MoveSpeed;

    private Rigidbody2D rigidbody2d;

    private Transform target;

    private NavMeshAgent agent;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
