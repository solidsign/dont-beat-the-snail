using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightAbilities : EnemyAbilityController
{
    [SerializeField] private float attackCooldown;
    private int timer = 0;
    private void Update()
    {
        if (attackMode && timer == 0 && dmg.stunEffect <= 0)
        {
            if (abilities[0].cooldownTimer == 0)
            {
                movement.attacking = true;
                animator.SetTrigger("swordkick");
                if(dmg.stunEffect <= 0)
                {
                    Invoke("First", 0.2f);
                    timer = (int)(attackCooldown * 50);
                }
            }
            else if(abilities[1].cooldownTimer == 0)
            {
                movement.attacking = true;
                animator.SetTrigger("swordhit");
                if(dmg.stunEffect <= 0)
                {
                    Second();
                    timer = (int)(attackCooldown * 50);
                }
            }
        }
    }
    private void FixedUpdate()
    {
        if(timer != 0)
        {
            timer--;
        }
    }
}
