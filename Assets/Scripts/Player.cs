using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        healthBar.SetMaxHealth(100);
        healthBar.SetHealth(75);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
