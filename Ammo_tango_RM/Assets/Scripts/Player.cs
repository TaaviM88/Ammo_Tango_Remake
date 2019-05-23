using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Player : MonoBehaviour
{

    public enum CharacterName { None, character1, character2, character3, character4 }
    public CharacterName characterName = CharacterName.None;
    [Header("Player stats")]

    public float currentHealth = 10;

    [SerializeField]
    private float MaxHp;


    public float currentShield = 0;

    [SerializeField]
    private float MaxShield;


    private PlayerCombat combat;

    bool shieldOn = true;

    PlayerMovement pmovement;

    private int PlayerID = 0;

    CinemachineTargetGroup cmTargets;
    Weapon wp;

    [Header("Weapon Settings")]
    public Transform shotspawn;
    [SerializeField]
    GameObject baseWeapon;
    [SerializeField]
    GameObject currentWeapon;

    public GameObject ragdoll;
    GameObject gm;
    //Child objects
    private GameObject shield;
    private GameObject weaponSlotObj;
    // Start is called before the first frame update
    void Start()
    {
        combat = gameObject.GetComponent<PlayerCombat>();
        pmovement = gameObject.GetComponent<PlayerMovement>();
        PlayerID = pmovement.PlayerId;
        Debug.Log($"Player scriptin playerId = {PlayerID}");
        currentHealth = MaxHp;
        currentShield = MaxShield;
        // UIManager.instance.UpdateShieldBar(currentShield, pmovement.PlayerId);
        //GameManager.instance.UpdateShield(currentShield, pmovement.PlayerId);
        gm = FindObjectOfType<GameManager>().gameObject;
        gm.GetComponent<GameManager>().UpdateShield(currentShield, pmovement.PlayerId);
        gm.GetComponent<GameManager>().UpdateHealth(currentHealth, pmovement.PlayerId);
        shieldOn = true;

        //Add player to TargetGroup object. Camera stuff
        GameObject obj = GameObject.FindWithTag("TargetGroup");
        cmTargets = obj.GetComponent<CinemachineTargetGroup>();
        cmTargets.AddMember(gameObject.transform, 1, 0);

        //Weapon Settings

        currentWeapon = baseWeapon;

        foreach (Transform child in gameObject.GetComponentsInChildren<Transform>())
        {

            if (child.GetComponent<ShieldEffect>() != null)
            {
                shield = child.gameObject;
                shield.SetActive(false);

            }

            if (child.name == "WeaponSlot")
            {
                weaponSlotObj = child.gameObject;
                GameObject clone = Instantiate(currentWeapon);
                clone.transform.parent = weaponSlotObj.transform;
                currentWeapon = clone;
                currentWeapon.GetComponent<Weapon>().ShootingPlayerID(pmovement.PlayerId);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale > 0)
        {
            switch (pmovement.PlayerId)
            {
                #region Player1            
                case 1:

                    if (currentWeapon.GetComponent<Weapon>().shootmode == Weapon.ShootMode.Single)
                    {
                        if (Input.GetButtonDown("Fire1p1"))
                        {
                            Debug.Log($"Player{PlayerID} is shooting");
                            ShootMainWeapon();
                        }
                    }

                    if (currentWeapon.GetComponent<Weapon>().shootmode == Weapon.ShootMode.Burst)
                    {
                        if (Input.GetButtonDown("Fire1p1"))
                        {
                            ShootMainWeapon();
                        }

                    }
                    if (currentWeapon.GetComponent<Weapon>().shootmode == Weapon.ShootMode.Rapid)
                    {
                        if (Input.GetButton("Fire1p1"))
                        {
                            ShootMainWeapon();
                        }
                    }


                    if (Input.GetButtonDown("Fire2p1"))
                    {
                        combat.UseSubWeapon();
                    }
                    break;
                #endregion

                #region Player2            
                case 2:

                    if (currentWeapon.GetComponent<Weapon>().shootmode == Weapon.ShootMode.Single)
                    {
                        if (Input.GetButtonDown("Fire1p2"))
                        {
                            Debug.Log($"Player{PlayerID} is shooting");
                            ShootMainWeapon();
                        }
                    }

                    if (currentWeapon.GetComponent<Weapon>().shootmode == Weapon.ShootMode.Burst)
                    {
                        if (Input.GetButtonDown("Fire1p2"))
                        {
                            ShootMainWeapon();
                        }

                    }
                    if (currentWeapon.GetComponent<Weapon>().shootmode == Weapon.ShootMode.Rapid)
                    {
                        if (Input.GetButton("Fire1p2"))
                        {
                            ShootMainWeapon();
                        }
                    }


                    if (Input.GetButtonDown("Fire2p2"))
                    {
                        combat.UseSubWeapon();
                    }
                    break;
                #endregion

                #region Player3            
                case 3:
                    if (currentWeapon.GetComponent<Weapon>().shootmode == Weapon.ShootMode.Single)
                    {
                        if (Input.GetButtonDown("Fire1p3"))
                        {
                            ShootMainWeapon();
                        }
                    }

                    if (currentWeapon.GetComponent<Weapon>().shootmode == Weapon.ShootMode.Burst)
                    {
                        if (Input.GetButtonDown("Fire1p3"))
                        {
                            ShootMainWeapon();
                        }

                    }
                    if (currentWeapon.GetComponent<Weapon>().shootmode == Weapon.ShootMode.Rapid)
                    {
                        if (Input.GetButton("Fire1p3"))
                        {
                            ShootMainWeapon();
                        }
                    }


                    if (Input.GetButtonDown("Fire2p3"))
                    {
                        combat.UseSubWeapon();
                    }
                    break;
                #endregion

                #region Player4            
                case 4:
                    if (currentWeapon.GetComponent<Weapon>().shootmode == Weapon.ShootMode.Single)
                    {
                        if (Input.GetButtonDown("Fire1p4"))
                        {
                            ShootMainWeapon();
                        }
                    }

                    if (currentWeapon.GetComponent<Weapon>().shootmode == Weapon.ShootMode.Burst)
                    {
                        if (Input.GetButtonDown("Fire1p4"))
                        {
                            ShootMainWeapon(); ;
                        }

                    }
                    if (currentWeapon.GetComponent<Weapon>().shootmode == Weapon.ShootMode.Rapid)
                    {
                        if (Input.GetButton("Fire1p4"))
                        {
                            ShootMainWeapon();
                        }
                    }


                    if (Input.GetButtonDown("Fire2p4"))
                    {
                        combat.UseSubWeapon();
                    }
                    break;
                    #endregion

            }
        }

    }
    //Weapon and shooting methods
    public void ShootMainWeapon()
    {
        //wp.Shoot(shotspawn);
        if (currentWeapon.GetComponent<Weapon>() != null)
        {
            currentWeapon.GetComponent<Weapon>().Shoot(shotspawn);
        }
        else
        {
            Debug.Log("Can't find weapon-script");
        }
    }

    public void UpdateWeapon(GameObject newWeapon)
    {
        currentWeapon = newWeapon;
        currentWeapon.GetComponent<Weapon>().ShootingPlayerID(pmovement.PlayerId);
    }

    public void RollBackBaseWeapon()
    {
        currentWeapon = baseWeapon;
    }

    public GameObject ReturnCurrentWeaponObject()
    {
        return currentWeapon;
    }

    //Take damage methods and Dying method
    public void TakeDamageShield(float damage)
    {
        //Instantiet hit particle effect
        if (currentShield > 0)
        {
            currentShield = Mathf.Max(currentShield - damage, 0);
            //GameManager.instance.UpdateShield(currentShield, pmovement.PlayerId);
            gm.GetComponent<GameManager>().UpdateShield(currentShield, pmovement.PlayerId);
            Debug.Log($"{gameObject.name} Takes shield damage {damage} Shield left {currentShield}");
            if (shield.activeSelf == false)
            {
                shield.SetActive(true);
            }

            if (currentShield == 0)
            {
                shieldOn = false;
            }
        }
        else
        {
            TakeDamageHP(damage);
        }
    }

    public void RestoreShield(float restore)
    {
        currentShield = Mathf.Min(currentShield + restore, MaxShield);

        if (currentShield > 0)
        {
            shieldOn = true;
        }
    }

    public void TakeDamageHP(float damage)
    {
        //instantiate hit particle effect
        currentHealth = Mathf.Max(currentHealth - damage, 0);
        gm.GetComponent<GameManager>().UpdateHealth(currentHealth, pmovement.PlayerId);
        Debug.Log($"{gameObject.name} Takes damage {damage} Healt left {currentHealth}");
        if (currentHealth <= 0)
        {
            Debug.Log($"{gameObject.name} Dies");
            Die();
        }
    }

    public void Die()
    {
        //dying stuff here
        Debug.Log($"{gameObject.name} dies.");
        cmTargets.RemoveMember(gameObject.transform);
        Instantiate(ragdoll,transform.position,transform.rotation);
        Destroy(gameObject); 
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<WeaponBox>())
        {
            if (other.gameObject.GetComponent<WeaponBox>().ReturnWeapon() != null)
            {
                foreach (Transform child in weaponSlotObj.gameObject.GetComponentsInChildren<Transform>())
                {
                    if (child.name != weaponSlotObj.name)
                    {

                        Destroy(child.gameObject);
                    }

                }

                GameObject clone = Instantiate(other.gameObject.GetComponent<WeaponBox>().ReturnWeapon());
                clone.transform.parent = weaponSlotObj.transform;
                clone.transform.position = Vector3.zero;
                UpdateWeapon(clone);
                //combat.UpdateWeapon(clone);
                other.gameObject.GetComponent<WeaponBox>().ResetRespawn();
            }
        }
    }
}
