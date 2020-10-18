using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody playerRigidbody;
    private bool canJump;
    public float velocity;
    public float horizontalSpeed;
    // Start is called before the first frame update
    void Start()
    {
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
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.acceleration.x > 0 ||Input.acceleration.x < 0 )
        {
            playerRigidbody.AddForce(Input.acceleration.x * horizontalSpeed, 0, 0);
        }

        transform.Translate(Vector3.forward * Time.deltaTime * velocity);
        ManageJump();
        
    }

    void ManageJump()
    {
        if (Input.touchCount > 0)
        {
            Touch PlayerTouch = Input.GetTouch(0);
            if ( PlayerTouch.phase == TouchPhase.Began && canJump && transform.position.y <= 0)
            {
                playerRigidbody.AddForce(new Vector3(0, 40, 0), ForceMode.Impulse);
                canJump = false;
            }
            else if (PlayerTouch.phase == TouchPhase.Ended && !canJump)
            {
                canJump = true;
            }
        }
    }
}
