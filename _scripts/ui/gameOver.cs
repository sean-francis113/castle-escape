/*
 ************************************************
 * Name: gameOver.cs
 * Updated: 11/26/2017
 * Author: Sean Francis
 * Description: Controls the UI when Player Dies.
************************************************
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameOver : MonoBehaviour {

    public float showButtonTime = 1.0f;

    private float buttonTimer = 0;

    private pController pCon;

    private void Start()
    {

        pCon = GameObject.FindGameObjectWithTag("Player").GetComponent<pController>();

    }

    private void Update()
    {

        if (pCon.getActionState() == PlayerActionState.Dead)
        {

            enableButtons();

        }

    }

    public void endGame(){
        
        Cursor.visible = true;
        levelData.gameUI.SetActive(false);
        levelData.gameOverUI.SetActive(true);
        
    }

    void enableButtons()
    {

        if (buttonTimer < showButtonTime)
        {

            buttonTimer += Time.deltaTime;

            if (buttonTimer >= showButtonTime)
            {

                levelData.gOverContinue.SetActive(true);
                levelData.gOverMainMenu.SetActive(true);

            }

        }

    }

}
