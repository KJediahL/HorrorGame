using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bed1 : MonoBehaviour
{
    public Transform player;
    bool onBed = false;
    public CharacterController control;
    private void Start()
    {

    }

    void FixedUpdate()
    {
        if (onBed == true)
        {
            Debug.Log("test2");
            control.enabled = false;
            SceneManager.LoadScene("Catacombs");


            control.enabled = true;
            onBed = false;
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("test1");
            onBed = true;

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("test3");
            onBed = false;

        }
    }
}