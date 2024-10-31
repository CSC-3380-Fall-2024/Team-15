using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class AntiHealthpack : MonoBehaviour
{
    public GameObject Target;
    public int multiplier = -20;
    public float FollowDuration = 5f;
    public float FollowTimer;

    void Start()
    {
        FollowTimer = FollowDuration;
    }
    void Update()
    {
        if (FollowTimer > 0)
        {
            transform.position = Vector2.MoveTowards(transform.position,Target.transform.position, 5 * Time.deltaTime);
            FollowTimer -= Time.deltaTime;
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
