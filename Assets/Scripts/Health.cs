using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int health = 100;
    private int maxHealth = 100;
    private bool isDead;
    public GameManagerScript gameManager;
    public HealthBar healthBar; // Reference to HealthBar script
    // Initializes health values at the start and updated the health bar
    void Start()
    {
        healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(health);
    }
    // Checks for player input to damage or heal
    void Update()
    {
       // if(Input.GetKeyDown(KeyCode.O))
      //  {
      //      Damage(10);
      //  }
      //  if(Input.GetKeyDown(KeyCode.H))
      //  {
       //     Heal(10);
      //  }
    }
    // Reduces the health by a specific amount and if it reaches 0 or drops it triggers the die method
    public void Damage(int amount)
    {
        health -= amount;
        healthBar.SetHealth(health);

        if (health <= 0 && !isDead)
        {
            isDead = true;
            Die();
            gameManager.gameOver();
        }
    }
    // Increases the health by a specific amount and updates the healthbar to that value
    public void Heal(int amount)
    {
        health = Mathf.Min(health + amount, maxHealth);
        healthBar.SetHealth(health);
    }
   // Handles the characters death by destroying the game object
   private void Die()
   {
    gameObject.SetActive(false);
    Debug.Log("You are Dead");
   }
}
