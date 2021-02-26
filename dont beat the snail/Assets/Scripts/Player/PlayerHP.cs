using UnityEngine;

public class PlayerHP : Damagable
{
    public float healDelay = 3f;
    public float maxHP = 100f;
    public float HpPerSecond = 25f;
    private int healTimer = 0;
    private Animator hpBar;
    protected override void Start()
    {
        base.Start();
        hpBar = GameObject.FindObjectOfType<HPControllerUI>().GetComponentInParent<Animator>();
    }
    private void Update()
    {
        if (stunEffect > 0)
        {
            animator.SetBool("stunned", true);
        }
        else
        {
            animator.SetBool("stunned", false);
        }
    }
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        if(healTimer != 0)
        {
            healTimer--;
        }
        if (healTimer == 0 && hp <= maxHP && !dying)
        {
            hp += HpPerSecond / 50;
        }
    }
    public override void Damage(float damage)
    {
        base.Damage(damage);
        if(hp <= 0)
        {
            if(!dying) Die();
        }
        hpBar.SetTrigger("hit");
        healTimer = (int)(healDelay * 50);
    }

    override protected void Die()
    {
        dying = true;
        GameObject.FindObjectOfType<AudioController>().Play("playerdeath");
        GameObject.FindObjectOfType<LevelCompleteManager>().Retry();
        gameObject.GetComponent<PlayerMovement>().enabled = false;
        gameObject.GetComponent<AbilityController>().enabled = false;
        gameObject.GetComponentInChildren<SpriteRenderer>().enabled = false;
        transform.GetChild(5).GetComponent<ParticleSystem>().Play();
        gameObject.GetComponent<PlayerHP>().enabled = false;
        gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
        gameObject.GetComponent<Rigidbody2D>().Sleep();
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject en in enemies)
        {
            en.GetComponent<EnemyAbilityController>().rangeAttackMode = false;
            en.GetComponent<EnemyAbilityController>().attackMode = false;
            en.GetComponent<EnemyMovement>().attackMode = false;
            en.GetComponent<EnemyMovement>().escapeMode = false;
        }
    }
}
