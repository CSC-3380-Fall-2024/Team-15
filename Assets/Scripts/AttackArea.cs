using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    private int damage = 3;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.GetComponent<HealthBar>() != null)
        {
            HealthBar health = collider.GetComponent<HealthBar>();
            health.Damage(damage);
        }
    }
}