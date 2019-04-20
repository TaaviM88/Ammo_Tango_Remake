using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBox : MonoBehaviour
{
    [SerializeField]
    private GameObject weaponPrefab;

    // do timer stuff


    public GameObject ReturnWeapon()
    {
        return weaponPrefab;
    }

}
