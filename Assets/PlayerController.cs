using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class playermovemnt : MonoBehaviour
{
    private Rigidbody rb;
   
    private float movementX;
    private float movementY;
    public AudioSource Audio;

    public TMP_Text scoreText;
    private int scoreCounter;

   
    public float speed = 0;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
    }
    
    void OnMove(InputValue movementValue)
    {
        
        Vector2 movementVector = movementValue.Get<Vector2>();       
        movementX = movementVector.x;
        movementY = movementVector.y;
    }
    
    private void FixedUpdate()
    {
        // Get camera’s forward and right directions
        Vector3 camForward = Camera.main.transform.forward;
        Vector3 camRight = Camera.main.transform.right;

        // Ignore vertical tilt (keep movement on ground)
        camForward.y = 0;
        camRight.y = 0;
        camForward.Normalize();
        camRight.Normalize();

        // Calculate movement based on camera orientation
        Vector3 movement = camRight * movementX + camForward * movementY;

        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            audio.Play();
        }

    }

}

