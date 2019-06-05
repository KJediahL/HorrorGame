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
    bool alerted = false;
    float soundFXcounter = 19;

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

            soundFXcounter -= 1;
            if(soundFXcounter <= 0 && alerted == true)
            {
                soundFXcounter = Random.Range(10.0f, 500.0f);
                alertSoundEffect.Play();
            }
            Debug.Log("searching");
            enemy.LookAt(player);
            if (Physics.Raycast(transform.position, transform.forward, out hit))
            {
                Debug.Log("raycast sent");
                if (hit.collider.tag == "Player")
                {

                    alerted = true;
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