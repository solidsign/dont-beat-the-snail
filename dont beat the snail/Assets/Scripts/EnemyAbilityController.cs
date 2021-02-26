using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAbilityController : MonoBehaviour
{
    public List<Ability> abilities;
    [HideInInspector] public bool attackMode = false;
    [HideInInspector] public bool rangeAttackMode = false;
    protected Animator animator;
    protected Damagable dmg;
    protected EnemyMovement movement;
    public virtual void Start()
    {
        dmg = GetComponent<Damagable>();
        animator = GetComponentInChildren<Animator>();
        movement = GetComponent<EnemyMovement>();
    }

    protected void First()
    {
        abilities[0].Activate();
        Invoke("UnsetAttacking", 0.25f);
    }
    protected void Second()
    {
        abilities[1].Activate();
        Invoke("UnsetAttacking", 0.25f);
    }
    private void UnsetAttacking()
    {
        movement.attacking = false;

    }
}
