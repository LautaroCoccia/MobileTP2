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

    // Update is called once per frame
    void Update()
    {   
        transform.Translate(Input.acceleration.x * Time.deltaTime * horizontalSpeed, 0, 0);
        transform.Translate(Vector3.forward * Time.deltaTime * velocity);
        ManageJump();
    }

    void ManageJump()
    {
        if (Input.touchCount > 0)
        {
            Touch PlayerTouch = Input.GetTouch(0);
            if (PlayerTouch.phase == TouchPhase.Began && canJump && transform.position.y <= 0)
            {
                canJump = false;
                transform.Translate(Vector3.up);
            }
            else if (PlayerTouch.phase == TouchPhase.Ended && !canJump)
            {
                canJump = true;
            }
        }
    }
}
