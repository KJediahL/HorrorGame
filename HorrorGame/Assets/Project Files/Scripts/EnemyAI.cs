using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

public class EnemyAI : MonoBehaviour
{
    public Transform player;               // Reference to the player's position.
    public NavMeshAgent nav;               // Reference to the nav mesh agent.
    public Transform enemy;
    public AudioSource alertSoundEffect;
    public float fieldOfViewAngle = 110f;
    public bool playerInSight;
    public Vector3 personalLastSighting;
    public SphereCollider Collider;
    bool searching = false;
    RaycastHit hit;

    void Awake()
    {
        Debug.Log("work at all?");
        personalLastSighting = enemy.localPosition;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }


    void Update()
    {
        if (searching == true)
        {
            Debug.Log("searching");
            enemy.LookAt(player);
            if (Physics.Raycast(transform.position, transform.forward, out hit))
            {
                Debug.Log("raycast sent");
                if (hit.collider.tag == "Player")
                {
                        nav.SetDestination(player.position);
                        personalLastSighting = player.localPosition;
            
                }
            }
            else
            {
                Debug.Log("nolongerfound");
                nav.SetDestination(personalLastSighting);
            }
           



        }
    }

    void OnTriggerEnter(Collider other)
    {
            /*Debug.Log(other);*/
            if (other.tag == "Player")
            {
                alertSoundEffect.Play();
                Debug.Log("playerenter");
                searching = true;
            }
    }
        
    void OnTriggerExit(Collider other)
    {
            if (other.tag == "Player")
            {
                Debug.Log("playerexit");
                searching = false;
            }
    }
}