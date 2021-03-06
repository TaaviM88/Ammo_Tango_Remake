﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    [Header("Bullet Settings")]
    private float btimer = 0;
    public float fadetime;
    
    [SerializeField]
    private float force = 10;
    
    [SerializeField]
    private float damage;
    Rigidbody rb;

    public ParticleSystem particleLauncher;
    public GameObject bulletHitParticleEffect;
    public int playerID = 0;
    List<ParticleCollisionEvent> collisionEvents;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        collisionEvents = new List<ParticleCollisionEvent>();
        rb.AddForce(-transform.forward * force, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        btimer += Time.deltaTime;

        if(btimer >= fadetime)
        {
            Disable(false);
        }

        // Debug.Log($"Bullet id ={playerID}");
    }

  private void FixedUpdate()
    {
        //rb.AddForce(Vector3.forward * (Time.deltaTime * speed), ForceMode.Impulse);
        //rb.AddForce(-transform.forward * force, ForceMode.Impulse);  //(Time.deltaTime * force), ForceMode.Impulse);
        //rb.velocity = new Vector3(transform.forward.x * (Time.deltaTime * speed), transform.forward.y * (Time.deltaTime * speed), transform.forward.z * (Time.deltaTime * speed));

    }

    /*public void OnCollisionEnter(Collision collision)
    {

        if(collision.gameObject.GetComponent<Player>())
        {
            collision.gameObject.GetComponent<Player>().TakeDamageShield(damage);
            //Disable();
        }

        if(collision.gameObject.GetComponent<Destroyer>())
        {
            collision.gameObject.GetComponent<Destroyer>().TakeDMG(damage);
            //Disable();
        }

        if (other.gameObject.isStatic == true)
        {
            Disable();
        }

        //Destroy(this.gameObject);
        //Disable();

    }*/

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player>() && other.gameObject.GetComponent<PlayerMovement>().PlayerId != playerID)
        {
            other.gameObject.GetComponent<Player>().TakeDamageShield(damage);
            Disable(true);
        }

        if (other.gameObject.GetComponent<Destroyer>())
        {
            other.gameObject.GetComponent<Destroyer>().TakeDMG(damage);
            Disable(true);
        }

        if(other.gameObject.GetComponent<CellController>())
        {
            //Debug.Log("löyty cellController");
            other.gameObject.GetComponent<CellController>().ActivateRigidbody();
            Disable(true);
        }

        if (other.gameObject.isStatic == true)
        {
            Disable(true);
        }
    }

    private void OnParticleCollision(GameObject other)
    {

        if (other.gameObject.GetComponent<Player>() && other.gameObject.GetComponent<PlayerMovement>().PlayerId != playerID)
        {
            other.gameObject.GetComponent<Player>().TakeDamageShield(damage);
            //Disable(false);
        }

        if (other.gameObject.GetComponent<Destroyer>())
        {
            other.gameObject.GetComponent<Destroyer>().TakeDMG(damage);
            //Disable(false);
        }

        if (other.gameObject.GetComponent<CellController>())
        {
            other.gameObject.GetComponent<CellController>().ActivateRigidbody();
            //Disable(false);
        }
        if (other.gameObject.isStatic == true)
        {
            //Disable(false);
        }
    }

    public void Disable(bool spawnHitEffect)
    {
        /*transform.position = Vector3.zero;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        rb.velocity = Vector3.zero;*/
        if(spawnHitEffect)
        {
            Instantiate(bulletHitParticleEffect, transform.position, transform.rotation);
        }

        Destroy(gameObject);
        //gameObject.SetActive(false);
    }

    public void ResetTimer()
    {
        btimer = 0;
    }

    public void UpdateDamage(float newDMG)
    {

        damage = newDMG;
    }

    public float ReturnTimer()
    {
        return fadetime;
    }

    public void UpdatePlayerID(int id)
    {
        playerID = id;
    }

    public void SetupFadeTime(float t)
    {
        fadetime = t;
    }
 }
