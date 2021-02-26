using UnityEngine;

public abstract class Damagable : MonoBehaviour
{
    [SerializeField] public float hp;
    public float stunEffect = 0f;
    protected Animator animator;
    protected bool dying = false;
    private Animator cam;


    protected virtual void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
        animator = GetComponentInChildren<Animator>();
    }

    protected virtual void FixedUpdate()
    {
        if(stunEffect > 0)
        {
            stunEffect = (stunEffect * 50 - 1) / 50;
        }
    }

    public virtual void Damage(float damage)
    {
        transform.GetChild(2).GetComponent<ParticleSystem>().Play();
        hp -= damage;
        if (hp <= 0)
        {
            if (!dying) Die();
        }
        GameObject.FindObjectOfType<AudioController>().Play("hit");
        cam.SetTrigger("hit");
        Debug.Log(gameObject.name + " damaged: " + damage + " | Current HP: " + hp);
    }

    protected virtual void Die()
    {
        Debug.Log(gameObject.name + " died");
    }
}
