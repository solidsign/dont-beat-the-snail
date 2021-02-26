using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundHit : Ability
{
    public Transform attackPoint;
    public float hitRange = 5;
    public float attackForce = 30;
    [SerializeField] protected float stunEffect = 3f;
    [SerializeField] private float damage = 50;
    [SerializeField] private float cooldown = 5f;
    [SerializeField] private float minForce = 1;
    [SerializeField] private float maxForce = 1.2f;
    private void Start()
    {
        Cooldown = cooldown;
        abilityID = 4;
        animationDelay = 0.2f;
        animationName = "groundhit";
        attackPoint = transform.GetChild(1).GetComponent<Transform>();
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
                float deltaX = collider.transform.position.x - transform.position.x;
                float deltaY = collider.transform.position.y - transform.position.y;
                float distance = Mathf.Sqrt(deltaX * deltaX + deltaY * deltaY + 0.0001f);
                float coef = hitRange / distance;
                if (coef < minForce) coef = minForce;
                if (coef > maxForce) coef = maxForce;
                Vector2 forceDirection = new Vector2(deltaX / distance, deltaY / distance);
                Rigidbody2D rb = collider.gameObject.GetComponent<Rigidbody2D>();
                Damagable dmg = collider.gameObject.GetComponent<Damagable>();
                rb.velocity = Vector2.zero;

                if (dmg.stunEffect < stunEffect)
                {
                    dmg.stunEffect = stunEffect;
                }

                rb.AddForce(forceDirection * attackForce * coef, ForceMode2D.Impulse);
                dmg.Damage(damage * coef);
            }
        }
        cooldownTimer = (int)(cooldown * 50f);
        GameObject.FindObjectOfType<AudioController>().Play("explosion");
        return true;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, hitRange);
    }
}
