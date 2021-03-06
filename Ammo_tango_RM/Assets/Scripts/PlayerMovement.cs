﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public int PlayerId = 0;

    protected Rigidbody MyRb;
    public float MovementSpeed = 10f;
    private float maxVelocity = 10f;
    private Vector3 lastRotation;
    private bool _canMove;
    Vector3 moveDirection;
    Vector3 lookDirection;

    public Animator anime;
   

    // Start is called before the first frame update
    void Awake()
    {
        if(PlayerId == 0)
        {
            Debug.Log(this.gameObject.name + " missing ID");
        }
        MyRb = GetComponent<Rigidbody>();
        anime = GetComponent<Animator>();
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

            case 3:
                moveDirection = new Vector3(Input.GetAxis("LeftStickHorizontalP3"), 0, Input.GetAxis("LeftStickVerticalP3"));
                lookDirection = new Vector3(Input.GetAxis("RightStickHorizontalP3"), 0, Input.GetAxis("RightStickVerticalP3"));
                Movement(moveDirection, lookDirection);
                break;

            case 4:
                moveDirection = new Vector3(Input.GetAxis("LeftStickHorizontalP4"), 0, Input.GetAxis("LeftStickVerticalP4"));
                lookDirection = new Vector3(Input.GetAxis("RightStickHorizontalP4"), 0, Input.GetAxis("RightStickVerticalP4"));
                Movement(moveDirection, lookDirection);
                break;
        }

        anime.SetFloat("VelX", MyRb.velocity.x);
        anime.SetFloat("VelY", MyRb.velocity.z);
    }

    public void Movement(Vector3 move, Vector3 rotation)
    {

        MyRb.velocity = move * MovementSpeed;

        if (MyRb.velocity.magnitude > maxVelocity)
        {
            MyRb.velocity = Vector3.ClampMagnitude(MyRb.velocity, maxVelocity);
        }

        if (rotation != Vector3.zero)
        {

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
    }

     public void UpdatePlayerID(int ID)
     {
        PlayerId = ID;
     }

    public void CanMove(bool b)
    {
        _canMove = b;
    }

    
}
