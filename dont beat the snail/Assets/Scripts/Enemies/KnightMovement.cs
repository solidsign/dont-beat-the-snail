using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightMovement : EnemyMovement
{
    public float stopRange;
    private void Update()
    {
        horizontalSpeed = 0;

        if (attackMode && !attacking)
        {
            if(Mathf.Abs(player.position.x - transform.position.x) > stopRange)
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

        if(dmg.stunEffect <= 0) SetVelocity();
    }
    
}
