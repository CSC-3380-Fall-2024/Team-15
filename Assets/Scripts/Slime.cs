using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.Rendering;

public class Slime : MonoBehaviour
{
    private float moveSpeed = 5f;
    public float chaseRange = 5f; 
    public float attackRange = 1.5f;
    private int maxHealth = 50;
    private int currentHealth;
    private Transform player;
    private bool isChasing = false;
    private bool isAttacking = false;
    public int attackDamage = 8;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        player = GameObject.FindWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player == null) return;
            
        if(currentHealth <= 0) Die();

          if(Input.GetKeyDown(KeyCode.U))
        {
            TakeDamage(10);
        }
        float distanceToPlayer = Vector2.Distance(transform.position,player.position);

        if(distanceToPlayer < chaseRange)
        {
            isChasing = true;
        }
        else{
            isChasing = false;
        }

        if(distanceToPlayer < attackRange && !isAttacking)
        {
            Attack();
        }
        
        if (isChasing && !isAttacking)
        {
            MoveTowardPlayer();
        }
    }

    private void Attack()
    {
        Debug.Log("Attack");
        isAttacking = true;
        Health playerHealth = player.GetComponent<Health>();
        if ( playerHealth != null)
        {
            playerHealth.Damage(attackDamage);
        }
      
        StartCoroutine(ResetAttack());
    
    }
    private IEnumerator ResetAttack()
    {
        yield return new WaitForSeconds(0.2f);
        Debug.Log("resetting :)");
        isAttacking = false;
    }


    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        StartCoroutine(ChangeColorOnDamage());

        if (currentHealth <= 0)
        {
            Die();
        }
    }
    private IEnumerator ChangeColorOnDamage()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(0.2f);
        spriteRenderer.color = Color.white;
    }

    private void MoveTowardPlayer()
    {
        if (player != null)
        {
             Vector2 direction = (player.position - transform.position).normalized; // Get direction
             rb.velocity = new Vector2(direction.x * moveSpeed, rb.velocity.y);
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
