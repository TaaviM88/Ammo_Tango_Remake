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
