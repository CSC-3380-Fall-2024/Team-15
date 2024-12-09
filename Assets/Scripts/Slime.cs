using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.Rendering;

public class Slime : MonoBehaviour
{
    public float moveSpeed = 1.5f;
    public float chaseRange = 5f;
    public float attackRange = 1.5f;

    private Transform player;
    private bool isChasing = false;
    private bool isAttacking = false;
    public int attackDamage = 8;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    public Transform target;

    [SerializeField] LayerMask groundLayer;
    [SerializeField] float jumpHeight;
    [SerializeField] Transform groundCheck;
    [SerializeField] Vector2 boxSize;
    private bool isGrounded;

    [SerializeField] Vector2 lineOfSite;
    [SerializeField] LayerMask playerLayer;
    private bool canSeePlayer;

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
        }

        if (transform.position.x > player.position.x)
        {
            transform.localScale = new Vector3(.15f, .15f, 1);
        }
        else if (transform.position.x < player.position.x)
        {
            transform.localScale = new Vector3(-.15f, .15f, 1);
        }

    }

    void FixedUpdate() 
    {
        isGrounded = Physics2D.OverlapBox(groundCheck.position, boxSize, 0, groundLayer);
        canSeePlayer = Physics2D.OverlapBox(transform.position, lineOfSite, 0, playerLayer);
        bool isPlayerAbove = Physics2D.Raycast(transform.position, Vector2.up, 3f, 1 << player.gameObject.layer);
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        if(distanceToPlayer > 3.5 && canSeePlayer && isGrounded)
        {
            JumpAttack();
        }
        
    }

    void JumpAttack()
    {
        float distanceFromPlayer = player.position.x - transform.position.x;

        if(isGrounded)
        {
            rb.AddForce(new Vector2(distanceFromPlayer, jumpHeight), ForceMode2D.Impulse);
        }
    }
    private void MoveTowardsTarget()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
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
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawCube(groundCheck.position, boxSize);
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, lineOfSite);
    }
}

