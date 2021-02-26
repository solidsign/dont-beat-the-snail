using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordKick : Ability
{
    public Transform attackPoint;
    public float hitRange = 1.18f;
    public float attackForce = 20;
    [SerializeField] private float damage = 70;
    [SerializeField] private float stunEffect = 2f;
    [SerializeField] private float cooldown = 1f;

    private void Start()
    {
        Cooldown = cooldown;
        abilityID = 3;
        animationDelay = 0.2f;
        animationName = "swordkick";
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
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(attackPoint.position, hitRange);
        foreach (Collider2D collider in hitColliders)
        {
            if (collider.name != gameObject.name && (collider.CompareTag("Player") || collider.CompareTag("Enemy")))
            {
                Rigidbody2D rb = collider.gameObject.GetComponent<Rigidbody2D>();
                Damagable dmg = collider.gameObject.GetComponent<Damagable>();

                Vector2 direction;
                if (gameObject.GetComponent<Movement>().facingRight)
                {
                    direction = new Vector2(1, 1);
                }
                else
                {
                    direction = new Vector2(-1, 1);
                }

                rb.velocity = Vector2.zero;

                if (dmg.stunEffect < stunEffect)
                {
                    dmg.stunEffect = stunEffect;
                }

                rb.AddForce(direction * attackForce, ForceMode2D.Impulse);
                dmg.Damage(damage);
            }
        }
        cooldownTimer = (int)(cooldown * 50f);
        GameObject.FindObjectOfType<AudioController>().Play("swordkick");
        return true;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, hitRange);
    }
}
