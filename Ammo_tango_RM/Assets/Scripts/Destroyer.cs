﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject destroyedObject;

    [SerializeField]
    private float hp = 1;
    public void TakeDMG( float  dmg)
    {
        hp = Mathf.Max(hp-dmg, 0);

        if(hp <= 0)
        {
            Instantiate(destroyedObject, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
