using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chestrandomizer : MonoBehaviour
{
    public List<GameObject> powerUps;
    public Animator chestAnimator;
    public float openDelay = 0.5f;
    private bool isOpening = false;
    SpriteRenderer spriteRenderer;
    private GameObject player;
    private bool playerInRange = false;
    

    
    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E) && !isOpening)
        {
            OpenChest();
        }
    }
    public void OpenChest()
    {
        if(!isOpening)
        {
            StartCoroutine(OpenChestCoroutine());
        }
    }

    private IEnumerator OpenChestCoroutine()
    {
        isOpening = true;
        chestAnimator.SetTrigger("Open");

        yield return new WaitForSeconds(openDelay);
        Vector3 spawnPosition = transform.position + Vector3.up * 2f; 
        GameObject randomPowerUp = powerUps[Random.Range(0, powerUps.Count)];
        randomPowerUp.SetActive(true);
        GameObject spawnedPowerUp = Instantiate(randomPowerUp, spawnPosition, Quaternion.identity);
        Destroy(gameObject);

       //yield return new WaitForSeconds(1f);
       Debug.Log("Selected Power-Up: " + randomPowerUp.name);
      // Destroy(gameObject);
       isOpening = false;
    }
   
   void OnTriggerEnter2D(Collider2D other)
   {
    if (other.CompareTag("Player"))
    {
        playerInRange = true;
    }
   }

   void OnTriggerExit2D(Collider2D other)
   {
    if (other.CompareTag("Player"))
    {
        playerInRange = false;
    }
   }
}
