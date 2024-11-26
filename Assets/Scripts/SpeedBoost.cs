using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class SpeedBoost : MonoBehaviour,IPowerUp
{
    public float boostAmount = 4f;
    public float duration = 4f;
    
    public void Activate (GameObject player)
    {
          PlayerMove playerMove = player.GetComponent<PlayerMove>();
          if (playerMove != null)
          {
            playerMove.StartCoroutine(ApplySpeedBoost(playerMove));
          }
          Destroy(gameObject);
    }
    // This method enables the speedboost when its picked up and deletes it when the timer runs out
    private IEnumerator ApplySpeedBoost(PlayerMove playerMove)
    {
      
           
            playerMove.moveSpeed *= boostAmount;

            
            GetComponent<Collider2D>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;

            yield return new WaitForSeconds(duration);
          
            playerMove.moveSpeed /= boostAmount;

          //  Destroy(gameObject);

    }
    
}
