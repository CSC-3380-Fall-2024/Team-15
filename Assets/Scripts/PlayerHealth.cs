using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int health = 100;
    private int MaxHealth = 100;

    public HealthBar healthBar; // Reference to HealthBar script

    void Start()
    {
        healthBar.SetMaxHealth(MaxHealth);
        healthBar.SetHealth(health);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.O))
        {
            Damage(10);
        }
        if(Input.GetKeyDown(KeyCode.H))
        {
            Heal(10);
        }
    }

    public void Damage(int amount)
    {
        health -= amount;
        healthBar.SetHealth(health);

        if (health <= 0)
        {
            Die();
        }
    }

    public void Heal(int amount)
    {
        health = Mathf.Min(health + amount, MaxHealth);
        healthBar.SetHealth(health);
    }

   private void Die()
   {
    Destroy(gameObject);
   }
}