/*
 ************************************************
 * Name: rangedAI.cs
 * Updated: 11/6/2017
 * Author: Sean Francis
 * Description: The AI Behavior for All Ranged
 *              Enemies.
 ************************************************
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rangedAI : MonoBehaviour {

	public float escapeDistance;
    public float shootDistance;
	public float moveSpeed;
	public float maxSpeed;
	//public float attackSpeed;
	public float minAttackSpeed;
    public float maxAttackSpeed;
    public float projectileForce;
	public float dashSpeed;
	public float moveDrag;
    public float invulTime;
    public float flashSpeed;

	public GameObject projectile;
	public GameObject arrowSpawn;
    public GameObject potion;

	public int maxHealth;

    private Animator animCon;

	private bool wallHit;
	private bool facingRight;
	private bool isDashing;
	private bool isEscaping;
    [SerializeField]
    private bool visible;

	private float attackDelay;
	private float dashDelay;
    private float invulDelay;
    private float flashTimer;

	private GameObject playerObj;

    private int health;
    
	private RaycastHit2D[] leftCircleHit;
	private RaycastHit2D[] rightCircleHit;
	private RaycastHit2D[] platformCircleHit;

	private Rigidbody2D rb;

	private Vector3 targetLocation;

	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody2D> ();
		playerObj = GameObject.FindGameObjectWithTag ("Player");
        
        facingRight = true;
        health = maxHealth;
        attackDelay = Random.Range(minAttackSpeed, maxAttackSpeed);
        
        visible = GetComponent<SpriteRenderer>().isVisible;

        animCon = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {

        if (!player.clear)
        {

            cooldown();

            targetLocation = ai.findTarget(playerObj);

            checkDirection();

            if (visible)
            {

                if (ai.closeEnough(this.transform.position, targetLocation, escapeDistance))
                {

                    isEscaping = true;
                    rb.drag = 0;
                    rb.angularDrag = 0;

                    escape();

                }
                else
                {

                    isEscaping = false;

                    charMove.stop(rb, moveDrag);

                }

                if (attackDelay <= 0 && !isEscaping)
                {

                    if (ai.closeEnough(this.transform.position, targetLocation, shootDistance))
                    {

                        combat.shoot(arrowSpawn, playerObj.transform.position, projectile, projectileForce, playerObj, facingRight);
                        attackDelay = Random.Range(minAttackSpeed, maxAttackSpeed);

                    }

                }

            }
            else
            {

                if (this.transform.position.x - targetLocation.x > 0)
                {

                    charMove.hMove(rb, moveSpeed / 2, maxSpeed / 2, "left");

                }
                else if (this.transform.position.x - targetLocation.x < 0)
                {

                    charMove.hMove(rb, moveSpeed / 2, maxSpeed / 2, "right");

                }

            }

        } else
        {

            charMove.stop(rb);

        }

    }

    void checkDirection()
    {

        if (this.transform.position.x - targetLocation.x > 0)
        {

            facingRight = false;

            this.transform.localScale = new Vector3(Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);

        }
        else if(this.transform.position.x - targetLocation.x < 0 && Mathf.Sign(this.transform.localScale.x) == 1)
        {

            facingRight = true;

            this.transform.localScale = new Vector3(-this.transform.localScale.x, this.transform.localScale.y, this.transform.localScale.z);

        }

    }

	void cooldown(){
        
        if (invulDelay >= 0.0f) {

			invulDelay -= Time.deltaTime;

		}

		if (attackDelay >= 0.0f) {

			attackDelay -= Time.deltaTime;

		}

		if (dashDelay >= 0.0f) {

			dashDelay -= Time.deltaTime;

		}
        
        if(flashTimer > 0.0f) {
            
            flashTimer -= Time.deltaTime;
            
            if(flashTimer <= flashSpeed / 2 && flashTimer > 0.0f)
            {

                GetComponent<SpriteRenderer>().color = new Vector4(1f, 1f, 1f, 0f);
                
            }
            else if(flashTimer <= 0.0f){
                
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

	void escape(){

		leftCircleHit = Physics2D.CircleCastAll (this.transform.position, 1.0f, Vector2.left, escapeDistance * 2);
		rightCircleHit = Physics2D.CircleCastAll (this.transform.position, 1.0f, Vector2.right, escapeDistance * 2);

		for (int i = 0; i < leftCircleHit.Length; i++) {

			if (leftCircleHit [i].collider.tag == "wall") {

                if(!facingRight){
                
                    facingRight = true;
                    charMove.flipChar(this.gameObject);
                    
                }
                
				charMove.hMove (rb, moveSpeed, maxSpeed, "right");

			} else if (leftCircleHit [i].collider.tag == "Player") {

				for (int y = 0; y < rightCircleHit.Length; y++) {

					if (rightCircleHit [y].collider.tag == "wall") {

						wallHit = true;
                        
                        if(facingRight){                            
                        
                            facingRight = false;
                            charMove.flipChar(this.gameObject);
						
                        }
                            
                        charMove.hMove (rb, moveSpeed, maxSpeed, "left");

					} else {
                    
                        if(!facingRight){
                        
                            facingRight = true;
                            charMove.flipChar(this.gameObject);
                        
                        }
                    
					   charMove.hMove (rb, moveSpeed, maxSpeed, "right");

				    }

				}

			}

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
    
    void OnBecameVisible() {
        
        visible = true;
        
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
