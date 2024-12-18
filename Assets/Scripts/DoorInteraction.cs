using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorInteraction : MonoBehaviour
{
    private string bossFightSceneName = "Level1BossArea";
    private bool playerInRange = false;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.O))
        {
            LoadBossFight();
        }
    }

    private void LoadBossFight()
    {
        SceneManager.LoadScene(bossFightSceneName);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            playerInRange = true;
            Debug.Log("Press 'O' to enter Boss fight");
        }
    }
}
