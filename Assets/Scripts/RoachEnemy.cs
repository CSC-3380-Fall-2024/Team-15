using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;

public class RoachEnemy : MonoBehaviour
{
    private float moveSpeed = 1.5f;
    public float chaseRange = 5f;
    public float attackRange = 1.5f;
    private Transform player;
    private bool isChasing = false;
    private bool isAttacking = false;
    public int attackDamage = 8;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) return;

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer < chaseRange)
        {
            isChasing = true;
        }
        else
        {
            isChasing = false;
        }

        if (distanceToPlayer < attackRange && !isAttacking)
        {
            Attack();
        }

        if (isChasing && !isAttacking)
        {
            MoveTowardPlayer();
        }

        if (Vector3.Distance(transform.position, target.position) > 1f)
        {
            MoveTowardsTarget();
            RotateTowardsTarget();
        }
    }

    private void MoveTowardsTarget()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
    }

    private void RotateTowardsTarget()
    {
        var offset = 90f;
        Vector2 direction = transform.position - target.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
    }
    private void Attack()
    {
        Debug.Log("Attack");
        isAttacking = true;
        Health playerHealth = player.GetComponent<Health>();
        if (playerHealth != null)
        {
            playerHealth.Damage(attackDamage);
            
        }

        StartCoroutine(ResetAttack());

    }
    private IEnumerator ResetAttack()
    {
        yield return new WaitForSeconds(0.4f);
        Debug.Log("resetting :)");
        isAttacking = false;
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
        GetComponent<LootBag>().InstantiateLoot(transform.position);
        Destroy(gameObject);
    }
}
