using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class statMenuUI : MonoBehaviour {

	public Text playTime;
    public Text enemiesKilled;
    public Text bossesKilled;
	
	// Update is called once per frame
	void Update () {
		
        if(savePrefs.prefSlot == 1){
            
            playTime.text = string.Format("{0:00} : {1:00}", PlayerPrefs.GetFloat("slot1PlayTime") / 60,    PlayerPrefs.GetFloat("slot1PlayTime") % 60);
        
            enemiesKilled.text = PlayerPrefs.GetInt("slot1EnemyKills").ToString();

            bossesKilled.text = PlayerPrefs.GetInt("slot1BossKills").ToString();

        } else if(savePrefs.prefSlot == 2){
            
            playTime.text = string.Format("{0:00} : {1:00}", PlayerPrefs.GetFloat("slot2PlayTime") / 60,    PlayerPrefs.GetFloat("slot2PlayTime") % 60);
        
            enemiesKilled.text = PlayerPrefs.GetInt("slot2EnemyKills").ToString();

            bossesKilled.text = PlayerPrefs.GetInt("slot2BossKills").ToString();

        } else if(savePrefs.prefSlot == 3){
            
            playTime.text = string.Format("{0:00} : {1:00}", PlayerPrefs.GetFloat("slot3PlayTime") / 60,    PlayerPrefs.GetFloat("slot3PlayTime") % 60);
        
            enemiesKilled.text = PlayerPrefs.GetInt("slot3EnemyKills").ToString();

            bossesKilled.text = PlayerPrefs.GetInt("slot3BossKills").ToString();

        }
        
	}
    
}
