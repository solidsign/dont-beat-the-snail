using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBlast : Ability
{
    [SerializeField] private float cooldown = 5f;
    [SerializeField] private GameObject blast;
    private void Start()
    {
        Cooldown = cooldown;
        abilityID = 7;
        animationDelay = 0f;
        animationName = "magicblast";
    }
    private void FixedUpdate()
    {
        if (cooldownTimer != 0)
        {
            cooldownTimer--;
        }
    }
    public override bool Activate()
    {
        if (cooldownTimer != 0) return false;

        cooldownTimer = (int)(cooldown * 50);
        blast.SetActive(true);
        blast.GetComponent<MagicBlastController>().Activate();
        return true;
    }
}
