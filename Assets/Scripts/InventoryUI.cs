using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    public TMP_Text inventoryText;
    public Inventory inventory;

    // Start is called before the first frame update
    void Start()
    {
        UpdateInventoryUI();
    }

    // Update is called once per frame
    public void UpdateInventoryUI()
    {
        if (inventory.inventory.Count > 0)
        {
            inventoryText.text = "Power-Up: " + inventory.inventory[0].GetType().Name;
        }
        else
        {
            inventoryText.text = "No Power-up";
        }
    }
}
