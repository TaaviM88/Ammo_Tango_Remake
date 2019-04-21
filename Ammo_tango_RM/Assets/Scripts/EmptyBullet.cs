using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyBullet : MonoBehaviour
{

    private float btimer;
    private float fadetime = 1;
    Rigidbody rb;
    //public GameObject addBullet = null;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
            btimer += Time.deltaTime;

            if (btimer >= fadetime)
            {
                Disable();
            }
    }

    public void Disable()
    {
        transform.position = Vector3.zero;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        rb.velocity = Vector3.zero;
        foreach(Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        gameObject.SetActive(false);
    }
    public void AddBullet(GameObject add, float dmg)
    {
        GameObject bulletClone = Instantiate(add, transform.position, transform.rotation,gameObject.transform);
        bulletClone.GetComponent<Bullet>().ResetTimer();
        bulletClone.GetComponent<Bullet>().UpdateDamage(dmg);
        fadetime = bulletClone.GetComponent<Bullet>().ReturnTimer();
    }
}
