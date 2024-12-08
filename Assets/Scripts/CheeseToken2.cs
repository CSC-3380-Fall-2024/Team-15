using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseToken2 : MonoBehaviour
{
  public CoinCounter2 cm;

    
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
           cm.coinCount++;
           Destroy(gameObject);
           
        }
    }
}
