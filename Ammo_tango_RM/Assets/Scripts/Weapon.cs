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
        //GameObject clone = Instantiate(ammo, shotspawn.transform.position, shotspawn.transform.rotation);

        //clone.GetComponent<Rigidbody>().velocity = new Vector3(transform.forward.x * 10,transform.forward.y * 10,transform.forward.z * 10);
        GameObject bullet = PoolManager.Instance.GetPlayer1Bullet();
        if (bullet == null) return;

        bullet.transform.position = shotspawn.position;
        bullet.transform.rotation = transform.rotation;
        bullet.GetComponent<Rigidbody>().velocity = new Vector3(transform.forward.x * 1, transform.forward.y * 1, transform.forward.z * 1);
        bullet.GetComponent<Bullet>().ResetTimer();
        bullet.SetActive(true);

        /*if (Time.time > nextfire)
        {
            nextfire = Time.time + firerate;

            bullet.transform.position = bulletStartingPoint.position;
            bullet.transform.rotation = transform.rotation;

            bullet.SetActive(true);
        }
    }
        else
        {
            Debug.Log("Haetaan luotia niin perkeleesti");
            GameObject ebullet = PoolManager.current.GetEnemyBullet();
            if (ebullet == null)
            {
                Debug.Log("Ei täällä mitään luoteja ole!");
                return;
            }
            if (Time.time > nextfire)
            {
                nextfire = Time.time + firerate;

                ebullet.transform.position = bulletStartingPoint.position;
                ebullet.transform.rotation = transform.rotation;

                ebullet.SetActive(true);
            }
        }
     
        }*/
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
