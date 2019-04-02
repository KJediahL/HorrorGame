using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

public class EnemyAI : MonoBehaviour
{
    Transform player;               // Reference to the player's position.
    public NavMeshAgent nav;               // Reference to the nav mesh agent.
    public float fieldOfViewAngle = 110f;
    public bool playerInSight;
    public Vector3 personalLastSighting;
    public SphereCollider Collider;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }


    void Update()
    {
        nav.SetDestination(player.position);
        
    }
}