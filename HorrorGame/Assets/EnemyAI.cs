using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

public class EnemyAI : MonoBehaviour
{
    Ray Detect;
    public Color rayColor;
    private NavMeshAgent EnemyNav;
    bool follow = false;
    public GameObject target;
    public Transform player;
    public GameObject Enemy;
    public float previousRotateX;
    public float previousRotateY;
    public float previousRotateZ;
    public float counter;
    /*Transform player;               // Reference to the player's position.
    public NavMeshAgent nav;               // Reference to the nav mesh agent.
    private SphereCollider col;
    public Transform personalTransform;
    public float fieldOfViewAngle = 110f;
    public bool playerInSight;
    public Transform personalLastSighting;
    public SphereCollider Collider;

    private Vector3 previousLastSighting;
    */
    void Awake()
    {
        EnemyNav = GetComponent<NavMeshAgent>();
        
        /*
        nav = GetComponent<NavMeshAgent>();
        col = GetComponent<SphereCollider>();
        personalTransform = GetComponent<Transform>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerInSight = true;
        */
    }


    private void Update()
    {
        //Detect = new Ray(transform.position, transform.forward * 10);
        //Debug.DrawRay(transform.position, transform.forward * 10, rayColor); // For testing the ray cast
        RaycastHit hit;

        
        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if(hit.collider.tag == "Player")
            {
                follow = true;
            }
        }
        else if (Physics.Raycast(transform.position, -transform.forward, out hit))
        {
            if (hit.collider.tag == "Player")
            {
                follow = true;
            }
        }
        else if (Physics.Raycast(transform.position, transform.right, out hit))
        {
            if (hit.collider.tag == "Player")
            {
                follow = true;
            }
        }
        else if (Physics.Raycast(transform.position, -transform.right, out hit))
        {
            if (hit.collider.tag == "Player")
            {
                follow = true;
            }
        }
        else
        {
            follow = false;
        }


        if (follow == true)
        {
            EnemyNav.SetDestination(player.position);
        }
        else
        {
            search();
        }
        /*
        if (playerInSight == false)
        {
            nav.SetDestination(personalTransform.position);
        }
        else
        {
            nav.SetDestination(player.position);
        }
        */



    }

    public void search()
    {
        counter = 0;
        previousRotateX = Enemy.transform.rotation.x;
        previousRotateY = Enemy.transform.rotation.y;
        previousRotateZ = Enemy.transform.rotation.z;
        while(true)
        {
            Enemy.transform.rotation = Quaternion.Euler(previousRotateX + counter, previousRotateY, previousRotateZ);
            counter = counter + 1;
            if(counter == 90 || follow == true)
            {
                break;
            }
            

        }
        
    }
       
    /*
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == player)
        {
            playerInSight = false;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject == player)
        {
            playerInSight = false;

            Vector3 direction = other.transform.position - transform.position;
            float angle = Vector3.Angle(direction, transform.forward);

            if(angle < fieldOfViewAngle * 0.5f)
            {
                RaycastHit hit;
                if(Physics.Raycast(transform.position + transform.up, direction.normalized, out hit, col.radius))
                {
                    if(hit.collider.gameObject == player)
                    {
                        playerInSight = true;
                        personalLastSighting.position = player.transform.position;
                    }
                }
            }
        }
    }
    */
}

