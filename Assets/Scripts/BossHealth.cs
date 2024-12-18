using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossHealth : MonoBehaviour
{
    [SerializeField] FloatingHealthbar healthBar;
    private int health = 100;
    public int MaxHealth = 100;
    public GameManagerScript gameManager;

    private void Start()
    {
        health = MaxHealth;
        healthBar.UpdateHealthBar(health, MaxHealth);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            Damage(10);
        }
    }

    public void Damage(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative damage.");
        }
        this.health -= amount;
        healthBar.UpdateHealthBar(health, MaxHealth);

        if (health <= 0)
        {
            Die();
            SceneManager.LoadScene("LevelSelect");
        }

    }

    public void Heal(int amount)
    {
        if (amount < 0)
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
        Debug.Log("I am Dead!");
        Destroy(gameObject);
    }

    private void Awake()
    {
        healthBar = GetComponentInChildren<FloatingHealthbar>();
    }
}
