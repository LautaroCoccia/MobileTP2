using System.Collections;
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
    public bool gameOver = false;
    float acceleration = 0;
    int lives;
    
    const float CameraPosX = 0f;
    const float CameraPosY = 1.74f;
    const float CameraPosZ = -4.42f;

    const int MaxLives = 3;
    // Start is called before the first frame update
    void Start()
    {
        RestartCamPos();
        gameOver = false;
        Time.timeScale = 1f;
        lives = MaxLives;
        playerRigidbody = GetComponent<Rigidbody>();
        canJump = true;
    }
    void Update()
    {
        if (transform.position.y <= -0.75f )
        {
            Fall();
        }
        if(lives <0)
        {
            gameOver = true;
            Time.timeScale = 0f;
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
            PlayerMovement(Input.acceleration.x * 20 * horizontalSpeed);
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
            PlayerMovement(Input.GetAxis("Horizontal") * horizontalSpeed * 7.5f );
        }
        
        else
        {
            PlayerMovement(0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Ground")
        {
            canJump = true;
        }
        if (collision.transform.tag == "Checker")
        {
            Fall();
        }
        if (collision.transform.tag == "FinishLine")
        {
            Time.timeScale = 0;
        }
    }
    public void Restart()
    {
        RestartCamPos();
        Time.timeScale = 1f;
        lives = MaxLives;
        canJump = true;
        transform.position = new Vector3(0, 0, 0);
    }
    private void RestartCamPos()
    {
        playerCamera.transform.position = new Vector3(CameraPosX, CameraPosY, CameraPosZ);
    }
    public bool GetGameOver()
    {
        return gameOver;
    }
    private void Jump()
    {
        
        canJump = false;
        playerRigidbody.AddForce(new Vector3(0, jumpForce * Time.deltaTime , 0), ForceMode.Impulse);
    }

    private void Fall()
    {
        lives--;
        RestartCamPos();
        transform.position = new Vector3(0, 0, 0);
        transform.rotation = new Quaternion(0, 0, 0, 0);
    }

    private void PlayerMovement(float x)
    {
        playerRigidbody.AddForce(x * Time.deltaTime, 0, speed * Time.deltaTime);
    }
    
}
