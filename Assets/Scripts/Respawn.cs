using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{

    private Vector3 startPosition;
    private Health healthScript;
    private bool isRespawning = false;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update and it saves the position that the player is in
    void Start()
    {
        startPosition = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();

        healthScript = GetComponent<Health>();
    }

    // Update is called once per frame and calls the respawn method and starts the timer 
    void Update()
    {
        if (healthScript != null && healthScript.health <= 0 && !isRespawning)
        {
            StartCoroutine(RespawnPlayer());
           
        }
    }
    // This method deletes the sprite while the timer is going on and once the player respawns it resets the health back to full
    private IEnumerator RespawnPlayer()
    {
        isRespawning = true;
        spriteRenderer.enabled = false;
        yield return new WaitForSeconds(0.5f);
        transform.position = startPosition;
        spriteRenderer.enabled = true;
        healthScript.health = 100;
        healthScript.healthBar.SetMaxHealth(100); 
        healthScript.healthBar.SetHealth(healthScript.health);

        Debug.Log("Player respawned at starting position.");

        isRespawning = false;
    }
}
