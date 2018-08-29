using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pBreakDanceController : MonoBehaviour {

    Rigidbody2D rb2d;

    [Header("Movement Values")]
    public bool isStunned = false;
    public float dashTimer = 0.75f;
    public float dashLength = 0.25f;
    public bool dashRight;

    [Header("Jumping Values")]
    public float groundingRange = 0.1f;
    public float vertRange = 0.25f;
    public bool isGrounded = false;

    [Header("Attack Values")]
    public GameObject weaponSpawn;
    public GameObject weapon;
    public string attackTarget = "enemy";
    public float attackTimer = 0.0f;

    [Header("States")]
    public static PlayerMoveState moveState;
    public static PlayerActionState actionState;

    [Header("Keys")]
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode attackKey = KeyCode.Mouse0;
    public KeyCode pauseKey = KeyCode.Escape;
    public KeyCode dashKey = KeyCode.LeftShift;
    public KeyCode duckKey = KeyCode.S;

    [Header("Joystick Buttons")]
    public KeyCode joyJumpKey = KeyCode.JoystickButton0;
    public KeyCode joyAttackKey = KeyCode.JoystickButton2;
    public KeyCode joyPauseKey = KeyCode.JoystickButton7;
    public KeyCode joyDashKey = KeyCode.JoystickButton3;

    private bool UIShowing = false;

    private BoxCollider2D blockArea;

    private float duckTimer = 0.0f;

    private gameOver gOver;
    private victory victory;

    // Use this for initialization
    void Start()
    {

        rb2d = GetComponent<Rigidbody2D>();
        rb2d.freezeRotation = true; //don't want rotation with this! Will make our character fall over.

        blockArea = GetComponent<BoxCollider2D>();

        gOver = GetComponent<gameOver>();
        victory = GetComponent<victory>();

        if (player.clear)
        {

            player.clear = false;

        }

    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log("Move State: " + moveState);
        Debug.Log("Action State: " + actionState);

        //checkDeath();

        //checkEndGame();

        if (actionState != PlayerActionState.Dead && player.clear == false)
        {

            //movestate will be updated before frame is rendered.
            //moveState = PlayerMoveState.Idle;
            //actionState = PlayerActionState.Idle;

            //checkCheat();

            cooldown();

            //apply horizontal movement and Jump when called
            ApplyMovement();

            //Apply Actions to Player when Called
            checkAction();

            updatePlayTime();

            checkPause();

            //check for ground when falling.
            if (!isGrounded)
            {

                if (rb2d.velocity.y <= 0)
                {

                    moveState = PlayerMoveState.Falling;
                    GroundCast();

                }

                else
                {

                    moveState = PlayerMoveState.Jumping;

                }

            }

        }

    }


    public void ApplyMovement()
    {

        //horizontal movement uses 'Get Axis' to interpolate up to full speed when walking.
        //Also allows for variable movement speed when using Joysticks

        Debug.Log("Horizontal Axis: " + Input.GetAxis("Horizontal"));
        Debug.Log("Vertical Axis: " + Input.GetAxis("Vertical"));

        bool lastFacingRight = player.facingRight;

        if (Input.GetAxis("Horizontal") < 0 && lastFacingRight)
        {

            player.facingRight = false;
            charMove.flipChar(this.gameObject);

        }
        else if (Input.GetAxis("Horizontal") > 0 && !lastFacingRight)
        {

            player.facingRight = true;
            charMove.flipChar(this.gameObject);

        }

        if (moveState != PlayerMoveState.Dashing)
        {

            rb2d.velocity = new Vector2(Input.GetAxis("Horizontal") * player.speed, rb2d.velocity.y);
            Debug.Log("Player Moving");

            if (Input.GetAxis("Horizontal") != 0)
            {

                moveState = PlayerMoveState.Running;

            }
            else
            {

                moveState = PlayerMoveState.Idle;

            }

            if (Input.GetAxis("Vertical") < 0.0f && moveState != PlayerMoveState.Falling)
            {

                moveState = PlayerMoveState.Crouching;

                Debug.DrawRay(new Vector2(transform.position.x, transform.position.y - 0.8f), Vector3.down * vertRange, Color.red);
                RaycastHit2D[] hit2D = Physics2D.RaycastAll(new Vector2(transform.position.x, transform.position.y - 0.8f), Vector2.down, vertRange);

                if (hit2D != null)
                {

                    for (int i = 0; i < hit2D.Length; i++)
                    {

                        Debug.Log("Trying to Duck. Standing On: " + hit2D[i].collider.tag);

                        if (hit2D[i].collider.tag == "platform")
                        {

                            blockArea.enabled = false;
                            duckTimer = 0.05f;
                            break;

                        }

                    }

                }

            }

            //rigidbody gravity will handle most downwards movement!
            //Use Jump to add velocity upwards.
            if ((Input.GetKeyDown(jumpKey) || Input.GetKeyDown(joyJumpKey)) && moveState != PlayerMoveState.Crouching)
            {

                if (isGrounded && !isStunned)
                {

                    moveState = PlayerMoveState.Jumping;
                    rb2d.velocity += Vector2.up * player.jumpForce;
                    isGrounded = false;

                }

            }

        }
        else
        {

            if (dashRight)
            {

                rb2d.velocity = Vector2.right * player.dashSpeed;

            }
            else
            {

                rb2d.velocity = Vector2.left * player.dashSpeed;

            }

        }

        //if stunned, overwrite movement
        if (isStunned)
        {

            rb2d.velocity = new Vector2(0, rb2d.velocity.y);

        }

        if ((Input.GetKeyDown(dashKey) || Input.GetKeyDown(joyDashKey)) && dashTimer <= 0.0f)
        {

            moveState = PlayerMoveState.Dashing;
            player.isDashing = true;
            dashLength = player.dashDelay;
            dashTimer = player.dashTime;

            if (Input.GetAxis("Horizontal") > 0)
            {

                dashRight = true;

            }
            else if (Input.GetAxis("Horizontal") < 0)
            {

                dashRight = false;

            }
            else
            {

                if (player.facingRight)
                {

                    dashRight = false;

                }
                else
                {

                    dashRight = true;

                }

            }

        }

    }

    public void GroundCast()
    {

        //Draw Ray will show a visual in the scene view as for how long the grounding check is.
        Debug.DrawRay(transform.position, Vector3.down * groundingRange, Color.red);

        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - 0.9f), Vector2.down, groundingRange);

        if (hit.collider != null)
        {

            isGrounded = true;
            Debug.Log(hit.collider.gameObject.name);

        }

    }

    public void checkAction()
    {

        if (Input.GetKeyDown(attackKey) || Input.GetKeyDown(joyAttackKey))
        {

            if (attackTimer <= 0.0f)
            {

                //combat.attack(weaponSpawn, weapon, attackTarget);
                attackTimer = player.attackDelay;

            }

            if (attackTimer > 0.0f)
            {

                actionState = PlayerActionState.Attacking;

            }
            else
            {

                actionState = PlayerActionState.Idle;

            }

        }

    }

    public void checkDeath()
    {

        if (player.health <= 0)
        {

            actionState = PlayerActionState.Dead;
            rb2d.velocity = Vector2.zero;

        }
        else
        {

            actionState = PlayerActionState.Idle;

        }

    }

    public void updatePlayTime()
    {

        player.runTime += Time.deltaTime;

    }

    public void checkPause()
    {

        if (Input.GetKeyDown(pauseKey) || Input.GetKeyDown(joyPauseKey))
        {

            if (player.isPaused)
            {

                levelData.pauseUI.SetActive(false);
                levelData.gameUI.SetActive(true);
                Cursor.visible = false;
                Time.timeScale = 1.0f;

            }
            else
            {

                levelData.pauseUI.SetActive(true);
                levelData.gameUI.SetActive(false);
                Cursor.visible = true;
                Time.timeScale = 0.0f;

            }

        }

    }

    public void cooldown()
    {

        if (dashLength > 0.0f)
        {

            dashLength -= Time.deltaTime;

            if (dashLength <= 0.0f)
            {

                moveState = PlayerMoveState.Idle;
                player.isDashing = false;

            }

        }

        if (dashTimer > 0.0f)
        {

            dashTimer -= Time.deltaTime;

        }

        if (attackTimer > 0.0f)
        {

            attackTimer -= Time.deltaTime;

            if (attackTimer <= 0.0f)
            {

                actionState = PlayerActionState.Idle;

            }

        }

        if (duckTimer > 0.0f)
        {

            duckTimer -= Time.deltaTime;

            if (duckTimer <= 0.0f)
            {

                blockArea.enabled = true;
                duckTimer = 0.25f;

            }

        }

    }

    void checkEndGame()
    {

        if (levelData.enemiesAlive <= 0 && !player.clear)
        {

            rb2d.velocity = Vector2.zero;

            if (!player.clear)
            {

                player.floorsCleared++;
                player.clear = true;

            }

            if ((player.floorsCleared < player.maxClear) && UIShowing == false)
            {

                UIShowing = true;
                victory.moveOn();

            }
            else if ((player.floorsCleared >= player.maxClear) && UIShowing == false)
            {

                UIShowing = true;
                victory.endGame();

            }

        }

    }

    void dead()
    {

        rb2d.velocity = Vector2.zero;

        if (!player.clear)
        {

            player.clear = true;

        }

        if (UIShowing == false)
        {

            UIShowing = true;
            gOver.endGame();

        }

    }

    public PlayerMoveState getMoveState()
    {

        return moveState;

    }

    public PlayerActionState getActionState()
    {

        return actionState;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (moveState == PlayerMoveState.Dashing)
        {

            if (collision.collider.tag != "floor" && collision.collider.tag != "platform" && collision.collider.tag != "wall")
            {

                Physics2D.IgnoreCollision(this.blockArea, collision.collider);

            }

        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {

        if (moveState == PlayerMoveState.Dashing)
        {

            if (collision.collider.tag != "floor" && collision.collider.tag != "platform" && collision.collider.tag != "wall")
            {

                Physics2D.IgnoreCollision(this.blockArea, collision.collider);

            }

        }

    }

}