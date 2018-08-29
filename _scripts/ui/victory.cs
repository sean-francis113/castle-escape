/*
 ************************************************
 * Name: victory.cs
 * Updated: 11/26/2017
 * Author: Sean Francis
 * Description: Controls the UI when Player kills
 *              all Enemies.
 ************************************************
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class victory : MonoBehaviour {

    public float showButtonTime = 1.0f;

    private float buttonTimer = 0;
    private bool isEndGame = false;
    private bool isMoveOn = false;

    void Update()
    {

        if (player.clear)
        {

            enableButtons();

        }

    }

    public void endGame(){
        
        Cursor.visible = true;
        levelData.gameUI.SetActive(false);
        levelData.victoryUI.SetActive(true);
        isEndGame = true;
        
        //Time.timeScale = 0;
        
    }
    
    public void moveOn(){
        
        Cursor.visible = true;
        levelData.gameUI.SetActive(false);
        levelData.switchLevelUI.SetActive(true);
        isMoveOn = true;
        
        //Time.timeScale = 0;
        
    }

    void enableButtons()
    {

        if (buttonTimer < showButtonTime)
        {

            buttonTimer += Time.deltaTime;

            if(buttonTimer >= showButtonTime)
            {

                if (isEndGame)
                {

                    levelData.victoryContinue.SetActive(true);
                    levelData.victoryMainMenu.SetActive(true);

                }
                else if (isMoveOn)
                {

                    levelData.moveContinue.SetActive(true);
                    levelData.moveMainMenu.SetActive(true);

                }

            }

        }

    }
    
}
