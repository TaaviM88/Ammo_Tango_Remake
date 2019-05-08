using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Player : MonoBehaviour {

    enum PlayerName {character1, character2, character3, character4 }

    [Header("Player stats")]
    
    private float currentHealth = 10;

    [SerializeField]
    private float MaxHp;


    private float currentShield = 0;

    [SerializeField]
    private float MaxShield;

    private PlayerCombat combat;

    bool shieldOn = true;

    PlayerMovement pmovement;

    private int PlayerID = 0;

    CinemachineTargetGroup cmTargets;
    Weapon wp;

    // Start is called before the first frame update
    void Start()
    {
        combat = gameObject.GetComponent<PlayerCombat>();
        pmovement = gameObject.GetComponent<PlayerMovement>();
        PlayerID = pmovement.PlayerId;
        currentHealth = MaxHp;
        currentShield = MaxShield;
        shieldOn = true;

        GameObject obj = GameObject.FindWithTag("TargetGroup");
        cmTargets = obj.GetComponent<CinemachineTargetGroup>();
        cmTargets.AddMember(gameObject.transform, 1, 0);
    }

    // Update is called once per frame
    void Update()
    {
        switch(PlayerID)
        {
            #region Player1            
            case 1:
                if (combat.ReturnWeapon().shootmode == Weapon.ShootMode.Single)
                {
                    if (Input.GetButtonDown("Fire1p1"))
                    {
                        combat.ShootMainWeapon();
                    }
                }

                if(combat.ReturnWeapon().shootmode == Weapon.ShootMode.Burst)
                {
                    if (Input.GetButtonDown("Fire1p1"))
                    {
                        combat.ShootMainWeapon();
                    }
                    
                }
                if(combat.ReturnWeapon().shootmode == Weapon.ShootMode.Rapid)
                {
                    if (Input.GetButton("Fire1p1"))
                    {
                        combat.ShootMainWeapon();
                    }
                }
                

                if(Input.GetButtonDown("Fire2p1"))
                {
                    combat.UseSubWeapon();
                }
                break;
            #endregion

            #region Player2            
            case 2:
                if (combat.ReturnWeapon().shootmode == Weapon.ShootMode.Single)
                {
                    if (Input.GetButtonDown("Fire1p2"))
                    {
                        combat.ShootMainWeapon();
                    }
                }

                if (combat.ReturnWeapon().shootmode == Weapon.ShootMode.Burst)
                {
                    if (Input.GetButtonDown("Fire1p2"))
                    {
                        combat.ShootMainWeapon();
                    }

                }
                if (combat.ReturnWeapon().shootmode == Weapon.ShootMode.Rapid)
                {
                    if (Input.GetButton("Fire1p2"))
                    {
                        combat.ShootMainWeapon();
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
                if (combat.ReturnWeapon().shootmode == Weapon.ShootMode.Single)
                {
                    if (Input.GetButtonDown("Fire1p3"))
                    {
                        combat.ShootMainWeapon();
                    }
                }

                if (combat.ReturnWeapon().shootmode == Weapon.ShootMode.Burst)
                {
                    if (Input.GetButtonDown("Fire1p3"))
                    {
                        combat.ShootMainWeapon();
                    }

                }
                if (combat.ReturnWeapon().shootmode == Weapon.ShootMode.Rapid)
                {
                    if (Input.GetButton("Fire1p3"))
                    {
                        combat.ShootMainWeapon();
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
                if (combat.ReturnWeapon().shootmode == Weapon.ShootMode.Single)
                {
                    if (Input.GetButtonDown("Fire1p4"))
                    {
                        combat.ShootMainWeapon();
                    }
                }

                if (combat.ReturnWeapon().shootmode == Weapon.ShootMode.Burst)
                {
                    if (Input.GetButtonDown("Fire1p4"))
                    {
                        combat.ShootMainWeapon();
                    }

                }
                if (combat.ReturnWeapon().shootmode == Weapon.ShootMode.Rapid)
                {
                    if (Input.GetButton("Fire1p4"))
                    {
                        combat.ShootMainWeapon();
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

    public void TakeDamageShield(float damage)
    {
        //Instantiet hit particle effect
        if(currentShield > 0)
        {
            float takenDamage = Mathf.Min(damage - currentShield, 0);
            Debug.Log($"{gameObject.name} Takes shield damage {damage}");
            if ( currentShield == 0)
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
        float restoreAmount = Mathf.Max(currentShield + restore, MaxShield);
        if(currentShield > 0)
        {
            shieldOn = true; 
        }
    }

    public void TakeDamageHP(float damage)
    {
        //instantiate hit particle effect
        float takenDamage = Mathf.Min(damage - currentHealth, 0);
        Debug.Log($"{gameObject.name} Takes damage {damage}");
        if (currentHealth <=0)
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
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<WeaponBox>())
        {
            if(other.gameObject.GetComponent<WeaponBox>().ReturnWeapon() != null)
            {
                combat.UpdateWeapon(other.gameObject.GetComponent<WeaponBox>().ReturnWeapon());
                other.gameObject.GetComponent<WeaponBox>().ResetRespawn();
            }
        } 
    }
}
