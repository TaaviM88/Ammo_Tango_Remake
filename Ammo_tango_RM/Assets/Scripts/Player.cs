using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour { 

    public int health;
    private Weapon weapon;

    // Start is called before the first frame update
    void Start()
    {
        weapon = gameObject.GetComponent<Weapon>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire3") && weapon.cooldownTimer() == true)
        {
            weapon.shoot();
        }

        if (Input.GetButtonDown("Horizontal"))
        {
            transform.Rotate(0, 90, 0);
        }

        if(health <= 0)
        {
            health = 0;
            Debug.Log("kuolemaaaaa");
            return;
        }
    }
}
