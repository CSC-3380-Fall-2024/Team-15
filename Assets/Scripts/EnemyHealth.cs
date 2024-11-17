using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int health = 100;
    private int MaxHealth = 100;

    public void Damage(int amount)
    {
        if(amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative damage.");
        }
        this.health -= amount;

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
    }

   private void Die()
   {
    Debug.Log("I am Dead!");
    Destroy(gameObject);
   }
}