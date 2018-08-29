/*
 ************************************************
 * Name: shieldAI.cs
 * Updated: 11/4/2017
 * Author: Sean Francis
 * Description: The AI Behaviors for Any Shield
 *              Enemy.
 ************************************************
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shieldAI : MonoBehaviour {

    public float turnDelay;
    public float stunDelay;
    public float invulTime;
    public float moveSpeed;
    public float maxSpeed;
    public float flashSpeed;

    public GameObject potion;
    
    public int maxHealth;

    private Animator animCon;

    private bool readyToTurn;
    private bool isStunned;
    private bool visible;
    private bool facingRight;
    
    private float turnTimer;
    private float recordTimer;
    private float stunTimer;
    private float invulDelay;
    private float flashTimer;
    
    private GameObject playerObj;
    
    private int health;
    
    private BoxCollider2D hitBox;
    
    private Rigidbody2D rb;
    
    private Vector3 playerPos;
    private Vector3 lastPlayerPos;
    
    void Start(){
        
        playerObj = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        recordTimer = 1.0f;
        health = maxHealth;
        
        visible = GetComponent<SpriteRenderer>().isVisible;
        hitBox = GetComponent<BoxCollider2D>();
        hitBox.enabled = false;

        animCon = GetComponent<Animator>();
        
    }
    
    void Update(){

        if (!player.clear)
        {

            playerPos = ai.findTarget(playerObj);

            record();
            cooldown();
            checkTurn();

            if (visible)
            {

                if (turnTimer <= 0.0f)
                {

                    checkDirection();

                }
                else
                {

                    turnTimer -= Time.deltaTime;

                    if (turnTimer <= 0.0f)
                    {

                        readyToTurn = true;
                        hitBox.enabled = false;

                    }

                }

                if (readyToTurn)
                {

                    //charMove.flipChar(this.gameObject);
                    readyToTurn = false;

                    if (facingRight)
                    {

                        facingRight = false;

                    }
                    else
                    {

                        facingRight = true;

                    }

                }

            }
            else
            {

                if (this.transform.position.x - playerPos.x > 0)
                {

                    if (facingRight)
                    {

                        facingRight = false;

                    }

                    charMove.hMove(rb, moveSpeed / 4, maxSpeed / 4, "left");

                }
                else if (this.transform.position.x - playerPos.x < 0)
                {

                    if (!facingRight)
                    {

                        facingRight = true;

                    }

                    charMove.hMove(rb, moveSpeed / 4, maxSpeed / 4, "right");

                }

            }

        } else
        {

            charMove.stop(rb);

        }

    }
    
    void cooldown(){
        
        if (invulDelay >= 0.0f) {

			invulDelay -= Time.deltaTime;

		}
        
        if(flashTimer > 0.0f){
            
            flashTimer -= Time.deltaTime;
            
            if(flashTimer <= flashSpeed / 2 && flashTimer > 0.0f) {

                GetComponent<SpriteRenderer>().color = new Vector4(1f, 1f, 1f, 0f);
                
            } else if (flashTimer <= 0.0f){
                
                GetComponent<SpriteRenderer>().color = new Vector4(1f, 1f, 1f, 1f);
                
            }
            
        }

	}
    
    void checkDirection(){
        
        //USE THIS TO DETERMINE DAMAGE!
        //When timer starts, activate the collider/trigger to allow the enemy to take damage.
        
        if(this.transform.position.x - playerPos.x < 0){
            
            if(this.transform.position.x - lastPlayerPos.x > 0){
                
                hitBox.enabled = true;
                turnTimer = turnDelay;
                
            }
            
        } else if(this.transform.position.x - playerPos.x > 0){
            
            if(this.transform.position.x - lastPlayerPos.x < 0){
                
                hitBox.enabled = true;
                turnTimer = turnDelay;
                
            }
            
        }
        
    }
    
    void record(){
        
        if(recordTimer > 0.0f){
            
            recordTimer -= Time.deltaTime;
            
        } else {
            
            recordTimer = 1.0f;
            lastPlayerPos = playerPos;
            
        }
        
    }
    
    void OnCollisionEnter2D(Collision2D other){

		if (other.collider.tag == "enemy") {

			Physics2D.IgnoreCollision (this.GetComponent<Collider2D> (), other.collider);

		}

	}

	void OnCollisionStay2D(Collision2D other){

		if (other.collider.tag == "enemy") {

			Physics2D.IgnoreCollision (this.GetComponent<Collider2D> (), other.collider);

		}

	}
    
    void applyDamage(int damage){
        
        if(invulDelay <= 0.0f){
            
            health -= damage;
        
            invulDelay = invulTime;
            
            flashTimer = flashSpeed;
            GetComponent<SpriteRenderer>().color = new Vector4(1f, 0f, 0f, 1f);
        
            if(health <= 0){

                float randChance = Random.Range(0.0f, 100.0f);

                if (randChance <= 25.0f)
                {

                    Instantiate(potion, this.transform.position, this.transform.rotation);

                }

                levelData.enemiesAlive--;
                player.enemiesKilled++;
                animCon.SetTrigger("dead");
            
            }
            
        }
        
        //stun();
        
    }

    void dead()
    {

        Destroy(this.gameObject);

    }
    
    void OnBecameInvisible() {
        
        visible = false;
        
    }
    
    //Turns off the indicator if object is onscreen.
    void OnBecameVisible() {
        
        visible = true;
        
    }
    
    void checkTurn(){
        
        if(!facingRight){
            
            this.transform.localScale = new Vector3(Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
            
        } else if(facingRight && Mathf.Sign(this.transform.localScale.x) == 1){
            
            this.transform.localScale = new Vector3(-this.transform.localScale.x, this.transform.localScale.y, this.transform.localScale.z);
            
        }
        
    }
    
   /* void stun(){
        
        isStunned = true;
        
        switch(Random.Range(0, 1)){
                
            case 0: rb.AddForce(new Vector2(-100, 0));
                
                break;
                
            case 1: rb.AddForce(new Vector2(100, 0));
                
                break;
        
        }
        
    }*/
    
}
