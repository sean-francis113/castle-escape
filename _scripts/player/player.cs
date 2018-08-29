/*
 ************************************************
 * Name: player.cs
 * Updated: 11/26/2017
 * Author: Sean Francis
 * Description: Stores Global Variables for the
 * 				Player.
 ************************************************
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class player{
    
    public static bool facingRight = false;
    public static bool clear = false;
    public static bool isPaused = false;
    public static bool isDashing = false;
    public static bool defFacingRight = facingRight;

	public static float speed = 8.0f;
    public static float dashSpeed = 20.0f;
	public static float jumpForce = 12.0f;
	public static float attackDelay = 0.5f;
	public static float footfallDelay = 0.5f;
    public static float stunDelay = 0.5f;
    public static float invulDelay = 0.25f;
    public static float invulTimer = 0.0f;
    public static float runTime = 0.0f;
    public static float dashDelay = 0.25f;
    public static float dashTime = 0.75f;
    public static float flashDelay = 0.1f;
    public static float flashTimer = 0.0f;

	public static int maxHealth = 4;
    public static int health = 4;
	public static int damage = 1;
    public static int enemiesKilled = 0;
    public static int bossesKilled = 0;
    public static int floorsCleared = 0;
    public static int maxClear = 5;

    public static void restoreFacing()
    {

        if (!defFacingRight)
        {

            if (facingRight)
            {

                facingRight = false;

            }

        } else
        {

            if (!facingRight)
            {

                facingRight = true;

            }

        }

    }

}
