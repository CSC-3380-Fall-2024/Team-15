using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCounter : MonoBehaviour
{
    public int coinCount;
    public TMP_Text coinText;
    public GameObject door;
    private bool doorUnlocked;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        coinText.text = "Cheese Count: " + coinCount.ToString();

        if(coinCount == 8 && !doorUnlocked)
        {
            UnlockDoor();
        }
    }
        
        private void UnlockDoor()
        {
            Collider2D doorCollider = door.GetComponent<Collider2D>();
            doorCollider.isTrigger = true;
            doorUnlocked = true;

            
        }
    
}
