using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strength : MonoBehaviour
{
   public int strength = 6;
   public int maxStrength = 12;
  
    
    public void increasesDamage(int increase){
        strength += increase;
        if(strength >= maxStrength){
            strength = maxStrength;
        }
    }
    public void decreasesDamage(int decrease){
        strength -= decrease;
        if(strength <= 0){
            strength = 1;
        }
    }

}
