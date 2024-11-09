using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
   public float speed;

    public Transform player;
    void Update()
    {
     transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

     if(transform.position.x > player.position.x){
        this.GetComponent<SpriteRenderer>().flipX = true;

     }  
     else{
        this.GetComponent<SpriteRenderer>().flipX = false;
     } 
    }
}
