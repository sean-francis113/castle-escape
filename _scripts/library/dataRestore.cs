using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class dataRestore {

	public static void restorePlayerDef()
    {

        Debug.Log("Player Data Reset");

        player.facingRight = false;
        player.isPaused = false;
        player.isDashing = false;

        player.speed = 8.0f;
        player.dashSpeed = 16.0f;
        player.jumpForce = 12.0f;
        player.attackDelay = 0.5f;
        player.footfallDelay = 0.5f;
        player.stunDelay = 0.5f;
        player.invulDelay = 0.25f;
        player.invulTimer = 0.0f;
        player.runTime = 0.0f;
        player.dashDelay = 0.25f;
        player.dashTime = 0.75f;
        player.flashDelay = 0.1f;
        player.flashTimer = 0.0f;

        player.maxHealth = 4;
        player.health = 4;
        player.damage = 1;
        player.enemiesKilled = 0;
        player.floorsCleared = 0;
        player.maxClear = 5;

        pController.moveState = PlayerMoveState.NULL;
        pController.actionState = PlayerActionState.NULL;

        player.restoreFacing();

    }

    public static void restoreLevelDef()
    {

        Debug.Log("Level Data Reset");

        levelData.enemiesAlive = 0;

    }

    public static void restoreTimerDef()
    {

        Debug.Log("Timer Data Reset");

        nLevelTimer.timerLength = 60.0f;
        nLevelTimer.intervalTime = 20.0f;
        bLevelTimer.timerLength = 120.0f;
        bLevelTimer.intervalTime = 30.0f;

    }

    public static void restoreAllDef()
    {

        restorePlayerDef();
        restoreLevelDef();
        restoreTimerDef();
        Debug.Log("Restored All Defaults");

    }

}
