using System.Collections;
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
    protected bool canShoot = true;
    [SerializeField]
    protected float maxClipSize = 10;
    [SerializeField]
    protected float currentClipAmount = 4;

    [SerializeField]
    protected float reloadTime = 10f;
    protected float currentReloadTime =0;
    public bool isReloading = false;

    [SerializeField]
    protected GameObject bullet;
    [SerializeField]
    protected AudioClip weaponshotSound;

    public enum ShootMode {None, Single, Burst, Rapid}
    public ShootMode shootmode = ShootMode.None;

    [Header("If using burst. Tell how many bullets to shoot else leave to 0")]
    [SerializeField]
    protected int burst = 0;
    [SerializeField]
    protected float burstDelay = 1;

    private int playerID = 0;

    AudioManager audioM;

    public virtual void Awake()
    {
        if(weaponshotSound == null)
        {
            return;
        }

        currentClipAmount = maxClipSize;

        audioM = FindObjectOfType<AudioManager>();
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
      
            if (currentClipAmount > 0 && Time.time > nextFire && canShoot)
            {
                if(shootmode == ShootMode.Burst)
                {
                    StartCoroutine("FireBurst", spawnBullet);
                }
                else
                {
                    GameObject bulletClone = Instantiate(bullet, spawnBullet.position, spawnBullet.rotation);
                    bulletClone.GetComponent<Bullet>().UpdateDamage(damage);
                    bulletClone.GetComponent<Bullet>().UpdatePlayerID(playerID);
                    PlaySoud();
                    currentClipAmount -= 1;
                }
                
                nextFire = Time.time + fireRate;
                canShoot = false;
                Invoke("ChangeCanShoot", fireRate);
            }
            else if (currentClipAmount <= 0 && !isReloading)
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

    public IEnumerator FireBurst(Transform spawnbullet)
    {
        for (int i = 0; i < burst; i++)
        {
            GameObject bulletClone = Instantiate(bullet, spawnbullet.position, spawnbullet.rotation);
            bulletClone.GetComponent<Bullet>().UpdateDamage(damage);
            bulletClone.GetComponent<Bullet>().UpdatePlayerID(playerID);
            bulletClone.GetComponent<Bullet>().fadetime = range;
            PlaySoud();
            currentClipAmount -= 1;
            yield return new WaitForSeconds(burstDelay);
        }
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
        if (audioM != null)
        {
            Debug.Log(weaponshotSound);
            audioM.Play(weaponshotSound.name);
        }
        
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

    public float ReturnBurstDelay()
    {
        return burstDelay;
    }

    public float ReturnFireRate()
    {
        return fireRate;
    }

    public bool ReturnCanShoot()
    {
        return canShoot;
    }

    public void ChangeCanShoot()
    {
        canShoot = true;
    }

    public void ShootingPlayerID(int id)
    {
        playerID = id;
    }

    public float ReturnRange()
    {
        return range;
    }

    public float ReturnReloadTime()
    {
        return reloadTime;
    }

    public float ReturnCurrentClipSize()
    {
        return currentClipAmount;
    }
}
