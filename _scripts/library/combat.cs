/*
 ************************************************
 * Name: combat.cs
 * Updated: 11/3/2017
 * Author: Sean Francis
 * Description: Static Class with Functions for
 *              Combat.
 ************************************************
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class combat : MonoBehaviour{

    private static GameObject createdProjectile;
    private static GameObject createdWeapon;
    
    private static RaycastHit2D[] attackHit;
    
	public static void attack(GameObject obj, float attackRange, Vector3 direction, string target, int damage){
        
		Debug.Log ("Called Attack Function");

        attackHit = Physics2D.CircleCastAll(obj.transform.position, 0.5f, direction, attackRange);
        
        for(int i = 0; i < attackHit.Length; i++){
            
            if(attackHit[i].collider.tag == "shield"){
                
                break;
                
            } else if(attackHit[i].collider.tag == target){
                
                attackHit[i].collider.gameObject.SendMessage("applyDamage", damage);  
                
            }
            
        }
        
	}
    
    public static void attack(GameObject spawn, GameObject weapon, string target){
        
        createdWeapon = Instantiate(weapon, spawn.transform);
        createdWeapon.SendMessage("setTarget", target);
        
    }

	public static void shoot(GameObject spawn, Vector3 direction, GameObject projectile, float shootSpeed, GameObject target, bool facingRight){

        Debug.Log ("Called Shoot Function");

		createdProjectile = Instantiate (projectile, spawn.transform.position, spawn.transform.rotation);

        if (!facingRight)
        {

            createdProjectile.transform.localScale = new Vector3(-createdProjectile.transform.localScale.x, createdProjectile.transform.localScale.y, createdProjectile.transform.localScale.z);

        }

		createdProjectile.SendMessage ("setTarget", target);

	}

	public static void lob(string path, GameObject projectile, string target){

		Debug.Log ("Called Lob Function");

	}
    
    public static void death(GameObject obj){
        
        Destroy(obj);
        
    }
    
    public static void playerDeath(){
        
        //player.isDead = true;
        
    }

}
