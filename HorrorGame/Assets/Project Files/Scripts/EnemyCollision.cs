using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    float counter = 0;

    public float health = 3;
    public GameObject Enemy;

    private void FixedUpdate()
    {
        if (health <= 0)
        {
            Destroy(Enemy);
        }
    }

    private void Start()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("test");
        if (other.tag == "Player")
        {
            GameObject.Find("Player").GetComponent<Character>().health -= 16;
        }
    }

    void OnTriggerExit(Collider other)
    {

    }

    void OnTriggerStay(Collider other)
    {
        Debug.Log("test");
        if (other.tag == "Player")
        {
            if (counter > 49)
            {
                GameObject.Find("Player").GetComponent<Character>().health -= 16;
                counter = 0;
            }
            else
            {
                counter += 1;
            }
        }
    }
}
