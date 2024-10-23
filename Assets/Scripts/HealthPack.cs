using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    public GameObject pickupEffect;
    public int multiplier = 15;
    void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Pickup(other);
        }
    }
    void Pickup(Collider player)
    {
        Instantiate(pickupEffect, transform.position, transform.rotation);
        HealthBar stats = player.GetComponent<HealthBar>();
        stats.AddHealth(multiplier);
        Destroy(gameObject);
    }
}
