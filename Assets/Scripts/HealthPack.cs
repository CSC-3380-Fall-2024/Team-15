using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
   
    public int multiplier = 15;
    void OnTriggerEnter2D (Collider2D other)
    {
        Debug.Log("Triggered by: " + other.name);
        if (other.CompareTag("Player"))
        {
            Debug.Log("player collided with pack");
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
