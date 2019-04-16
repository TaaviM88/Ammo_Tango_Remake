using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2Movement : MonoBehaviour
{
    protected Rigidbody MyRb;
    public float MovementSpeed = 3f;

    public void Start()
    {
        MyRb = GetComponent<Rigidbody>();
    }
    public void Update()
    {
        Vector3 moveDirection = new Vector3(Input.GetAxis("LeftStickHorizontalP2"), 0, Input.GetAxis("LeftStickVerticalP2"));
        Vector3 lookDirection = new Vector3(Input.GetAxis("RightStickHorizontalP2"), 0, Input.GetAxis("RightStickVerticalP2"));

        MyRb.velocity = moveDirection * MovementSpeed;
        transform.rotation = Quaternion.LookRotation(lookDirection);
    }
}
