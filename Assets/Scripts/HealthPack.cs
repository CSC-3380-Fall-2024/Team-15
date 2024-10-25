using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
   
    public int multiplier = 15;
    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Pickup(other);
        }
    }
    void Pickup(Collider2D player)
    {
       
       Player playerScript = player.GetComponent<Player>();
       playerScript.healthBar.AddHealth(multiplier);
        Destroy(gameObject);
    }
}
