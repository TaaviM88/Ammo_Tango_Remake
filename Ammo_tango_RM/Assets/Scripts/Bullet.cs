using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour { 

    private float btimer;
    public float fadetime;
    public int damage;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        btimer += Time.deltaTime;

        if(btimer >= fadetime)
        {
            Disable();
        }
    }

    public void OnCollisionEnter(Collision collision)
    {

        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().TakeDamageShield(damage);
        }

        //Destroy(this.gameObject);
        
    }

    public void Disable()
    {
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        rb.velocity = Vector3.zero;
        gameObject.SetActive(false);
    }
 }
