using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour { 

    private float btimer;
    public float fadetime;
    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        btimer += Time.deltaTime;

        if(btimer >= fadetime)
        {
            Destroy(this.gameObject);
        }
    }

    public void OnCollisionEnter(Collision collision)
    {

        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().health -= damage;
        }

        Destroy(this.gameObject);
    }
}
