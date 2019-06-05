using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    float counter = 0;
    
    public GameObject Enemy;
    public AudioSource playerhit;
    float soundFXcounter = 0;
   
    void FixedUpdate()
    {
        Debug.Log(soundFXcounter);
        if(soundFXcounter != 0)
        {
            soundFXcounter -= 1;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Player")
        {
            GameObject.Find("Player").GetComponent<Character>().health -= 16;
            if(soundFXcounter == 0)
            {
                playerhit.Play();
                soundFXcounter = 50;
            }


            //Debug.Log(GameObject.Find("Player").GetComponent<Character>().health);
        }
    }

    void OnTriggerExit(Collider other)
    {

    }

    void OnTriggerStay(Collider other)
    {
        
        if (other.tag == "Player")
        {
            if (counter > 49)
            {
                GameObject.Find("Player").GetComponent<Character>().health -= 16;
               // Debug.Log(GameObject.Find("Player").GetComponent<Character>().health);
            

                counter = 0;
            }
            else
            {
                counter += 1;
            }
        }
    }
}
