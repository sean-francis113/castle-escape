using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swordAnim : MonoBehaviour {

	Animator animCon;
    
    void Start(){
        
        animCon = GetComponent<Animator>();
        
    }
    
    void Update(){
        
        if(pController.actionState == PlayerActionState.Attacking){
        
            animCon.SetBool("isAttacking", true);
        
        } else {
        
            animCon.SetBool("isAttacking", false);
        
        } 
        
    }
    
    void OnTriggerEnter2D(Collider2D other){
        
        if(other.tag == "enemy"){
            
            other.SendMessage("applyDamage", 1);
            
        }
        
    }
    
}
