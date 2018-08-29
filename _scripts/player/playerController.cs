/*
 ************************************************
 * Name: playerController.cs
 * Updated: 10/30/2017
 * Author: Sean Francis
 * Description: Stores Global Variables for the
 * 				Player.
 ************************************************
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {
    
    /*
    public GameObject weaponSpawn;
    public GameObject sword;
    public GameObject gameUI;
    public GameObject pauseUI;
    
	private float jumpTimer;
	private float attackTimer;
    private float stunTimer;
	private float translateX;

	private Rigidbody2D rb;

	void Start(){

		rb = GetComponent<Rigidbody2D> ();
        levelData.gameUI = GameObject.FindGameObjectWithTag("gameUI");
        levelData.victoryUI = GameObject.FindGameObjectWithTag("victoryUI");
        
		if(levelData.victoryUI != null) levelData.victoryUI.SetActive(false);

	}

	// Update is called once per frame
	void Update () {
        
        if(!player.isDead){
        
            if(player.isStunned){
            
                stunTimer = player.stunDelay;
            
            }

		  cooldown ();

		  player.isGrounded = charMove.checkGrounding (this.gameObject, -2.0f);

            /*if(player.isGrounded){
            
                rb.gravityScale = 1;
            
            }
        
		  Debug.Log ("Grounded: " + player.isGrounded);

		  translateX = Input.GetAxis ("Horizontal");

		  if (translateX > 0 && !player.isStunned) {

                if(!player.facingRight){
			
                    player.facingRight = true;
                    charMove.flipChar(this.gameObject);
            
                }
            
                player.isIdle = false;

			 if (player.isGrounded) {

				    player.isMoving = true;
				    charMove.hMove (rb, player.speed, player.maxSpeed, "right");

			 } else {

				    charMove.hMove (rb, player.speed, player.maxSpeed, translateX);

			 }

		  } else if (translateX < 0 && !player.isStunned) {

                if(player.facingRight){
            
                    player.facingRight = false;
                    charMove.flipChar(this.gameObject);
            
                }
            
                player.isIdle = false;

			 if (player.isGrounded) {

				    player.isMoving = true;
				    charMove.hMove (rb, player.speed, player.maxSpeed, "left");

			 } else {

				    charMove.hMove (rb, player.speed, player.maxSpeed, translateX);

			 }

		  } else {

			 if (player.isGrounded) {

				    charMove.stop (rb, player.moveDrag);

			 }else {

				    charMove.stop (rb, 0);

			 }
            
                player.isIdle = true;

		  }

		  if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0)) && !player.isStunned) {

			 

			 if (player.isGrounded && jumpTimer <= 0.0f) {
					rb.velocity = Vector2.zero;
				    player.isJumping = true;
				    //player.playerAudio.Play("jumpSound");
					Debug.Log ("Jump executed");
                    //rb.gravityScale = 2;
                
                    if(Mathf.Abs(translateX) < 0.5){
						Debug.Log ("HighJUmp");
                        charMove.jump (rb, player.jumpForce * 2);
                
                    } else {
						Debug.Log ("Normal Jump");
                        charMove.jump (rb, player.jumpForce);
                    
                    }
                
				    player.isJumping = false;
				    jumpTimer = player.jumpDelay;

			 }

		  }

		  if ((Input.GetAxis("Vertical") > 0) && !player.isStunned) {

			 player.aimingUp = true;
			 player.isCrouching = false;

		  }

		  if ((Input.GetAxis("Vertical") < 0) && !player.isStunned) {

			 player.isCrouching = true;
			 player.aimingUp = false;

		  }

		  if ((Input.GetAxis ("Fire3") > 0) && !player.isStunned) {

			 if (attackTimer <= 0.0f) {

				 Debug.Log ("Player is Attacking!");
				 charMove.stop (rb);
				 player.isAttacking = true;
                
                 combat.attack(weaponSpawn, sword, "enemy");
                 
				 attackTimer = player.attackDelay;
				 player.isAttacking = false;

			 }

		  }
            
            if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.JoystickButton7)){
                
                if(player.isPaused){
                    
                    player.isPaused = false;
                    unPause();
                    
                } else {
                    
                    player.isPaused = true;
                    pause();
                    
                }
                
            }
            
        }

	}

	void cooldown(){

		if (jumpTimer > 0.0f) {

			jumpTimer -= Time.deltaTime;

		}

		if (attackTimer > 0.0f) {

			attackTimer -= Time.deltaTime;

		}
        
        if(stunTimer > 0.0f) {
            
            stunTimer -= Time.deltaTime;
            
            if(stunTimer <= 0.0f){
                
                player.isStunned = false;
                
            }
            
        }
        
        if(player.invulTimer > 0.0f){
            
            player.invulTimer -= Time.deltaTime;
            
        }

	}
    
    void OnCollisionEnter2D(Collision2D other){
        
        if(other.collider.tag == "enemy" || other.collider.tag == this.tag){
            
            Physics2D.IgnoreCollision (this.GetComponent<Collider2D> (), other.collider);
            
        }   
        
    }
    
    void OnCollisionStay2D(Collision2D other){
        
        if(other.collider.tag == "enemy" || other.collider.tag == this.tag){
            
            Physics2D.IgnoreCollision (this.GetComponent<Collider2D> (), other.collider);
            
        }    
        
    }
    
    public void pause(){
        
        player.isPaused = true;
        gameUI.SetActive(false);
        pauseUI.SetActive(true);
        Cursor.visible = true;
        
        Time.timeScale = 0;
    }
    
    public void unPause(){
        
        player.isPaused = false;
        gameUI.SetActive(true);
        pauseUI.SetActive(false);
        Cursor.visible = false;
        
        Time.timeScale = 1.0f;
        
    }

*/

}
