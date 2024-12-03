using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Inventory : MonoBehaviour
{
    public List<IPowerUp> inventory = new List<IPowerUp>();
    public int maxInventorySize = 1;
    private GameObject currentPowerup;
    public InventoryUI inventoryUI;
    void OnTriggerEnter2D (Collider2D other)
    {
       IPowerUp powerUp = other.GetComponent<IPowerUp>();
       if (powerUp != null && inventory.Count < maxInventorySize)
       {
        currentPowerup = other.gameObject;
       }
    }

    void OnTriggerExit2D (Collider2D other)
    {
        if (other.gameObject == currentPowerup)
        {
            currentPowerup = null;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && inventory.Count > 0)
        {
            UsePowerUp(0);
        }
        if (Input.GetKeyDown(KeyCode.X) && currentPowerup != null && inventory.Count < maxInventorySize )
        {
            PickupPowerUp();
            inventoryUI.UpdateInventoryUI();
        }
        if (Input.GetKeyDown(KeyCode.O) && inventory.Count > 0)
        {
            DropPowerUp(0);
            inventoryUI.UpdateInventoryUI();
        }
    }
    void PickupPowerUp()
    {
        if (currentPowerup != null)
        {
            IPowerUp powerUp = currentPowerup.GetComponent<IPowerUp>();
            if (powerUp != null)
            {
                inventory.Add(powerUp);
                currentPowerup.SetActive(false);
                currentPowerup = null;
                Debug.Log("Picked up: " + powerUp.GetType().Name);
            }
        }
   
        
       
    }

    void UsePowerUp(int index)
    {
        IPowerUp powerUp = inventory[index];
        powerUp.Activate(gameObject);
        inventory.RemoveAt(index);
        inventoryUI.UpdateInventoryUI();
    }

    void DropPowerUp(int index)
    {
        IPowerUp powerUp = inventory[index];
        GameObject powerUpObj = (powerUp as MonoBehaviour)?.gameObject;
        if (powerUpObj != null)
        {
            powerUpObj.SetActive(true);
            powerUpObj.GetComponent<Collider2D>().enabled = true; 
            powerUpObj.GetComponent<SpriteRenderer>().enabled = true; 
            powerUpObj.transform.position = transform.position + Vector3.right;
            Debug.Log($"Dropped: {powerUpObj.name}");
        }
        inventory.RemoveAt(index);
        inventoryUI.UpdateInventoryUI();
    }
}
