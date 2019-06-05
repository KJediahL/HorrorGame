using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    

    public float health = 3;
    public GameObject Enemy;
    public AudioSource death;

    private void FixedUpdate()
    {
        if (health <= 0)
        {
            death.Play();
            Destroy(Enemy);
        }
    }

    private void Start()
    {

    }

    
}
