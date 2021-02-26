using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicShield : Ability
{
    [SerializeField] private float cooldown = 5f;
    [SerializeField] private float duration = 5f;
    [SerializeField] private GameObject shield;
    private int timer;
    private void Start()
    {
        Cooldown = cooldown;
        abilityID = 6;
        animationDelay = 0f;
        animationName = "magicshield";
    }
    private void FixedUpdate()
    {
        if(cooldownTimer != 0)
        {
            cooldownTimer--;
        }
        if(timer != 0)
        {
            timer--;
        }
    }
    private void Update()
    {
        if(timer == 1)
        {
            shield.GetComponent<Animator>().SetTrigger("end");
            GameObject.FindObjectOfType<AudioController>().Play("magicshieldend");
            Invoke("Deactivate", 0.2f);
        }
    }
    public override bool Activate()
    {
        if (cooldownTimer != 0) return false;

        timer = (int)(duration * 50);
        cooldownTimer = (int)(cooldown * 50) + timer;
        shield.SetActive(true);
        GameObject.FindObjectOfType<AudioController>().Play("magicshield");
        return true;
    }
    private void Deactivate()
    {
        shield.SetActive(false);
    }
}
