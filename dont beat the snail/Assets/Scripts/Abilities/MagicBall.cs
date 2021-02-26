using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBall : Ability
{
    public GameObject ball;
    public float launchForce = 4;
    [SerializeField] private float cooldown = 0.3f;
    void Start()
    {
        Cooldown = cooldown;
        abilityID = 5;
        animationDelay = 0f;
        animationName = "magicball";
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
        GameObject shot = Instantiate(ball, transform.GetChild(1).GetComponent<Transform>().position, transform.GetChild(1).GetComponent<Transform>().rotation);
        shot.name = gameObject.name;
        shot.GetComponent<Rigidbody2D>().AddForce(shot.transform.up * launchForce, ForceMode2D.Impulse);
        cooldownTimer = (int)(cooldown * 50f);
        return true;
    }
}
