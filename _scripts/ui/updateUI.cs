/*
 ************************************************
 * Name: updateUI.cs
 * Updated: 11/3/2017
 * Author: Sean Francis
 * Description: Constantly Updates the Game UI.
 ************************************************
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class updateUI : MonoBehaviour {
    
    public bool bossLevel;

    public Slider timerSlider;

    public Text timer;
    public Text playerHealth;
    public Text enemyCount;
    public Text floorCount;
    
    private float timerMinutes;
    private float timerSeconds;
    private float timerMax;

    private void Start()
    {

        if (!bossLevel)
        {

            timerMax = nLevelTimer.timerLength;

        }else
        {

            timerMax = bLevelTimer.timerLength;

        }

    }

    // Update is called once per frame
    void Update () {
		
        playerHealth.text = player.health.ToString();
        enemyCount.text = levelData.enemiesAlive.ToString();
        floorCount.text = "" + (player.floorsCleared + 1) + " / " + player.maxClear;
        
        if(!bossLevel){

            /*
            timerMinutes = nLevelTimer.timerLength / 60;
            timerSeconds = nLevelTimer.timerLength % 60;
            
            timer.text = string.Format("{0:00} : {1:00}", (int)timerMinutes, (int)timerSeconds);
            */

            timerSlider.value = nLevelTimer.timerLength / timerMax;

        } else {

            /*
            timerMinutes = bLevelTimer.timerLength / 60;
            timerSeconds = bLevelTimer.timerLength % 60;
            
            timer.text = string.Format("{0:00} : {1:00}", (int)timerMinutes, (int)timerSeconds);
            */

            timerSlider.value = bLevelTimer.timerLength / timerMax;

        }
        
	}
    
}
