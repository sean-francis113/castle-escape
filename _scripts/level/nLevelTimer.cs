/*
 ************************************************
 * Name: nLevelTimer.cs
 * Updated: 11/3/2017
 * Author: Sean Francis
 * Description: Behavior for the Non-Boss Rooms'
 *              Timers.
 ************************************************
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nLevelTimer : MonoBehaviour {

    public static float timerLength = 60.0f;
    public static float intervalTime = 20.0f;
    
    public GameObject melee;

    public int endSummonNum;

    private bool summoned = false;
    
    private GameObject[] spawnLocations;
    
    private List<float> milestones;

    private int curInterval;
    
	// Use this for initialization
	void Start () {
        
        milestones = new List<float>();
        spawnLocations = GameObject.FindGameObjectsWithTag("spawn");
        curInterval = 0;

        setMilestones();
		
	}
	
	// Update is called once per frame
	void Update () {
        
        if(!player.clear){
            
            if(timerLength > 0.0f){
        
                timerLength -= Time.deltaTime;
        
            }
            
            if(timerLength <= 0.0f && !summoned){
            
                summoned = true;
                spawn.spawnSingle(spawnLocations, melee, endSummonNum);
            
            }
        
            if((timerLength <= milestones[0] && timerLength >= milestones[1]) && milestones != null){

                curInterval++;
                spawn.spawnSingle(spawnLocations, melee, Random.Range(curInterval, curInterval * 2));
                milestones.Remove(milestones[0]);
            
            }
        
        }
		
	}
    
    void setMilestones(){
        
        //timerLength / spawnInterval is supposed to Add an Index for Each Interval
        for(int i = 1; i <= (timerLength / intervalTime); i++){
            
            milestones.Add(timerLength - (intervalTime * i));
            
        }    
        
    }

}
