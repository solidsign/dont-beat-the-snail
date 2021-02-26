using System.Collections.Generic;
using UnityEngine;

public class AbilityController : MonoBehaviour
{
    public List<Ability> abilities;
    private Animator animator;
    [HideInInspector] public bool attacking;
    private PlayerHP hp;
    public FirstAbilityUI firstUI;
    public SecondAbilityUI secondUI;
    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        hp = GetComponent<PlayerHP>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(Inputs.firstAbility))
        {
            if(abilities[0].cooldownTimer == 0 && hp.stunEffect <= 0 && !attacking)
            {
                attacking = true;
                animator.SetTrigger(abilities[0].animationName);
                Invoke("First", abilities[0].animationDelay);
            }
        }

        if (Input.GetKeyDown(Inputs.secondAbility))
        {
            if (abilities[1].cooldownTimer == 0 && hp.stunEffect <= 0 && !attacking)
            {
                attacking = true;
                animator.SetTrigger(abilities[1].animationName);
                Invoke("Second", abilities[1].animationDelay);
            }
        }
    }

    public void SwitchAbilities(int firstAbilityID, int secondAbilityID)
    {
        abilities[0] = gameObject.GetComponents<Ability>()[FindAbility(firstAbilityID)];
        abilities[1] = gameObject.GetComponents<Ability>()[FindAbility(secondAbilityID)];
        firstUI.Switch();
        secondUI.Switch();
    }

    private int FindAbility(int abilityID)
    {
        for (int i = 0; i < gameObject.GetComponents<Ability>().Length; i++)
        {
            if(gameObject.GetComponents<Ability>()[i].abilityID == abilityID)
            {
                return i;
            }
        }
        return 0;
    }

    private void First()
    {
        if(hp.stunEffect <= 0)
        {
            abilities[0].Activate();
        }
        Invoke("UnsetAttacking", 0.2f);
    }
    private void Second()
    {
        if(hp.stunEffect <= 0)
        {
            abilities[1].Activate();
        }
        Invoke("UnsetAttacking", 0.25f);
    }
    private void UnsetAttacking()
    {
        attacking = false;
    }
}
