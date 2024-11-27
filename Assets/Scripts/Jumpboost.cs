using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumpboost : MonoBehaviour,IPowerUp
{
     public float jumpAmount = 2f;
    public float duration = 4f;
    
    // This method makes sure when the powerup is activated it starts the routine for the jumpboost
   public void Activate (GameObject player)
    {
          PlayerMove playerMove = player.GetComponent<PlayerMove>();
          if (playerMove != null)
          {
            playerMove.StartCoroutine(ApplyJumpBoost(playerMove));
          }
          Destroy(gameObject);
    }
    // This method enables the jumpboost when its picked up and deletes it when the timer runs out
    private IEnumerator ApplyJumpBoost(PlayerMove playerMove)
    {
      
           
            playerMove.jumpPower *= jumpAmount;

            
            GetComponent<Collider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;

            yield return new WaitForSeconds(duration);
          
            playerMove.jumpPower /= jumpAmount;

         

    }
    
    
}
