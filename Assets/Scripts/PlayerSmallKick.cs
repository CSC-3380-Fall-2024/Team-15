using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSmallKick : MonoBehaviour
{
    public Strength damget;
    private int damage = 4;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        damget.strength = damage;
        if(collider.GetComponent<EnemyHealth>() != null)
        {
            EnemyHealth health = collider.GetComponent<EnemyHealth>();
            health.Damage(damage);
        }
        if(collider.GetComponent<BossHealth>() != null)
        {
            BossHealth health = collider.GetComponent<BossHealth>();
            health.Damage(damage);
        }
    }
}
