    using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] FloatingHealthbar healthBar;
    private int health = 100;
    public int MaxHealth = 100;

    private void Start(){
        health = MaxHealth;
        healthBar.UpdateHealthBar(health,MaxHealth);
    }
    
    public void Damage(int amount)
    {
        if(amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative damage.");
        }
        this.health -= amount;
        healthBar.UpdateHealthBar(health, MaxHealth);

        if (health <= 0)
        {
            Die();
        }
        
    }

    public void Heal(int amount)
    {
        if(amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative healing.");
        }

        bool wouldBeOverMaxHealth = health + amount > MaxHealth;

        if (wouldBeOverMaxHealth)
        {
            this.health = MaxHealth;
        }
        else
        {
            this.health += amount;
        }
        
        health = Mathf.Min(health + amount, MaxHealth);
        healthBar.UpdateHealthBar(health, MaxHealth);
    }

   private void Die()
   {
    GetComponent<LootBag>().InstantiateLoot(transform.position);
    Debug.Log("I am Dead!");
    Destroy(gameObject);
   }

   private void Awake()
   {
    healthBar = GetComponentInChildren<FloatingHealthbar>();
   }
}