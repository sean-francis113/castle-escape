/*
 ************************************************
 * Name: playerDamage.cs
 * Updated: 11/26/2017
 * Author: Sean Francis
 * Description: Script That Handles the Player
 *              Recieving Damage.
 ************************************************
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDamage : MonoBehaviour {
    
    private Rigidbody2D rb;
    
	// Use this for initialization
	void Start () {
		
        rb = GetComponent<Rigidbody2D>();
        
	}
    
    void Update(){
        
        cooldown();
        
    }
    
    void cooldown(){
        
        if(player.invulTimer > 0.0f){
            
            player.invulTimer -= Time.deltaTime;
            
        }
        
        if(player.flashTimer > 0.0f){
            
            player.flashTimer -= Time.deltaTime;

            if(player.flashTimer <= player.flashDelay / 2 && player.flashTimer > 0.0f)
            {

                GetComponent<SpriteRenderer>().color = new Vector4(1f, 1f, 1f, 0f);

            }
            else if (player.flashTimer <= 0.0f){
                
                GetComponent<SpriteRenderer>().color = new Vector4(1f, 1f, 1f, 1f);
                
            }
            
        }
        
    }
	
	void applyDamage(int damage){
        
        if(player.invulTimer <= 0.0f && !player.isDashing){
            
            player.invulTimer = player.invulDelay;
            player.flashTimer = player.flashDelay;
            GetComponent<SpriteRenderer>().color = new Vector4(1f, 0f, 0f, 1f);
            
            player.health -= damage;
            
        } 
        
    }
    
    void stun(){
        
        //player.isStunned = true;
        
        switch(Random.Range(0, 1)){
                
            case 0: rb.AddForce(new Vector2(-100, 0));
                
                break;
                
            case 1: rb.AddForce(new Vector2(100, 0));
                
                break;
        
        }
        
    }
    
}
