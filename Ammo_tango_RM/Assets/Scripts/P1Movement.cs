using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1Movement : MonoBehaviour
{
    protected Rigidbody MyRb;
    public float MovementSpeed = 3f;

    public void Start()
    {
        MyRb = GetComponent<Rigidbody>();
    }
    public void Update()
    {
        Vector3 moveDirection = new Vector3(Input.GetAxis("LeftStickHorizontalP1"), 0, Input.GetAxis("LeftStickVerticalP1"));
        Vector3 lookDirection = new Vector3(Input.GetAxis("RightStickHorizontalP1"), 0, Input.GetAxis("RightStickVerticalP1"));

        MyRb.velocity = moveDirection * MovementSpeed;
        transform.rotation = Quaternion.LookRotation(lookDirection);
    }
}
