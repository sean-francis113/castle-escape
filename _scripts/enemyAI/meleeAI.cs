/*
 ************************************************
 * Name: meleeAI.cs
 * Updated: 11/4/2017
 * Author: Sean Francis
 * Description: The AI Behavior for All Melee
 *              Enemies.
 ************************************************
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meleeAI : MonoBehaviour {

	public float moveSpeed;
	public float maxSpeed;
	public float attackSpeed;
	public float dashSpeed;
	public float moveDrag;
    public float acceptibleDistance;
    public float attackRange;
    public float invulTime;
    public float flashSpeed;
    
    public GameObject weapon;
    public GameObject weaponSpawn;
    public GameObject potion;
    
	public int maxHealth;
    public int damage;

    private Animator animCon;

	private bool facingRight;
	private bool isDashing;

	private float attackDelay;
	private float dashDelay;
    private float invulDelay;
    private float flashTimer;

	private GameObject playerObj;
    
    private int health;
    
	private RaycastHit2D[] platformCircleHit;

	private Rigidbody2D rb;

	private Vector3 targetLocation;
    
	// Use this for initialization
	void Start () {
		
        health = maxHealth;
        playerObj = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        facingRight = true;
        animCon = GetComponent<Animator>();
        
	}
	
	// Update is called once per frame
	void Update () {

        if (!player.clear)
        {
            targetLocation = ai.findTarget(playerObj);

            cooldown();

            if (!ai.closeEnough(this.gameObject.transform.position.x, playerObj.transform.position.x, acceptibleDistance))
            {

                rb.drag = 0;
                Debug.Log("Melee Moving");
                charMove.hMove(rb, moveSpeed, maxSpeed, checkDirection());

            }
            else
            {

                charMove.stop(rb, moveDrag);

                if (attackDelay <= 0.0f)
                {

                    combat.attack(weaponSpawn, weapon, "Player");
                    attackDelay = attackSpeed;

                }

            }

        } else
        {

            charMove.stop(rb);

        }

	}
    
    void cooldown(){
        
        if (invulDelay > 0.0f) {

			invulDelay -= Time.deltaTime;

		}

		if (attackDelay > 0.0f) {

			attackDelay -= Time.deltaTime;

		}
        
        if(flashTimer > 0.0f) {
            
            flashTimer -= Time.deltaTime;

            if(flashTimer <= flashSpeed / 2 && flashTimer > 0.0f)
            {

                GetComponent<SpriteRenderer>().color = new Vector4(1f, 1f, 1f, 0f);

            }

            if (flashTimer <= 0.0f) {
                
                GetComponent<SpriteRenderer>().color = new Vector4(1f, 1f, 1f, 1f);
                
            }
            
        }
        
    }
    
    void OnCollisionEnter2D(Collision2D other){

		if (other.collider.tag == "enemy" || other.collider.tag == "shield") {

			Physics2D.IgnoreCollision (this.GetComponent<Collider2D> (), other.collider);

		}

	}

	void OnCollisionStay2D(Collision2D other){

		if (other.collider.tag == "enemy" || other.collider.tag == "shield") {

			Physics2D.IgnoreCollision (this.GetComponent<Collider2D> (), other.collider);

		}

	}
    
    string checkDirection(){
        
        if(this.transform.position.x - targetLocation.x > 0){
            
            if(facingRight){
                
                charMove.flipChar(this.gameObject);
                facingRight = false;
                
            }
            
            return "left";
            
        } else if(this.transform.position.x - targetLocation.x < 0){
            
            if(!facingRight){
                
                charMove.flipChar(this.gameObject);
                facingRight = true;
                
            }
            
            return "right";
            
        }
        
        return "";
        
    }
    
    void applyDamage(int damage){
        
        if(invulDelay <= 0.0f){
            
            health -= damage;
        
            invulDelay = invulTime;
            
            flashTimer = flashSpeed;
            GetComponent<SpriteRenderer>().color = new Vector4(1f, 0f, 0f, 1f);
        
            if(health <= 0){

                float randChance = Random.Range(0.0f, 100.0f);

                if(randChance <= 25.0f)
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
