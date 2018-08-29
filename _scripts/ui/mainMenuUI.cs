using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainMenuUI : MonoBehaviour {

    private saveData nullData = new saveData();
    
	// Use this for initialization
	void Start () {
        
        nullData.timePlayed = 0.0f;
        nullData.successfulEscapes = 0;
        nullData.attemptedEscapes = 0;
        nullData.enemiesKilled = 0;
        nullData.timersTriggered = 0;
		
        saveLoadGame.savedGames.Add(nullData);
        saveLoadGame.savedGames.Add(nullData);
        saveLoadGame.savedGames.Add(nullData);
        
	}
    
}
