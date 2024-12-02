using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class Tryn_Needle : MonoBehaviour
{
   
    public int multiplier = 2;
    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Pickup(other);
        }
    }
    void Pickup(Collider2D player)
    {
       
       Strength playerScript = player.GetComponent<Strength>();
       playerScript.increasesDamage(multiplier);
        Destroy(gameObject);
    }
}
