using UnityEngine;

public class SwordHit : Ability
{
    public Transform attackPoint;
    public float hitRange = 0.9f;
    [SerializeField] protected float stunEffect = 0.7f;
    [SerializeField] private float damage = 40;
    [SerializeField] private float cooldown = 0.1f;
    private void Start()
    {
        Cooldown = cooldown;
        abilityID = 1;
        animationDelay = 0;
        animationName = "swordhit";
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
            if(collider.name != gameObject.name && (collider.CompareTag("Player") || collider.CompareTag("Enemy")))
            {
                if (collider.gameObject.GetComponent<Damagable>().stunEffect < stunEffect)
                {
                    collider.gameObject.GetComponent<Damagable>().stunEffect = stunEffect;
                }

                collider.GetComponent<Damagable>().Damage(damage);
            }
        }
        cooldownTimer = (int)(cooldown * 50f);
        GameObject.FindObjectOfType<AudioController>().Play("swordhit");
        return true;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, hitRange);
    }
}
