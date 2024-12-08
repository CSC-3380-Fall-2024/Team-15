using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2 : MonoBehaviour
{
    public float attackRange = 1.5f;
    private Transform player;
    private bool isAttacking = false;
    public int attackDamage = 15;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    public Transform target;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) return;

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer < attackRange && !isAttacking)
        {
            Attack();
        }
    }

    private void Attack()
    {
        Debug.Log("Attack");
        isAttacking = true;
        animator.SetBool("BossAttacking", isAttacking);
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
        animator.SetBool("BossAttacking", isAttacking);
    }
    private void Die()
    {
        Destroy(gameObject);
    }
}
