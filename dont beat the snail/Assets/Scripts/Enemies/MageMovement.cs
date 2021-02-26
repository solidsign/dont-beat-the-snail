using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageMovement : EnemyMovement
{
    public float stopRange;
    private int jumpTimer = 0;
    private void Update()
    {
        horizontalSpeed = 0;

        if (escapeMode && !attacking)
        {
            if (Mathf.Abs(player.position.x - transform.position.x) > stopRange)
            {
                animator.SetBool("running", true);
                if (player.position.x - transform.position.x < 0)
                {
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
                if (jumpTimer == 0)
                {
                    Jump();
                    jumpTimer = 50;
                }
            }
            else
            {
                animator.SetBool("running", false);
            }
        }
        else if (attackMode && !attacking)
        {
            if (Mathf.Abs(player.position.x - transform.position.x) > stopRange)
            {
                animator.SetBool("running", true);
                if (player.position.x - transform.position.x < 0)
                {
                    MoveLeft();
                }
                else
                {
                    MoveRight();
                }
            }
            else
            {
                animator.SetBool("running", false);
            }
        }
        else
        {
            animator.SetBool("running", false);
        }

        if (dmg.stunEffect <= 0) SetVelocity();
    }
    private void FixedUpdate()
    {
        if (jumpTimer != 0)
        {
            jumpTimer--;
        }
    }
}
