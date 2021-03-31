using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : MonoBehaviour {

    private playyerHP player;
    public GameObject healthEffect;
    public int healthBoost;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<playyerHP>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H) && player.currentHealth <= 90)
        {
            Use();
        }
    }

    public void Use()
    {
        Instantiate(healthEffect, player.transform.position, Quaternion.identity);
        player.currentHealth += healthBoost;

        player.healthBar.SetHealth(player.currentHealth);

        Destroy(gameObject);
    }
}
