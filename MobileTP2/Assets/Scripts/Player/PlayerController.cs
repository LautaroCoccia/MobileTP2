using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float velocity;
    public float horizontalSpeed;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {   
        transform.Translate(Input.acceleration.x * Time.deltaTime * horizontalSpeed, 0, 0);
        transform.Translate(Vector3.forward * Time.deltaTime * velocity);
    }
}
