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
    [SerializeField]
    protected float maxClipSize = 10;
    protected float currentClipAmount;

    [SerializeField]
    protected float reloadTime = 10f;
    protected float currentReloadTime =0;


    [SerializeField]
    protected GameObject bullet;
    // Start is called before the first frame update
    public virtual void Start()
    {
        currentClipAmount = maxClipSize;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void Shoot(Transform spawnBullet)
    {

        GameObject bulletClone = Instantiate(bullet, spawnBullet.position, spawnBullet.rotation);
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
}
