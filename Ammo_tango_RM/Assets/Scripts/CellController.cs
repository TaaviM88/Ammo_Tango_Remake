using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class CellController : MonoBehaviour
{
    Rigidbody rb;
    public float disableTimer = 3f;
    private bool isActivated = false;
    public float force = 20f;
    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateRigidbody()
    {
        if(!isActivated)
        {
            //Debug.Log("Laitetaan rb pois kinematicista");
            rb.isKinematic = false;
            //GetComponent<MeshCollider>().isTrigger = true;
            rb.AddForce(Vector3.forward * force, ForceMode.Impulse);
            isActivated = true;
            Invoke("DisableRigidbody",disableTimer);
        }
       

    }

    public void DisableRigidbody()
    {
        rb.isKinematic = true;
        //GetComponent<MeshCollider>().isTrigger = false;
    }
}
