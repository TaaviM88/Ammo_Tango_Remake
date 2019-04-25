using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    [Header("Bullet Settings")]
    private float btimer;
    public float fadetime;
    
    [SerializeField]
    private float force = 10;
    
    [SerializeField]
    private float damage;
    Rigidbody rb;

    public ParticleSystem particleLauncher;
    List<ParticleCollisionEvent> collisionEvents;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        collisionEvents = new List<ParticleCollisionEvent>();
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

    private void FixedUpdate()
    {
        //rb.AddForce(Vector3.forward * (Time.deltaTime * speed), ForceMode.Impulse);
        rb.AddForce( - transform.forward * (Time.deltaTime * force), ForceMode.Impulse);
        //rb.velocity = new Vector3(transform.forward.x * (Time.deltaTime * speed), transform.forward.y * (Time.deltaTime * speed), transform.forward.z * (Time.deltaTime * speed));

    }

    public void OnCollisionEnter(Collision collision)
    {

        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player>().TakeDamageShield(damage);
            Disable();
        }

        if(collision.gameObject.GetComponent<Destroyer>())
        {
            collision.gameObject.GetComponent<Destroyer>().TakeDMG(damage);
            Disable();
        }

        //Destroy(this.gameObject);
        
    }

    private void OnParticleCollision(GameObject other)
    {

        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Player>().TakeDamageShield(damage);
            Disable();
        }

        if (other.gameObject.GetComponent<Destroyer>())
        {
            other.gameObject.GetComponent<Destroyer>().TakeDMG(damage);
            Debug.Log("Shotgun");
        }
    }

    public void Disable()
    {
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        rb.velocity = Vector3.zero;
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
 }
