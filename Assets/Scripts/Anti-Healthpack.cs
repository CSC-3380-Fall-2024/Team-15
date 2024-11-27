using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using Unity.VisualScripting;
using UnityEngine;

public class AntiHealthpack : MonoBehaviour,IPowerUp
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
   
    public void Activate(GameObject player)
    {
        Health playerHealth = player.GetComponent<Health>();
        if (playerHealth != null)
        {
            playerHealth.Damage(Mathf.Abs(multiplier));
        }
        Destroy(gameObject);
    }
}
