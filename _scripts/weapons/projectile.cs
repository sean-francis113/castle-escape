/*
 ************************************************
 * Name: projectile.cs
 * Updated: 11/6/2017
 * Author: Sean Francis
 * Description: The Behavior of Any Projectile
 *              Once Instantiated.
 ************************************************
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour {

	public float destroyDelay;
	public float arrowSpeed;
    public float maxSpeed;

    public int damage;
    
	private float destroyTimer;

	private GameObject target;

	private string targetTag;

	private Vector3 direction;

    private void Start()
    {

        destroyTimer = destroyDelay;

    }

    void Update(){

        if (!player.clear)
        {

            if (destroyTimer >= 0.0f)
            {

                destroyTimer -= Time.deltaTime;

            } else
            {

                Destroy(this.gameObject);

            }

            this.gameObject.transform.position += direction * arrowSpeed;

        }

	}

	public void setTarget(GameObject target){

		this.target = target;
		targetTag = target.tag;
        
        if(this.gameObject.transform.position.x - target.transform.position.x < 0){
            
            direction = Vector2.right;
            
        } else {
            
            direction = Vector2.left;
            
        }

	}

	public void playerShoot(Vector3 direction){

		targetTag = "enemy";
        this.direction = direction;

	}
		
	void OnTriggerEnter2D(Collider2D other){

		if (other.tag == targetTag) {

			other.gameObject.SendMessage ("applyDamage", damage);
			Destroy (this.gameObject);

		} else if (other.tag == "floor" || other.tag == "wall" || (targetTag == "enemy" && other.tag == "shield")) {

			//destroyTimer = destroyDelay;
			Destroy (this.gameObject);

		}
	}

}
