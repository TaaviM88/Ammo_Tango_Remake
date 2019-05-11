using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float delay = 3f;
    private float countdown;
    bool hasExploded = false;
    public GameObject ExplosionEffect;
    public float damage = 1;

    // Start is called before the first frame update
    void Start()
    {
        countdown = delay;

        Invoke("Explode", delay);
    }

    // Update is called once per frame
    /*void Update()
    {
        countdown -= Time.deltaTime;
        if(countdown <= 0 && !hasExploded)
        {
            Explode();
            hasExploded = true;
        }
    }*/

    public void Explode()
    {
        Instantiate(ExplosionEffect, transform.position, transform.rotation);

        Destroy(gameObject);
    }
}
