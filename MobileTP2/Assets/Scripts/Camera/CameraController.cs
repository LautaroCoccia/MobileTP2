using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 cameraPos;
    // Start is called before the first frame update
    void Start()
    {
        cameraPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = cameraPos + player.transform.position;
        
    }
}
