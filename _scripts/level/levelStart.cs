/*
 ************************************************
 * Name: levelStart.cs
 * Updated: 11/6/2017
 * Author: Sean Francis
 * Description: Runs the Behaviors for When the
 *              Player Enters a New Room.
 ************************************************
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelStart : MonoBehaviour {
    
    public int summonMin;
    public int summonMax;
    
    public GameObject[] minions;
    
    private GameObject[] spawnLocations;

	// Use this for initialization
	void Start () {
        
        Time.timeScale = 1.0f;
        Cursor.visible = false;
		
        spawnLocations = GameObject.FindGameObjectsWithTag("spawn");
        
        spawn.spawnMany(spawnLocations, minions, Random.Range(summonMin, summonMax));
        
	}
    
}
