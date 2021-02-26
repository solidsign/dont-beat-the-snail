using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    private Rigidbody2D r;
    [SerializeField] private float damage = 20;
    [SerializeField] private float attackForce = 5f;
    [SerializeField] private float stunEffect = 0.5f;

    void Start()
    {
        r = GetComponent<Rigidbody2D>();
        GameObject.FindObjectOfType<AudioController>().Play("arrowshoot");
    }

    private void Update()
    {
        float angle = Mathf.Atan2(r.velocity.y, r.velocity.x) * Mathf.Rad2Deg - 90;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if((collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Player")) && collision.gameObject.name != name)
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            Damagable dmg = collision.gameObject.GetComponent<Damagable>();
            Vector2 direction;
            if (transform.position.x < collision.transform.position.x)
            {
                direction = new Vector2(1,1);
            }
            else
            {
                direction = new Vector2(-1,1);
            }

            rb.velocity = Vector2.zero;

            if(dmg.stunEffect < stunEffect)
            {
                dmg.stunEffect = stunEffect;
            }

            rb.AddForce(direction * attackForce, ForceMode2D.Impulse);
            dmg.Damage(damage);
        }
        if(collision.gameObject.name != name)
        {
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<Rigidbody2D>().Sleep();
            transform.GetChild(0).GetComponent<ParticleSystem>().Play();
            GameObject.FindObjectOfType<AudioController>().Play("arrowhit");
            Invoke("DestroySelf", 0.15f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Shield") && collision.gameObject.name != name)
        {
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<Rigidbody2D>().Sleep();
            transform.GetChild(0).GetComponent<ParticleSystem>().Play();
            Invoke("DestroySelf", 0.15f);
            GameObject.FindObjectOfType<AudioController>().Play("shieldhit");
        }
        if (collision.gameObject.CompareTag("ShieldTrigger") || collision.gameObject.name != name)
        {
            collision.gameObject.GetComponentInParent<EnemyAbilityController>().attackMode = true;
        }
    }
    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}
