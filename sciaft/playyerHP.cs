using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playyerHP : HealthItem
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;

    public Text END;
    public Text restart;

    private bool gameOver;
    private bool restarts;

    //public HealthItem BoosHp;
    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        restarts = false;

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        //BoosHp = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthItem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag ("Enamy"))
        {
            TakeDamage(20);
            //Damage(20);
        }
        if (other.gameObject.CompareTag("Boood"))
        {
            TakeDamage(10);
            //Damage(20);
            Debug.Log("1");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
            print("condition");
        }
    }

      void Die() //ตรวจสอบการตายของPlayer
    {
        END.text = "END";
        gameOver = true;
        restarts = true;
        restart.text = "Press K for Restart!";
        //Destroy(this.gameObject);

        this.GetComponent<PlayyerMovement>().enabled = false;
    }
    private void Update()
    {
        if(gameOver)
        {
            
        }

        if(restart)
        {
            if(Input.GetKeyDown(KeyCode.K))
            {
                Application.LoadLevel(Application.loadedLevel);
            }
        }
    }


}
