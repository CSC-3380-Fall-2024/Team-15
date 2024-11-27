using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class AntiHealthpack : MonoBehaviour
{
    
    public int multiplier = -20;
    public float FollowDuration = 5f;
    public float FollowTimer;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        FollowTimer = FollowDuration;

        if (rb != null)
        {
            rb.gravityScale = 1;
        }
    }
   
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Pickup(other);
        }
    }

   void Pickup(Collider2D player)
   {
    Health PlayerScript = player.GetComponent<Health>();
    PlayerScript.Damage(Mathf.Abs(multiplier));
    Destroy(gameObject);
   }
}
