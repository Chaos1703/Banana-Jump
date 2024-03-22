using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScripts : MonoBehaviour
{
    private Rigidbody2D rb;
    public float normalPush = 10f , extraPush = 14f , moveSpeed = 2f;
    private bool initialPush , playerDied;
    private int pushCount;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        initialPush = false;
        playerDied = false;
    }
    void FixedUpdate()
    {
        if(!playerDied)
            move();
    }
    void move(){
        if(Input.GetAxisRaw("Horizontal") > 0){
            rb.velocity = new Vector2(moveSpeed , rb.velocity.y);
        }
        else if(Input.GetAxisRaw("Horizontal") < 0){
            rb.velocity = new Vector2(-moveSpeed , rb.velocity.y);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(playerDied)
            return;
        if(other.tag == "ExtraPush")
        {
            if(!initialPush){
                initialPush = true;
                rb.velocity = new Vector2(rb.velocity.x , 18f);
                other.gameObject.SetActive(false);
                return;
            }
            else{
                rb.velocity = new Vector2(rb.velocity.x , extraPush);
                other.gameObject.SetActive(false);
                SoundManager.instance.JumpSound();
                pushCount++;
            }
        }

        if(other.tag == "NormalPush"){
            rb.velocity = new Vector2(rb.velocity.x , normalPush);
            other.gameObject.SetActive(false);
            SoundManager.instance.JumpSound();
            pushCount++;
        }
        if(pushCount == 2){
            pushCount = 0;
            PlatformScript.instance.SpawnPlatform();
        }

        if(other.tag == "Bird" || other.tag == "FallDown"){
            playerDied = true;  
            SoundManager.instance.GameOverSound();
            GameManager.instance.RestartGame();
        }
    }

}
