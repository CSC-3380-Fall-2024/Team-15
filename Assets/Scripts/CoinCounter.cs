using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCounter : MonoBehaviour
{
    public int coinCount;
    public TMP_Text coinText;
    public GameObject door;
    public Transform doorSpawnLocation;
    public bool doorSpawned = false;


    // Update is called once per frame
    void Update()
    {
        coinText.text = coinCount.ToString();

        if (coinCount >= 10 && doorSpawned == false)
        {
            SpawnDoor();
        }
    }

    void SpawnDoor()
    {
        if (door != null && doorSpawnLocation != null)
        {
            doorSpawned = true;
            Instantiate(door, doorSpawnLocation.position, Quaternion.identity);
            Debug.Log("Door spawned!");
        }
        else
        {
            Debug.LogError("Door prefab or spawn location not assigned!");
        }
    }

}
