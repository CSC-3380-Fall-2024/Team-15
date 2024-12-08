using System.Collections;
using System.Collections.Generic;
using System.Threading;
using JetBrains.Annotations;
using UnityEngine;

public class CheeseToken : MonoBehaviour
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
