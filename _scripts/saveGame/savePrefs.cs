using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class savePrefs : MonoBehaviour {

    public static int prefSlot;
    
	public static void save(){
        
        if(prefSlot == 1){
        
            PlayerPrefs.SetFloat("slot1PlayTime", PlayerPrefs.GetFloat("slot1PlayTime") + player.runTime);
            
            PlayerPrefs.SetInt("slot1EnemyKills", PlayerPrefs.GetInt("slot1EnemyKills") + player.enemiesKilled);

            PlayerPrefs.SetInt("slot1BossKills", PlayerPrefs.GetInt("slot1BossKills") + player.bossesKilled);
            
            if(PlayerPrefs.GetInt("slot1Saved") == 0){
                
                PlayerPrefs.SetInt("slot1Saved", 1);
                
            }
        
        } else if(prefSlot == 2){
        
            PlayerPrefs.SetFloat("slot2PlayTime", PlayerPrefs.GetFloat("slot2PlayTime") + player.runTime);
            
            PlayerPrefs.SetInt("slot2EnemyKills", PlayerPrefs.GetInt("slot2EnemyKills") + player.enemiesKilled);

            PlayerPrefs.SetInt("slot2BossKills", PlayerPrefs.GetInt("slot2BossKills") + player.bossesKilled);

            if (PlayerPrefs.GetInt("slot2Saved") == 0){
                
                PlayerPrefs.SetInt("slot2Saved", 1);
                
            }
        
        } else if(prefSlot == 3){
        
            PlayerPrefs.SetFloat("slot3PlayTime", PlayerPrefs.GetFloat("slot3PlayTime") + player.runTime);
            
            PlayerPrefs.SetInt("slot3EnemyKills", PlayerPrefs.GetInt("slot3EnemyKills") + player.enemiesKilled);

            PlayerPrefs.SetInt("slot3BossKills", PlayerPrefs.GetInt("slot3BossKills") + player.bossesKilled);

            if (PlayerPrefs.GetInt("slot3Saved") == 0){
                
                PlayerPrefs.SetInt("slot3Saved", 1);
                
            }
        
        }
        
    }
    
    public static void delete(){
        
        if(prefSlot == 1){
        
            PlayerPrefs.SetFloat("slot1PlayTime", 0);
            
            PlayerPrefs.SetInt("slot1EnemyKills", 0);

            PlayerPrefs.SetInt("slot1BossKills", 0);
            
            if(PlayerPrefs.GetInt("slot1Saved") == 1){
                
                PlayerPrefs.SetInt("slot1Saved", 0);
                
            }
        
        } else if(prefSlot == 2){
        
            PlayerPrefs.SetFloat("slot2PlayTime", 0);
            
            PlayerPrefs.SetInt("slot2EnemyKills", 0);

            PlayerPrefs.SetInt("slot2BossKills", 0);

            if (PlayerPrefs.GetInt("slot2Saved") == 1){
                
                PlayerPrefs.SetInt("slot2Saved", 0);
                
            }
        
        } else if(prefSlot == 3){
        
            PlayerPrefs.SetFloat("slot3PlayTime", 0);
            
            PlayerPrefs.SetInt("slot3EnemyKills", 0);

            PlayerPrefs.SetInt("slot3BossKills", 0);

            if (PlayerPrefs.GetInt("slot3Saved") == 1){
                
                PlayerPrefs.SetInt("slot3Saved", 0);
                
            }
        
        }
        
    }
    
    public static void reset(){
        
        if(prefSlot == 1){
        
            PlayerPrefs.SetFloat("slot1PlayTime", 0);
            
            PlayerPrefs.SetInt("slot1EnemyKills", 0);
        
        } else if(prefSlot == 2){
        
            PlayerPrefs.SetFloat("slot2PlayTime", 0);
            
            PlayerPrefs.SetInt("slot2EnemyKills", 0);
        
        } else if(prefSlot == 3){
        
            PlayerPrefs.SetFloat("slot3PlayTime", 0);
            
            PlayerPrefs.SetInt("slot3EnemyKills", 0);
        
        }
        
    }
    
}
