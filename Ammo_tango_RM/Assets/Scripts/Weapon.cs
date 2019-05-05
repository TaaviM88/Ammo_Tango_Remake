﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("Weapon settings")]

    [SerializeField]
    protected float damage = 1;
    [SerializeField]
    protected float range = 1;
    [SerializeField]
    protected float fireRate = 1;
    protected float nextFire;
    [SerializeField]
    protected float maxClipSize = 10;
    [SerializeField]
    protected float currentClipAmount = 4;

    [SerializeField]
    protected float reloadTime = 10f;
    protected float currentReloadTime =0;
    protected bool isReloading = false;

    [SerializeField]
    protected GameObject bullet;
    [SerializeField]
    protected AudioClip weaponshotSound;

    public enum ShootMode {None, Single, Burst, Rapid}
    public ShootMode shootmode = ShootMode.None;

    [Header("If using burst. Tell how many bullets to shoot else leave to 0")]
    [SerializeField]
    private int burst = 0;
    // Start is called before the first frame update
    private void Awake()
    {
        
    }

    public virtual void Start()
    {
        if(weaponshotSound == null)
        {
            return;
        }

        currentClipAmount = maxClipSize;
    }

    // Update is called once per frame
    void Update()
    {
        /*if(currentReloadTime > 0 && currentClipAmount <= 0)
        {
            currentReloadTime -= Time.deltaTime;
        }
        else
        {
            ReloadClip();
        }
        */
        /*if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
        }*/

    }

    public virtual void Shoot(Transform spawnBullet)
    {
        //&& Time.time > nextFire
        if (currentClipAmount > 0)
        {
            GameObject bulletClone = Instantiate(bullet, spawnBullet.position, spawnBullet.rotation);
            bulletClone.GetComponent<Bullet>().UpdateDamage(damage);
            PlaySoud();
            nextFire = Time.time + fireRate;
            currentClipAmount -= 1;
        }
        else if(!isReloading)
        {
            currentReloadTime = reloadTime;
            Invoke("ReloadClip", reloadTime);
            isReloading = true;
        }



        //bulletClone.GetComponent<Rigidbody>().AddForce(transform.forward * (Time.deltaTime * 60),ForceMode.Impulse);
        /*GameObject bul = PoolManager.Instance.GetPlayer1Bullet();
         if (bul == null) return;

        bul.transform.position = spawnBullet.position;
        bul.transform.rotation = spawnBullet.rotation;
        bul.GetComponent<EmptyBullet>().AddBullet(bullet,damage);
        
        //bullet.GetComponent<Rigidbody>().AddForce(Vector3.forward * Time.deltaTime * 6);
        //bullet.GetComponent<Rigidbody>().velocity = new Vector3(transform.forward.x * 1, transform.forward.y * 1, transform.forward.z * 1);
        //bul.GetComponent<Bullet>().ResetTimer();
        //bul.GetComponent<Bullet>().UpdateDamage(damage);
        bul.SetActive(true);
        */
    }

    public string ReturnName()
    {
        return this.name;
    }

    public GameObject ReturnBullet()
    {
        return bullet;
    }

    public void PlaySoud()
    {
        //play shooting sound
    }

    public void ReloadClip()
    {
        currentClipAmount = maxClipSize;
        isReloading = false;
    }

    public ShootMode ReturnShootMode()
    {
        return shootmode;
    }

    public int ReturnBurstAmount()
    {
        return burst;
    }
}
