using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    // Start is called before the first frame update
    void Start()
    {
        combat = gameObject.GetComponent<PlayerCombat>();
        currentHealth = MaxHp;
        currentShield = MaxShield;
        shieldOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire2"))
        {
            Debug.Log("Pressed fire2");
            combat.shoot();
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
