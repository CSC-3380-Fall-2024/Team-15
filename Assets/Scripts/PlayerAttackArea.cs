using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackArea : MonoBehaviour
{
    public Strength damget;
    private int damage;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        damget.strength = damage;
        if(collider.GetComponent<EnemyHealth>() != null)
        {
            EnemyHealth health = collider.GetComponent<EnemyHealth>();
            health.Damage(damage);
        }
    }
}
