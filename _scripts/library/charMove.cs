/*
 ************************************************
 * Name: charMove.cs
 * Updated: 10/30/2017
 * Author: Sean Francis
 * Description: Static Class with Functions for
 *              Movement of Characters.
 ************************************************
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class charMove {

	private static Collider2D[] checkColliders = new Collider2D[20];

	private static RaycastHit2D circleHit;
    
    public static void flipChar(GameObject obj){
        
        obj.transform.localScale = new Vector3(obj.transform.localScale.x * -1, obj.transform.localScale.y, obj.transform.localScale.z);        
        
    }

	public static void flipChar(GameObject obj, bool facingRight){

		if (facingRight) {

			obj.transform.localScale = new Vector3(1, obj.transform.localScale.y, obj.transform.localScale.z);

		} else {

			obj.transform.localScale = new Vector3(-1, obj.transform.localScale.y, obj.transform.localScale.z);

		}

	}

	//Moves obj to the Left By Their Speed Over Time
	public static void left(GameObject obj, float speed){

		obj.transform.position += Vector3.left * speed * Time.deltaTime;

	}

	//Uses the CharacterController Reference to Move a Character Left
	public static void left(CharacterController controller, float speed){

		controller.Move (Vector3.left * speed * Time.deltaTime);

	}

	//Uses the Rigidbody to Move an Object
	public static void left(Rigidbody2D rb, float force){

		rb.MovePosition(Vector3.left * force * Time.deltaTime);

	}

	public static void hMove(Rigidbody2D rb, float speed, float maxSpeed, string direction){

		rb.drag = 0;

		if (direction == "left") {

			if (Mathf.Abs (rb.velocity.magnitude) <= maxSpeed) {
				
				rb.AddForce (new Vector2 (-speed, 0));

			}

		} else if (direction == "right") {
			
				if (Mathf.Abs (rb.velocity.magnitude) <= maxSpeed) {
				
					rb.AddForce (new Vector2 (speed, 0));

				}

		}

	}

	public static void hMove(GameObject obj, float speed, float axisValue){

		obj.transform.Translate ((axisValue * speed * Time.deltaTime), 0, 0);

	}

	public static void hMove(Rigidbody2D rb, float speed, float axisValue){

		rb.velocity = new Vector2 ((rb.velocity.x + speed) * axisValue, rb.velocity.y);

	}

	public static void hMove(Rigidbody2D rb, float speed, float maxSpeed, float axisValue){

		rb.AddForce (new Vector2 ((axisValue * speed), 0));
	
	}

	//Moves obj to the Right By Their Speed Over Time
	public static void right(GameObject obj, float speed){

		obj.transform.position += Vector3.right * speed * Time.deltaTime;

	}

	//Pushes the Object with rb by force. Used for Midair Movement
	public static void right(Rigidbody2D rb, float force){

		rb.MovePosition(Vector3.right * force * Time.deltaTime);

	}

	//Uses the CharacterController Reference to Move a Character Right
	public static void right(CharacterController controller, float speed){

		controller.Move (Vector3.right * speed * Time.deltaTime);

	}

	//Pushes obj into the Air By Adding Force to Rigidbody.
	public static void jump(Rigidbody2D rb, float force){

		rb.velocity = new Vector2 (rb.velocity.x, force);

	}

	//Pushes obj into the Air By Adding Force to Rigidbody.
	public static void jump(CharacterController controller, float force){

		controller.Move(Vector3.up * force * Time.deltaTime);

	}

	//Pushes obj into the Air By Adding Diagonal Force to Rigidbody.
	public static void jump(Rigidbody2D rb, float force, string direction){

		if (direction == "left") {

			rb.AddForce((Vector3.up + Vector3.left) * force * Time.deltaTime);

		} else if (direction == "right") {

			rb.AddForce((Vector3.up + Vector3.right) * force * Time.deltaTime);

		}

	}

	//Returns Whether obj is On the Ground or Not
	public static bool checkGrounding(GameObject obj, float offset){

		circleHit = Physics2D.CircleCast (obj.transform.position + new Vector3(0.0f, offset, 0.0f), 0.25f, Vector3.down, 0.5f);
        
        if(circleHit == null) return false;
        
		if (circleHit.collider.tag == "floor" || circleHit.collider.tag == "platform" || circleHit.collider.tag == "shield") {

			return true;

		} else if (circleHit.collider.tag == obj.tag) {

			Debug.Log ("Circle Cast Hitting Self: " + obj.tag);
			return false;

		} else {

			return false;

		}

	}

	public static void stop(Rigidbody2D rb){

		rb.velocity = Vector2.zero;
		rb.angularVelocity = 0;

	}

	public static void stop(Rigidbody2D rb, float drag){

		rb.drag = drag;

	}

}
