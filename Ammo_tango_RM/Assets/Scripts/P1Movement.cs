using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1Movement : MonoBehaviour
{
    protected Rigidbody MyRb;
    public float MovementSpeed = 10f;
    private float maxVelocity = 10f;
    private Vector3 lastRotation;

    public void Start()
    {
        MyRb = GetComponent<Rigidbody>();
    }
    public void FixedUpdate()
    {
        Vector3 moveDirection = new Vector3(Input.GetAxis("LeftStickHorizontalP1"), 0, Input.GetAxis("LeftStickVerticalP1"));
        Vector3 lookDirection = new Vector3(Input.GetAxis("RightStickHorizontalP1"), 0, Input.GetAxis("RightStickVerticalP1"));

        MyRb.velocity =  moveDirection * MovementSpeed;
        
        if(MyRb.velocity.magnitude > maxVelocity)
        {
            MyRb.velocity = Vector3.ClampMagnitude(MyRb.velocity, maxVelocity);
        }

        if (lookDirection.sqrMagnitude > 0.1)
        {
            transform.rotation = Quaternion.LookRotation(lookDirection);
            lastRotation = lookDirection;
        }
        else
        {
            transform.rotation = Quaternion.LookRotation(lastRotation);
        }
    }
}
