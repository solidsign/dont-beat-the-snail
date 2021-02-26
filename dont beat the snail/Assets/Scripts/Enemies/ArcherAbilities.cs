using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherAbilities : EnemyAbilityController
{
    [SerializeField] private float attackCooldown;
    private int timer = 0;
    private Transform player;
    public override void Start()
    {
        base.Start();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        if ((attackMode || rangeAttackMode) && timer == 0 && dmg.stunEffect <= 0)
        {
            if (rangeAttackMode && abilities[0].cooldownTimer == 0)
            {
                movement.attacking = true;
                if (player.position.x - transform.position.x < 0)
                {
                    movement.MoveLeft();
                }
                else
                {
                    movement.MoveRight();
                }
                
                animator.SetTrigger("arrowshoot");
                if (dmg.stunEffect <= 0)
                {
                    Invoke("First", 0.2f);
                    timer = (int)(attackCooldown * 50);
                }
            }
            else if (attackMode && abilities[1].cooldownTimer == 0)
            {
                movement.attacking = true;
                animator.SetTrigger("swordhit");
                if (dmg.stunEffect <= 0)
                {
                    Second();
                    timer = (int)(attackCooldown * 50);
                }
            }
        }
    }
    private void FixedUpdate()
    {
        if (timer != 0)
        {
            timer--;
        }
    }
}
