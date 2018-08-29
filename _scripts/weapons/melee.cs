/*
 ************************************************
 * Name: melee.cs
 * Updated: 11/4/2017
 * Author: Sean Francis
 * Description: Spawning and Destroying Weapon
 *              When a Character Attacks.
 ************************************************
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class melee : MonoBehaviour {

	public float attackTime;
    public int damage;
    
    private string tag;
    private Collider2D[] colliderList;
	
	// Update is called once per frame
	void Update () {
		
        if(attackTime > 0.0f){
            
            attackTime -= Time.deltaTime;
            
        } else {
            
            Destroy(this.gameObject);
            
        }
        
	}
    
    void setTarget(string target){
        
        tag = target;
        
    }
    
    void OnTriggerEnter2D(Collider2D other){
        
        colliderList = Physics2D.OverlapBoxAll(this.gameObject.transform.position, GetComponent<BoxCollider2D>().size, 90.0f);
        
        for(int i = 0; i < colliderList.Length; i++){
            
            if(other.tag == "shield"){
            
                break;
            
            } else if(other.tag == tag){
            
                other.gameObject.SendMessage("applyDamage", damage);
            
            }
        
        }
        
    }
    
}
