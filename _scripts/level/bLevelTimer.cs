/*
 ************************************************
 * Name: bLevelTimer.cs
 * Updated: 10/30/2017
 * Author: Sean Francis
 * Description: Behavior for the Boss Rooms'
 *              Timers.
 ************************************************
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bLevelTimer : MonoBehaviour {

    public static float timerLength = 120.0f;
    public static float intervalTime = 30.0f;

    private List<float> milestones;

    private GameObject boss;

    // Use this for initialization
    void Start () {

        milestones = new List<float>();
        boss = GameObject.FindGameObjectWithTag("boss");

        setMilestones();

    }
	
	// Update is called once per frame
	void Update () {

        if (!player.clear)
        {

            if (timerLength > 0.0f)
            {

                timerLength -= Time.deltaTime;

            }

            if ((timerLength <= milestones[0] && timerLength >= milestones[1]) && milestones != null)
            {

                boss.SendMessage("milestoneHit");
                milestones.Remove(milestones[0]);

            }

        }

    }

    void setMilestones()
    {

        //timerLength / spawnInterval is supposed to Add an Index for Each Interval
        for (int i = 1; i <= (timerLength / intervalTime); i++)
        {

            milestones.Add(timerLength - (intervalTime * i));

        }

    }

}
