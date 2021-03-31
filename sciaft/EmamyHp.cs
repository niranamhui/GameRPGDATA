using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmamyHp : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public GameObject healthEffect;
   // public GameObject DactEffect;
    private enamy enamyEff;
    public HealthBar healthBar;
    public LootTable thisLoot;

    public GameObject playerPos;
    public GameObject power;

    //public HealthItem BoosHp;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        enamyEff = GameObject.FindGameObjectWithTag("Enamy").GetComponent<enamy>();
       // playerPos = GameObject.FindGameObjectWithTag("PlayerPos").transform;
    }

    // Update is called once per frame
    /* void Update()
     {
         if(Input.GetKeyDown(KeyCode.Space))
         {
             TakeDamage(20);
             Debug.Log("1"); 
         }
     }

    */
    private void ItemBoosHp()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            GameObject effect = Instantiate(healthEffect, transform.position, Quaternion.identity);
            //Destroy(healthEffect, 2);
            TakeDamage(10);
            //Damage(20);
            //MakeLoot();
        }
       
    }

    void OnCollisionEnter(Collision collisionInfo)
    {
       
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            //Instantiate(power, playerPos.position, power.transform.rotation, playerPos.transform);
            MakeLoot();
            GameObject effect = Instantiate(healthEffect, transform.position, Quaternion.identity);
            //Destroy(healthEffect, 2);
            this.gameObject.SetActive(false);

            print("condition");
        }
    }
    private void MakeLoot()
    {
        if (thisLoot != null)
        {
            Powerup current = thisLoot.LootPowerup();
            if (current != null)
            {
                GameObject Item = Instantiate(power.gameObject, playerPos.transform.position, Quaternion.identity);
                Die();
            }
        }
    }

    void Die() //ตรวจสอบการตายของPlayer
    {
        //GameObject effect = Instantiate(DactEffect, transform.position, Quaternion.identity);
        //Destroy(DactEffect);
        //Destroy(this.gameObject);
    }
}
