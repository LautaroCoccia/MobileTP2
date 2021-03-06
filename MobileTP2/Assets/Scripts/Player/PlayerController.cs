﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Camera playerCamera;
    Rigidbody playerRigidbody;
    private bool canJump;
    public float jumpForce;
    public float speed;
    public float horizontalSpeed;
    int lives;
    public LevelManager lvlManager;

    const float CameraPosX = 0f;
    const float CameraPosY = 1.74f;
    const float CameraPosZ = -4.42f;
    const int MaxLives = 3;
    const int MinLives = 1;
    const float MaxFall = -0.75f;

    //ESTA HECHO ASI A PROPOSITO 
    const float ExponentialSpeedEditor = 7.5f;
    const float ExponentialSpeedAndroid = 20.0f;
    void Start()
    {
        SetCamPos();
        Time.timeScale = 1f;
        lives = MaxLives;
        playerRigidbody = GetComponent<Rigidbody>();
        canJump = true;
    }
    void Update()
    {
        if (transform.position.y <= MaxFall)
        {
            Fall();
        }
        if(lives < MinLives)
        {
            lvlManager.Lose();
        }
    }
    void FixedUpdate()
    {
        playerRigidbody.AddForce(0, 0, speed * Time.deltaTime);
#if UNITY_EDITOR
        PlayerMovementEditor();
        ManageJumpEditor();

#elif UNITY_ANDROID
        PlayerMovementAndroid();
        ManageJumpAndroid();
#endif

    }

    private void ManageJumpAndroid()
    {
        
        if (Input.touchCount > 0 && canJump)
        {
            Touch PlayerTouch = Input.GetTouch(0);
            if ( PlayerTouch.phase == TouchPhase.Began && canJump && transform.position.y <= 0)
            {
                Jump();
            }
        }
    }
    private void PlayerMovementAndroid()
    {
        if(Input.acceleration.x == 0)
        {
            PlayerMovement(0);
        }
        else if (Input.acceleration.x > 0 || Input.acceleration.x < 0 )
        {
            //ESTA HECHO ASI A PROPOSITO
            PlayerMovement(Input.acceleration.x * ExponentialSpeedAndroid * horizontalSpeed);
        }
    }
    private void ManageJumpEditor()
    {
        if(Input.GetKeyDown("up")&& canJump)
        {
            Jump();
        }
    }
    private void PlayerMovementEditor()
    {

        if (Input.GetKey("right") || (Input.GetKey("left")))
        {
            //ESTA HECHO ASI A PROPOSITO
            PlayerMovement(Input.GetAxis("Horizontal") * horizontalSpeed * ExponentialSpeedEditor);
        }
        
        else
        {
            PlayerMovement(0);
        }
    }

    private void PlayerMovement(float x)
    {
        playerRigidbody.AddForce(x * Time.deltaTime, 0, speed * Time.deltaTime);
    }
    private void Jump()
    {

        canJump = false;
        playerRigidbody.AddForce(new Vector3(0, jumpForce * Time.deltaTime, 0), ForceMode.Impulse);
    }

    private void Fall()
    {
        lives--;
        SetCamPos();
        transform.position = Vector3.zero;
        transform.rotation = new Quaternion(0, 0, 0, 0);
    }
    private void SetCamPos()
    {
        playerCamera.transform.position = new Vector3(CameraPosX, CameraPosY, CameraPosZ);
    }
    public void SetCanJump(bool CanJump)
    {
        canJump = CanJump;
    }
    public void RestartPlayer()
    {
        SetCamPos();
        Time.timeScale = 1f;
        lives = MaxLives;
        canJump = true;
        transform.position = Vector3.zero;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Ground")
        {
            canJump = true;
        }
        if (collision.transform.tag == "FinishLine")
        {
            lvlManager.Win();
        }
        if (collision.transform.tag == "Checker")
        {
            Fall();
        }
    }




}
