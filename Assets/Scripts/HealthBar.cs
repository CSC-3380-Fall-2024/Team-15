using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    // Public field for the slider component
    public Slider slider;
    
    // To set the maxhealth for whatever sprite you want
    public void SetMaxHealth(int health){
        slider.maxValue = health;
        slider.value = health;

    }
    // Updates the current health value of the slider
    public void SetHealth(int health){
        slider.value = health;
    }
    // Method to add health
    public void AddHealth (int amount)
    {
        SetHealth((int)slider.value + amount);
    }

}
