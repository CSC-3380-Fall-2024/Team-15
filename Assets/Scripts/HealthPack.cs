using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour, IPowerUp
{
   
    public int multiplier = 15;
    public void Activate(GameObject player)
    {
       Health playerScript = player.GetComponent<Health>();
       playerScript.Heal(multiplier);
        Destroy(gameObject);
    }
    
}
