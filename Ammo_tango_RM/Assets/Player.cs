using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour { 

    public float HP;
    public Weapon weapon;

    // Start is called before the first frame update
    void Start()
    {
        
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
    }
}
