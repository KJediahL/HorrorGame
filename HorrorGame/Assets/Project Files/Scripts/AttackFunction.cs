using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackFunction : MonoBehaviour
{
    public bool fired = false;
    RaycastHit hit;
    string enemyname;
    public AudioSource gunshot;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && fired == false)
        {
            gunshot.Play();
            if (Physics.Raycast(transform.position, transform.forward, out hit))
            {
                Debug.DrawRay(transform.position, transform.forward);
                if (hit.collider.tag == "Enemy")
                {
                    Debug.Log("hitenemy");
                    enemyname = hit.collider.name;
                    GameObject.Find(enemyname).GetComponent<EnemyHealth>().health -= 1;
                }
            }

            fired = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            fired = false;
        }
    }
}