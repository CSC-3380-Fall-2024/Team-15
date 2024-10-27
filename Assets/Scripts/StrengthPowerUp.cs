using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    public GameObject pickupEffect;
   
    public int multiplier = 15;
    void OnTriggerEnter (Collider other)
    void OnTriggerEnter2D (Collider2D other)
    {
        Debug.Log("Triggered by: " + other.name);
        if (other.CompareTag("Player"))
        {
            Debug.Log("player collided with pack");
            Pickup(other);
        }
    }
    void Pickup(Collider player)
    void Pickup(Collider2D player)
    {
        Instantiate(pickupEffect, transform.position, transform.rotation);
        HealthBar stats = player.GetComponent<currentStrength>();
        stats.addStrength(multiplier);
       
       Player playerScript = player.GetComponent<Player>();
       playerScript.currentStrength.addStrength(multiplier);
        Destroy(gameObject);
    }
}
}
