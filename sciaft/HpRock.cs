using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpRock : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public GameObject healthEffect;

    public HealthBar healthBar;

    //public HealthItem BoosHp;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(20);
            //Damage(20);
        }

    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die() //ตรวจสอบการตายของPlayer
    {
        //Instantiate(healthEffect, enamyEff.transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
