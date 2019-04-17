using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour { 

    [SerializeField]
    private float currentHealth;

    [SerializeField]
    private float MaxHp;

    [SerializeField]
    private float currentShield;

    [SerializeField]
    private float MaxShield;

    private Weapon weapon;

    bool shieldOn = true;
    // Start is called before the first frame update
    void Start()
    {
        weapon = gameObject.GetComponent<Weapon>();
        currentHealth = MaxHp;
        currentShield = MaxShield;
        shieldOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire3") && weapon.cooldownTimer() == true)
        {
            weapon.shoot();
        }

        if (Input.GetButtonDown("Horizontal"))
        {
            transform.Rotate(0, 90, 0);
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
}
