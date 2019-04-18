﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int PlayerId;

    protected Rigidbody MyRb;
    public float MovementSpeed = 10f;
    private float maxVelocity = 10f;
    private Vector3 lastRotation;
    private bool _canMove;
    Vector3 moveDirection;
    Vector3 lookDirection;
   

    // Start is called before the first frame update
    void Start()
    {
        MyRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (PlayerId)
        {
            case 1:
                moveDirection = new Vector3(Input.GetAxis("LeftStickHorizontalP1"), 0, Input.GetAxis("LeftStickVerticalP1"));
                lookDirection = new Vector3(Input.GetAxis("RightStickHorizontalP1"), 0, Input.GetAxis("RightStickVerticalP1"));
                Movement(moveDirection, lookDirection);
                break;

            case 2:
                moveDirection = new Vector3(Input.GetAxis("LeftStickHorizontalP2"), 0, Input.GetAxis("LeftStickVerticalP2"));
                lookDirection = new Vector3(Input.GetAxis("RightStickHorizontalP2"), 0, Input.GetAxis("RightStickVerticalP2"));
                Movement(moveDirection, lookDirection);
                break;
        }
    }

    public void Movement(Vector3 move, Vector3 rotation)
    {

        MyRb.velocity = move * MovementSpeed;

        if (MyRb.velocity.magnitude > maxVelocity)
        {
            MyRb.velocity = Vector3.ClampMagnitude(MyRb.velocity, maxVelocity);
        }

        if (rotation.sqrMagnitude > 0.1)
        {
            transform.rotation = Quaternion.LookRotation(rotation);
            lastRotation = rotation;
        }
        else
        {
            transform.rotation = Quaternion.LookRotation(lastRotation);
        }
    }

     public void UpdatePlyaerID(int ID)
     {
        PlayerId = ID;
     }

    public void CanMove(bool b)
    {
        _canMove = b;
    }
}
