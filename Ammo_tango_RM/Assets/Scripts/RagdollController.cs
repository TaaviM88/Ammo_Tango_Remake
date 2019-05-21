using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollController : MonoBehaviour
{
    // Start is called before the first frame update
    public float disableTimer = 1f;
    void Start()
    {
        Invoke("DisableRagDoll", disableTimer);
    }

    public void DisableRagDoll()
    {
        Rigidbody[] bodies = GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody rb in bodies)
        {
            rb.isKinematic = true;
            if(rb.GetComponent<MeshCollider>())
            {
                rb.GetComponent<MeshCollider>().isTrigger = true;
            }
            else if(rb.GetComponent<Collider>().isTrigger)
            {
                rb.GetComponent<Collider>().isTrigger = true;
            }
        }
    }
}
