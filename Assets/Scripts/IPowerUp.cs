using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This creates a method for every powerup and helps with the inventory system
public interface IPowerUp
{
    void Activate(GameObject player);
}
