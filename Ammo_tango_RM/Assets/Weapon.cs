using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour { 

    public float damage;
    public float cooldown;
    private float timer = 0f;
    public GameObject ammo;
    public Player player;
    public Transform shotspawn;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
    }

    public void shoot()
    {
        GameObject clone = Instantiate(ammo, shotspawn.transform.position, shotspawn.transform.rotation);

        clone.GetComponent<Rigidbody>().velocity = new Vector3(transform.forward.x * 10,transform.forward.y * 10,transform.forward.z * 10);
    }

    public bool cooldownTimer()
    {
        
        if(timer >= cooldown)
        {
            timer = 0f;
            return true;
        }
        return false;
    }
}
