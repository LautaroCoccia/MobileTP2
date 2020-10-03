using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accelemeter : MonoBehaviour
{
    public bool isFlat = true;
    private Rigidbody rigid;
    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Vector3 tilt = Input.acceleration;
        if (isFlat)
        {
            tilt = Quaternion.Euler(90, 0, 0) * tilt;
        }
        rigid.AddForce(tilt);
    }

}
