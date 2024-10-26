using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private GameObject attackArea = default;
    private bool attacking = true;
    private float timeToAttack = 0.25f;
    private float timer = 0f;
    void Start()
    {
        attackArea = transform.GetChild(0).gameObject;
    }

    void Update()
    {
        if(Input.GetButton("Fire1"))
        {
            PlayerAttack();
        }

        if(attacking)
        {
            timer += Time.deltaTime;
            if(timer >= timeToAttack)
            {
                timer = 0;
                attacking = false;
                attackArea.SetActive(attacking);
            }
        }
    }

    private void PlayerAttack()
    {
        attacking = true;
        attackArea.SetActive(attacking);
    }
}
