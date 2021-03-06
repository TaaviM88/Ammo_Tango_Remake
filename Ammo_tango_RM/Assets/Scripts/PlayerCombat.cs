﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour {
    /*
    public float damage;
    public float cooldown;
    private float timer = 0f;
    //public GameObject ammo;
    //public Player player;
    

    [SerializeField]
    GameObject baseWeapon;

    [SerializeField]
    GameObject currentWeapon;
    */

    public Transform shotspawn;
    [Header("SubWeapon Settings")]
    [SerializeField]
    GameObject baseSubWeapon;
    [SerializeField]
    private int SubweaponAmount;

    private int currentSubWeaponAmount;
    GameObject currentSubWeapon;
    private bool subweaponUsed = false;
    [SerializeField]
    private float throwForce = -40f;
    [SerializeField]
    private float subweaponCoolDown = 1f;
    //Weapon wp;
    PlayerMovement pmovement;
    // Start is called before the first frame update
    void Awake()
    {
       // currentWeapon = baseWeapon;
        currentSubWeapon = baseSubWeapon;
        currentSubWeaponAmount = SubweaponAmount;

        //currentWeapon.GetComponent<Weapon>().ReloadClip();
        //wp = currentWeapon.GetComponent<Weapon>();
        //wp.ReloadClip();
        //pmovement = GetComponent<PlayerMovement>();
        //wp.ShootingPlayerID(pmovement.PlayerId);
    }

    // Update is called once per frame
    void Update()
    {
        //timer += Time.deltaTime;
    }

    public void ShootMainWeapon()
    {
        //wp.Shoot(shotspawn);
       // currentWeapon.GetComponent<Weapon>().Shoot(shotspawn);
    }

    public void UseSubWeapon()
    {
        if(currentSubWeaponAmount > 0 && !subweaponUsed)
        {
            GameObject subW = Instantiate(currentSubWeapon, shotspawn.position, Quaternion.identity);
            Rigidbody rb = subW.GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * throwForce,ForceMode.VelocityChange);
            currentSubWeaponAmount -= 1;
            subweaponUsed = true;
            //Change subweaponUsed=true
            Invoke("SubweaponCoolDown", subweaponCoolDown);
        }
        else
        {
            Debug.Log("You are out of subweapons");
        }
        
    }

   /* public bool cooldownTimer()
    {
        
        if(timer >= cooldown)
        {
            timer = 0f;
            return true;
        }
        return false;
    }*/

    public void SubweaponCoolDown()
    {
        subweaponUsed = false;
    }

    public void UpdateWeapon(GameObject newWeapon)
    {
        //currentWeapon = newWeapon;
        //currentWeapon.GetComponent<Weapon>().ShootingPlayerID(pmovement.PlayerId);
        //wp = currentWeapon.GetComponent<Weapon>();
        //wp.ShootingPlayerID(pmovement.PlayerId);
    }

    public void RollBackBaseWeapon()
    {
        //currentWeapon = baseWeapon;
        //wp = currentWeapon.GetComponent<Weapon>();
    }

   /* public Weapon ReturnWeapon()
    {
        return wp;
    }*/

   /* public GameObject ReturnCurrentWeaponObject()
    {
        return currentWeapon;
    }*/
}
