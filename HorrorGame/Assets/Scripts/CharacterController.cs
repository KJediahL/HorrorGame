using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    // Values for Movement
    public float speed = 10f;

    // Values for Jumping
    private Rigidbody rb;
    public float jumpforce = 5f;

    // Values to check if grounded
    public bool IsGrounded;
    public float hitdistance;
    public LayerMask layer;

    void Start()
    {
        // Hides and centers the cursor in the middle of the screen
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;

    }

    void FixedUpdate()
    {
        PlayerStatus();
        PlayerMovement();
        PlayerJumping();

        // Shows cursor and allows movement of cursor
        if (Input.GetKeyDown("escape"))
            Cursor.lockState = CursorLockMode.None;
    }


    void PlayerMovement()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float straffe = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        straffe *= Time.deltaTime;

        transform.Translate(straffe, 0, translation);
    }

    void PlayerJumping()
    {
        if (IsGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
        }
    }

    void PlayerStatus()
    {
        if (IsGrounded)
            hitdistance = 0.35f;
        else
            hitdistance = 0.15f;

        if (Physics.Raycast(transform.position - new Vector3(0, 0.85f, 0), -transform.up, hitdistance, layer))
            IsGrounded = true;
        else
            IsGrounded = false;
    }
}