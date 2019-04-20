using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance;

    public GameObject bulletPrefab;

    //public GameObject enemyBulletPrefab;
    [SerializeField]
    private int maxAmountPlayer1Bullets = 12;
    [SerializeField]
    private int maxAmountPlayer2Bullets = 12;

    private List<GameObject> p1Bullets = new List<GameObject>();
    private List<GameObject> p2Bullets = new List<GameObject>();
    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        for (int i = 0; i <= maxAmountPlayer1Bullets; i++)
        {
            GameObject player1bullet = GameObject.Instantiate(bulletPrefab);
            player1bullet.transform.parent = this.transform;
            player1bullet.SetActive(false);
            p1Bullets.Add(player1bullet);

        }

       /* for (int i = 0; i <= maxAmountPlayer2Bullets; i++)
        {
            GameObject player2Bullet = GameObject.Instantiate(enemyBulletPrefab);
            player2Bullet.transform.parent = this.transform;
            player2Bullet.SetActive(false);
            p2Bullets.Add(player2Bullet);
        }*/
    }
    public GameObject GetPlayer1Bullet()
    {
        return p1Bullets.FirstOrDefault(x => !x.activeInHierarchy);
    }

   /* public GameObject GetPlayer2Bullet()
    {
        return p2Bullets.FirstOrDefault(x => !x.activeInHierarchy);
    }*/
}
