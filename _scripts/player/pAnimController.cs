using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pAnimController : MonoBehaviour {

    public GameObject playerWeapon;

    private bool animationPlayed;

    Animator moveAnimCon;
    Animator actionAnimCon;

    private pController pCon;
    private pBreakDanceController pBDCon;

	// Use this for initialization
	void Start () {

        moveAnimCon = GetComponent<Animator>();
        actionAnimCon = playerWeapon.GetComponent<Animator>();

        pCon = GetComponent<pController>();
        pBDCon = GetComponent<pBreakDanceController>();

        Debug.Log("Action Anim Con: " + actionAnimCon.runtimeAnimatorController);
	}
	
	// Update is called once per frame
	void Update () {

        if (pCon != null)
        {

            if (pCon.getActionState() == PlayerActionState.Attacking && pCon.getActionState() != PlayerActionState.Dead)
            {

                Debug.Log("Set Animation Attack True");
                //actionAnimCon.SetBool("isAttacking", true);
                actionAnimCon.SetTrigger("isAttacking");

            }

            if (pCon.getMoveState() == PlayerMoveState.Running && pCon.getActionState() != PlayerActionState.Dead)
            {

                moveAnimCon.SetBool("isWalking", true);
                //moveAnimCon.speed = player.speed;

            }
            else
            {

                moveAnimCon.SetBool("isWalking", false);
                //moveAnimCon.speed = 1.0f;

            }

            if (pCon.getMoveState() == PlayerMoveState.Crouching && pCon.getActionState() != PlayerActionState.Dead)
            {

                moveAnimCon.SetBool("isCrouching", true);

            }
            else
            {

                moveAnimCon.SetBool("isCrouching", false);

            }

            if (pCon.getMoveState() == PlayerMoveState.Jumping && pCon.getActionState() != PlayerActionState.Dead)
            {

                moveAnimCon.SetBool("isJumping", true);

            }
            else
            {

                moveAnimCon.SetBool("isJumping", false);

            }

            if (pCon.getActionState() == PlayerActionState.Dead)
            {

                if (!animationPlayed)
                {

                    animationPlayed = true;
                    moveAnimCon.SetTrigger("dead");

                }
            }

        } else if (pBDCon != null)
        {

            if (pBDCon.getActionState() == PlayerActionState.Attacking && pBDCon.getActionState() != PlayerActionState.Dead)
            {

                Debug.Log("Set Animation Attack True");
                //actionAnimCon.SetBool("isAttacking", true);
                actionAnimCon.SetTrigger("isAttacking");

            }

            if (pBDCon.getMoveState() == PlayerMoveState.Running && pBDCon.getActionState() != PlayerActionState.Dead)
            {

                moveAnimCon.SetBool("isWalking", true);
                //moveAnimCon.speed = player.speed;

            }
            else
            {

                moveAnimCon.SetBool("isWalking", false);
                //moveAnimCon.speed = 1.0f;

            }

            if (pBDCon.getMoveState() == PlayerMoveState.Crouching && pBDCon.getActionState() != PlayerActionState.Dead)
            {

                moveAnimCon.SetBool("isCrouching", true);

            }
            else
            {

                moveAnimCon.SetBool("isCrouching", false);

            }

            if (pBDCon.getMoveState() == PlayerMoveState.Jumping && pBDCon.getActionState() != PlayerActionState.Dead)
            {

                moveAnimCon.SetBool("isJumping", true);

            }
            else
            {

                moveAnimCon.SetBool("isJumping", false);

            }

            if (pBDCon.getActionState() == PlayerActionState.Dead)
            {

                if (!animationPlayed)
                {

                    animationPlayed = true;
                    moveAnimCon.SetTrigger("dead");

                }
            }

        }

    }

}
