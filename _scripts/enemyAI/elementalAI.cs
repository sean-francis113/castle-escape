/*
 ************************************************
 * Name: elementalAI.cs
 * Updated: 11/27/2017
 * Author: Sean Francis
 * Description: Controls the AI of the Elemental
 *              Boss.
************************************************
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elementalAI : MonoBehaviour {

    [Header("Attack Values")]
    public float minAtkInterval = 4.0f;
    public float maxAtkInterval = 5.0f;
    public float scaleInterval = 0.5f;
    public GameObject fireballSpawn;
    public GameObject fireball;
    public GameObject pillar;
    public List<GameObject> pillarSpawns;

    [Header("Move Locations")]
    public GameObject upLeft;
    public GameObject midLeft;
    public GameObject lowLeft;
    public GameObject upRight;
    public GameObject midRight;
    public GameObject lowRight;

    [Header("Move Values")]
    public float moveSpeed;

    [Header("Facing")]
    public bool facingRight;

    [Header("Health/Damage Values")]
    public int health = 10;
    public float flashSpeed;
    public float invulTime;

    private ElementalActionState eActionState;
    private ElementalMoveState eMoveState;

    private float attackTimer;
    private float moveTimer;
    private float xHalfwayPoint;
    private float invulDelay;
    private float flashTimer;
    private float moveRate;

    private GameObject lastFireball;
    private GameObject lastPillar;

    private int lastAttack;
    private int pillarsToSummon = 1;
    private int fireballsToSummon = 1;

    private Vector3 pillarScale = new Vector3(20, 20, 1);
    private Vector3 fireballScale = new Vector3(0.25f, 0.25f, 1);
    private Vector3 targetLocation;

	// Use this for initialization
	void Start () {

        pillarSpawns = new List<GameObject>();
        pillarScale = pillar.transform.localScale;
        fireballScale = fireball.transform.localScale;
        //moveRate = 1.0f / moveSpeed;
        //xHalfwayPoint = Vector2.Distance(upLeft.transform.position, upRight.transform.position) / 2;
        setSpawns();
        resetTimer();

	}

    // Update is called once per frame
    void Update() {

        if (!player.clear)
        {

            cooldown();
            checkFacing();
            checkTurn();

            eMoveState = ElementalMoveState.Idle;
            eActionState = ElementalActionState.Idle;

            if (attackTimer <= 0.0f)
            {

                //Recheck this Logic!!
                if (moveTimer >= moveSpeed)
                {

                    chooseTargetLocation();
                    moveTimer = 0.0f;

                }
                else
                {

                    //moveTimer += moveRate * Time.deltaTime;
                    //Debug.Log("Move Timer: " + moveTimer);
                    moveTimer += Time.deltaTime;
                    move();

                    if (moveTimer >= moveSpeed)
                    {

                        attack();
                        resetTimer();

                    }

                }

            }

        }

	}

    void attack()
    {

        int randInt = Random.Range(1, 100);

        if(lastAttack == 0)
        {

            if(randInt <= 50)
            {

                eActionState = ElementalActionState.Throwing;
                fireBall();

            } else
            {

                eActionState = ElementalActionState.SummoningPillars;
                firePillar();

            }

        } else if(lastAttack == 1)
        {

            if (randInt <= 25)
            {

                eActionState = ElementalActionState.Throwing;
                fireBall();

            }
            else
            {

                eActionState = ElementalActionState.SummoningPillars;
                firePillar();

            }

        } else
        {

            if (randInt <= 75)
            {

                eActionState = ElementalActionState.Throwing;
                fireBall();

            }
            else
            {

                eActionState = ElementalActionState.SummoningPillars;
                firePillar();

            }

        }

    }

    void cooldown()
    {

        if (attackTimer > 0.0f)
        {

            attackTimer -= Time.deltaTime;

        }

        if(invulDelay > 0.0f)
        {

            invulDelay -= Time.deltaTime;

        }

        if (flashTimer > 0.0f)
        {

            flashTimer -= Time.deltaTime;

            if(flashTimer <= flashSpeed / 2 && flashTimer > 0)
            {

                GetComponent<SpriteRenderer>().color = new Vector4(1f, 1f, 1f, 0f);

            }

            if (flashTimer <= 0.0f)
            {

                GetComponent<SpriteRenderer>().color = new Vector4(1f, 1f, 1f, 1f);

            }

        }

    }

    void fireBall()
    {

        lastAttack = 1;
        lastFireball = Instantiate(fireball, fireballSpawn.transform.position, fireballSpawn.transform.rotation);
        lastFireball.transform.localScale = fireballScale;

        Debug.Log("Summoned Fireball");

    }

    void firePillar()
    {

        lastAttack = 2;
        lastPillar = Instantiate(pillar, pillarSpawns[Random.Range(0, pillarSpawns.Count)].transform.position, pillarSpawns[Random.Range(0, pillarSpawns.Count)].transform.rotation);
        lastPillar.transform.localScale = pillarScale;

        Debug.Log("Summoned Pillar");

    }

    private void chooseTargetLocation()
    {

        switch(Random.Range(1, 6))
        {

            case 1: targetLocation = upLeft.transform.position;
                break;
            case 2:
                targetLocation = midLeft.transform.position;
                break;
            case 3:
                targetLocation = lowLeft.transform.position;
                break;
            case 4:
                targetLocation = upRight.transform.position;
                break;
            case 5:
                targetLocation = midRight.transform.position;
                break;
            case 6:
                targetLocation = lowRight.transform.position;
                break;

        }

    }

    private void move()
    {

        eMoveState = ElementalMoveState.Moving;
        this.transform.position = Vector2.Lerp(this.transform.position, targetLocation, moveTimer);

    }

    private void resetTimer()
    {

        attackTimer = Random.Range(minAtkInterval, maxAtkInterval);

    }

    private void checkFacing()
    {

        if(this.transform.position == upLeft.transform.position || this.transform.position == midLeft.transform.position || this.transform.position == lowLeft.transform.position)
        {

            facingRight = true;

        } else if(this.transform.position == upRight.transform.position || this.transform.position == midRight.transform.position || this.transform.position == lowRight.transform.position)
        {

            facingRight = false;

        }

    }

    void checkTurn()
    {

        if (facingRight)
        {

            this.transform.localScale = new Vector3(Mathf.Abs(this.transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);

        }
        else if (!facingRight && Mathf.Sign(this.transform.localScale.x) == 1)
        {

            this.transform.localScale = new Vector3(-this.transform.localScale.x, this.transform.localScale.y, this.transform.localScale.z);

        }

    }

    public void milestoneHit()
    {

        switch(Random.Range(1, 2))
        {

            case 1: fireballScale = new Vector3(fireballScale.x * 2, fireballScale.y * 2, fireballScale.z);
                break;
            case 2: pillarScale = new Vector3(pillarScale.x * 2, pillarScale.y * 2, pillarScale.z);
                break;

                /*
            case 3: fireballsToSummon++;
                break;
            case 4: pillarsToSummon++;
                break;
                */

        }

    }

    void applyDamage(int damage)
    {

        if (invulDelay <= 0.0f)
        {

            health -= damage;

            invulDelay = invulTime;

            flashTimer = flashSpeed;
            GetComponent<SpriteRenderer>().color = new Vector4(1f, 0f, 0f, 1f);

            if (health <= 0)
            {

                levelData.enemiesAlive--;
                player.bossesKilled++;
                combat.death(this.gameObject);

            }

        }

        //stun();

    }

    void setSpawns()
    {

        upLeft = GameObject.Find("upLeft");
        midLeft = GameObject.Find("midLeft");
        lowLeft = GameObject.Find("lowLeft");
        upRight = GameObject.Find("upRight");
        midRight = GameObject.Find("midRight");
        lowRight = GameObject.Find("lowRight");

        pillarSpawns.Add(GameObject.Find("pillarLeft"));
        pillarSpawns.Add(GameObject.Find("pillarMidLeft"));
        pillarSpawns.Add(GameObject.Find("pillarMidRight"));
        pillarSpawns.Add(GameObject.Find("pillarRight"));

    }

    public ElementalMoveState getMoveState()
    {

        return eMoveState;

    }

    public ElementalActionState getActionState()
    {

        return eActionState;

    }

}

public enum ElementalMoveState
{

    NULL,
    Idle,
    Moving,

}

public enum ElementalActionState
{

    NULL,
    Idle,
    Throwing,
    SummoningPillars,
    Dead,

}
