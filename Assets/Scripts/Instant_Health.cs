using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instant_Health : MonoBehaviour
{
  public int multiplier = 5;
public void OnTriggerEnter2D(Collider2D other){
if(other.CompareTag("Player")){
    Pickup(other);
}
}
    public void Pickup(Collider2D player)
    {
       Health playerScript = player.GetComponent<Health>();
       playerScript.Heal(multiplier);
        Destroy(gameObject);
    } 
}
