using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class SpeedBoost : MonoBehaviour
{
    public float boostAmount = 4f;
    public float duration = 4f;
    
    // This method makes sure when the player collides with powerup it picks it up and starts the timer of the pickup method
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
           StartCoroutine(Pickup(other));

        }
    }
    // This method enables the speedboost when its picked up and deletes it when the timer runs out
    IEnumerator Pickup(Collider2D player)
    {
      
            PlayerMove playerMove = player.GetComponent<PlayerMove>();
            playerMove.moveSpeed *= boostAmount;

            
            GetComponent<Collider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;

            yield return new WaitForSeconds(duration);
          
            playerMove.moveSpeed /= boostAmount;

            Destroy(gameObject);

    }
    
}