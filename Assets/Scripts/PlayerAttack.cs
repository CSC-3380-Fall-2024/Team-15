using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private GameObject attackAreaJab = default;
    private GameObject attackAreaBKick = default;
    private GameObject attackAreaSKick = default;
    private GameObject attackAreaUpper = default;
    private bool attacking = false;
    private bool shortkicking = false;
    private bool roundhousing = false;
    private bool uppercutting = false;
    private float timeToAttack = 0.25f;
    private float timer = 0f;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        attackAreaJab = transform.GetChild(0).gameObject;
        attackAreaBKick = transform.GetChild(1).gameObject;
        attackAreaSKick = transform.GetChild(2).gameObject;
        attackAreaUpper = transform.GetChild(3).gameObject;
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            Attack();
        }

        if(Input.GetKeyDown(KeyCode.K))
        {
            ShortKick();
        }

        if(Input.GetKeyDown(KeyCode.L))
        {
            Roundhouse();
        }

        if(Input.GetKeyDown(KeyCode.I))
        {
            Uppercut();
        }

        if(attacking)
        {
            timer += Time.deltaTime;

            if(timer >= timeToAttack)
            {
                timer = 0;
                attacking = false;
                animator.SetBool("isAttacking", attacking);
                attackAreaJab.SetActive(attacking);
            }
        }

        if(shortkicking)
        {
            timer += Time.deltaTime;

            if(timer >= timeToAttack)
            {
                timer = 0;
                shortkicking = false;
                animator.SetBool("isShortKicking", shortkicking);
                attackAreaSKick.SetActive(shortkicking);
            }
        }

        if(roundhousing)
        {
            timer += Time.deltaTime;

            if(timer >= timeToAttack)
            {
                timer = 0;
                roundhousing = false;
                animator.SetBool("isRoundhousing", roundhousing);
                attackAreaBKick.SetActive(roundhousing);
            }
        }

        if(uppercutting)
        {
            timer += Time.deltaTime;

            if(timer >= timeToAttack)
            {
                timer = 0;
                uppercutting = false;
                animator.SetBool("isUppercutting", uppercutting);
                attackAreaUpper.SetActive(uppercutting);
            }
        }
    }

    private void Attack()
    {
        attacking = true;
        animator.SetBool("isAttacking", attacking);
        attackAreaJab.SetActive(attacking);
    }

    private void ShortKick()
    {
        shortkicking = true;
        animator.SetBool("isShortKicking", shortkicking);
        attackAreaSKick.SetActive(shortkicking);
    }

    private void Roundhouse()
    {
        roundhousing = true;
        animator.SetBool("isRoundhousing", roundhousing);
        attackAreaBKick.SetActive(roundhousing);
    }

    private void Uppercut()
    {
        uppercutting = true;
        animator.SetBool("isUppercutting", uppercutting);
        attackAreaUpper.SetActive(uppercutting);
    }
}
