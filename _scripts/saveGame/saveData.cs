/*
 ************************************************
 * Name: saveData.cs
 * Updated: 11/12/2017
 * Author: Sean Francis
 * Description: Script Holding All the Data
                That Will Be Saved and Loaded
                Between Playthroughs.
 ************************************************
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class saveData {

	public static saveData current;
    
    //public static List<accolade> allAccolades = new List<accolade>();
    //public static List<accolade> topThree = new List<accolade>();
    
    public float timePlayed = 0.0f;
    
    public int successfulEscapes = 0;
    public int attemptedEscapes = 0;
    public int enemiesKilled = 0;
    public int timersTriggered = 0;
    
}
