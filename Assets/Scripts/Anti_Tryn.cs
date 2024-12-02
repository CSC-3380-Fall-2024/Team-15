using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anti_Tryn : MonoBehaviour,IPowerUp
{
 public int multiplier = 2;
    public float duration = 6f;
    public void Activate(GameObject player)
    {
        Strength playerScript = player.GetComponent<Strength>();
         if (playerScript != null)
          {
            playerScript.StartCoroutine(DecreaseStrength(playerScript));
          }
          Destroy(gameObject);
    }
   private IEnumerator DecreaseStrength(Strength playerScript)
    {
       
       playerScript.decreasesDamage(multiplier);
       GetComponent<Collider2D>().enabled = false;
       GetComponent<SpriteRenderer>().enabled = false;
       yield return new WaitForSeconds(duration);
          
        playerScript.strength /= multiplier;
        
    }
}
