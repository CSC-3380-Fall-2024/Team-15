using System.Collections;
using System.Collections.Generic;
using System.Threading;
using JetBrains.Annotations;
using UnityEngine;

public class CheeseToken : MonoBehaviour
{

    public CoinCounter coinCounter;

    void Start()
    {
        coinCounter = GameObject.Find("GameManager").GetComponent<CoinCounter>();
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
           coinCounter.coinCount++;
           Destroy(gameObject);
           
        }
    }


}
