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
                    if (Input.GetButtonDown("Fire2"))
                    {
                        combat.ShootMainWeapon();
                    }
                }

                if(combat.ReturnWeapon().shootmode == Weapon.ShootMode.Burst)
                {
                    int a = combat.ReturnWeapon().ReturnBurstAmount();
                    if( Input.GetButtonDown("Fire2"))
                    {
                        for (int i = 0; i < a; i++)
                        {
                            combat.ShootMainWeapon();
                        }
                    }
                    
                }
                if(combat.ReturnWeapon().shootmode == Weapon.ShootMode.Rapid)
                {
                    if (Input.GetButton("Fire2"))
                    {
                        combat.ShootMainWeapon();
                    }
                }
                

                if(Input.GetButtonDown("Fire3"))
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

            if( currentShield == 0)
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

        if(currentHealth <=0)
        {
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
