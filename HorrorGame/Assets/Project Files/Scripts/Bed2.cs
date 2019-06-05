using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bed2 : MonoBehaviour
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
            onBed = true;

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            onBed = false;

        }
    }
}