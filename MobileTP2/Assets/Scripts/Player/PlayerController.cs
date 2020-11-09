using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Camera playerCamera;
    Rigidbody playerRigidbody;
    private bool canJump;
    public float speed;
    public float horizontalSpeed;
    float acceleration;
    const float CameraPosX = 0f;
    const float CameraPosY = -1.74f;
    const float CameraPosZ = -4.42f;
    int lives;
    public bool gameOver = false;


    const int MaxLives = 3;
    // Start is called before the first frame update
    void Start()
    {
        RestartCamPos();
        gameOver = false;
        Time.timeScale = 1f;
        lives = MaxLives;
        acceleration = 0;
        playerRigidbody = GetComponent<Rigidbody>();
        canJump = true;
    }
    void Update()
    {
        if(transform.position.y <= -2 )
        {
            lives--;
            transform.position = new Vector3(0, 0, 0);
            transform.rotation = new Quaternion(0, 0, 0, 0);
        }

        if(acceleration < speed)
        {
            acceleration += speed / 5 * Time.deltaTime;
        }
        if(lives <0)
        {
            gameOver = true;
            Time.timeScale = 0f;
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

    public void Restart()
    {
        Time.timeScale = 1f;
        lives = MaxLives;
        acceleration = 0;
        canJump = true;
        RestartCamPos();
    }

    public void RestartCamPos()
    {
        playerCamera.transform.position = new Vector3(CameraPosX, CameraPosY, CameraPosZ);
    }
}
