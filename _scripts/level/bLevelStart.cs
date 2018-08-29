using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bLevelStart : MonoBehaviour {

    public GameObject[] spawnLocations;
    public GameObject boss;

	// Use this for initialization
	void Start () {

        Time.timeScale = 1.0f;
        Cursor.visible = false;

        spawn.spawnSingle(spawnLocations, boss);

	}

}
