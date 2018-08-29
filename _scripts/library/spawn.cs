/*
 ************************************************
 * Name: spawn.cs
 * Updated: 11/1/2017
 * Author: Sean Francis
 * Description: Static Class with Functions for
 *              Spawning Enemies.
 ************************************************
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour{
    
    private static GameObject curSpawn;

	public static void spawnSingle(GameObject spawnLocation, GameObject obj){
        
        levelData.enemiesAlive++;
        Instantiate(obj, spawnLocation.transform.position, spawnLocation.transform.rotation);
        
    }
    
    public static void spawnSingle(GameObject[] spawnLocations, GameObject obj){
        
        curSpawn = spawnLocations[Random.Range(0, spawnLocations.Length)];
        
        levelData.enemiesAlive++;
        Instantiate(obj, curSpawn.transform.position, curSpawn.transform.rotation);
        
    }
    
    public static void spawnSingle(GameObject spawnLocation, GameObject obj, int summonNum){
        
        for(int i = 0; i < summonNum; i++){
            
            levelData.enemiesAlive++;
            Instantiate(obj, spawnLocation.transform.position, spawnLocation.transform.rotation);
            
        }
        
    }
    
    public static void spawnSingle(GameObject[] spawnLocations, GameObject obj, int summonNum){
        
        for(int i = 0; i < summonNum; i++){
            
            curSpawn = spawnLocations[Random.Range(0, spawnLocations.Length)];
            
            levelData.enemiesAlive++;
            Instantiate(obj, curSpawn.transform.position, curSpawn.transform.rotation);
            
        }
        
    }
    
    public static void spawnMany(GameObject spawnLocation, GameObject[] obj){
        
        levelData.enemiesAlive++;
        Instantiate(obj[Random.Range(0, obj.Length)], spawnLocation.transform.position, spawnLocation.transform.rotation);
        
    }
    
    public static void spawnMany(GameObject[] spawnLocations, GameObject[] obj){
        
        curSpawn = spawnLocations[Random.Range(0, spawnLocations.Length)];
        
        levelData.enemiesAlive++;
        Instantiate(obj[Random.Range(0, obj.Length)], curSpawn.transform.position, curSpawn.transform.rotation);
        
    }
    
    public static void spawnMany(GameObject spawnLocation, GameObject[] obj, int summonNum){
        
        for(int i = 0; i < summonNum; i++){
            
            levelData.enemiesAlive++;
            Instantiate(obj[Random.Range(0, obj.Length)], spawnLocation.transform.position, spawnLocation.transform.rotation);
            
        }
        
    }
    
    public static void spawnMany(GameObject[] spawnLocations, GameObject[] obj, int summonNum){
        
        for(int i = 0; i < summonNum; i++){
            
            curSpawn = spawnLocations[Random.Range(0, spawnLocations.Length)];
            
            levelData.enemiesAlive++;
            Instantiate(obj[Random.Range(0, obj.Length)], curSpawn.transform.position, curSpawn.transform.rotation);
            
        }
        
    }
    
}
