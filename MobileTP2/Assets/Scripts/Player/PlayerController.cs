﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody playerRigidbody;
    private bool canJump;
    public float speed;
    public float horizontalSpeed;
    float acceleration;
    // Start is called before the first frame update
    void Start()
    {
        acceleration = 0;
        playerRigidbody = GetComponent<Rigidbody>();
        canJump = true;
    }
    void Update()
    {
        if(transform.position.y <= -2 )
        {
            transform.position = new Vector3(0, 0, 0);
            transform.rotation = new Quaternion(0, 0, 0, 0);
        }

        if(acceleration < speed)
        {
            acceleration += speed / 5 * Time.deltaTime;
        }
    }
    void FixedUpdate()
    {
        PlayerMovement();
        ManageJump();
        
    }

    void ManageJump()
    {
        if (Input.touchCount > 0 && canJump)
        {
            Touch PlayerTouch = Input.GetTouch(0);
            if ( PlayerTouch.phase == TouchPhase.Began && canJump && transform.position.y <= 0)
            {
                canJump = false;
                playerRigidbody.AddForce(new Vector3(0, 50, 0), ForceMode.Impulse);
                
            }
        }
    }
    void PlayerMovement()
    {
        if(Input.acceleration.x == 0)
        {
            playerRigidbody.AddForce(0, 0, acceleration);
        }
        else if (Input.acceleration.x > 0 || Input.acceleration.x < 0 )
        {
            playerRigidbody.AddForce(Input.acceleration.x * horizontalSpeed, 0, acceleration);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Ground")
        {
            canJump = true;
        }
    }
}
