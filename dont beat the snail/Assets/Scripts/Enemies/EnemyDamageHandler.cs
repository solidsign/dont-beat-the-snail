using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageHandler : Damagable
{
    private void Update()
    {
        if(stunEffect > 0)
        {
            animator.SetBool("stunned", true);
        }
        else
        {
            animator.SetBool("stunned", false);
        }
    }
    override protected void Die()
    {
        dying = true;
        List<Ability> abilities = gameObject.GetComponent<EnemyAbilityController>().abilities;
        GameObject.FindGameObjectWithTag("Player").GetComponent<AbilityController>().SwitchAbilities(abilities[0].abilityID, abilities[1].abilityID);
        transform.GetChild(3).GetComponent<ParticleSystem>().Play();
        stunEffect = 1f;
        GameObject.FindObjectOfType<AudioController>().Play("death");
        Invoke("DestroySelf", 0.2f);
    }
    public override void Damage(float damage)
    {
        base.Damage(damage);
        gameObject.GetComponent<EnemyMovement>().attackMode = true;
    }
    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}
