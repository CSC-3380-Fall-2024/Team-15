using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class Tryn_Needle : MonoBehaviour,IPowerUp
{
   
    public int multiplier = 2;
    public float duration = 6f;
    public void Activate(GameObject player)
    {
        Strength playerScript = player.GetComponent<Strength>();
         if (playerScript != null)
          {
            playerScript.StartCoroutine(ApplyStrength(playerScript));
          }
          Destroy(gameObject);
    }
   private IEnumerator ApplyStrength(Strength playerScript)
    {
       
       playerScript.increasesDamage(multiplier);
       GetComponent<Collider2D>().enabled = false;
       GetComponent<SpriteRenderer>().enabled = false;
       yield return new WaitForSeconds(duration);
          
        playerScript.strength /= multiplier;
        
    }
}
