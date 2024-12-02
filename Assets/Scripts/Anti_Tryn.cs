using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anti_Tryn : MonoBehaviour
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
       playerScript.decreasesDamage(multiplier);
        Destroy(gameObject);
    }
}
