using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBlastController : MonoBehaviour
{
    [SerializeField] private float damage = 100;
    [SerializeField] private float stunEffect = 1f;
    [SerializeField] private float attackForce = 20f;
    [SerializeField] private float castDelay = 0.2f;
    [SerializeField] private float castDuration = 0.6f;
    private Animator cam;
    private void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>();
    }
    public void Activate()
    {
        Invoke("Cast", castDelay);
        Invoke("DeactivateSelf", castDuration);
    }
    private void Cast()
    {
        float direction = GetComponentInParent<Movement>().facingRight ? 1 : -1;
        Vector2 origin = new Vector2(transform.position.x - 10 * direction, transform.position.y);
        RaycastHit2D[] hits = Physics2D.RaycastAll(origin, Vector2.right * direction, 18.5f);
        foreach (RaycastHit2D hit in hits)
        {
            if ((hit.collider.transform.CompareTag("Enemy") || hit.collider.transform.CompareTag("Player")) && hit.collider.transform.name != name)
            {
                Damagable dmg = hit.transform.GetComponent<Damagable>();
                Rigidbody2D rb = hit.transform.GetComponent<Rigidbody2D>();
                dmg.Damage(damage);
                rb.velocity = Vector2.zero;
                rb.AddForce(new Vector2(attackForce * direction, attackForce * 1.5f), ForceMode2D.Impulse);
                if(dmg.stunEffect < stunEffect) dmg.stunEffect = stunEffect;
            }
        }
        cam.SetTrigger("hit");
        GameObject.FindObjectOfType<AudioController>().Play("magicblast");
    }
    private void DeactivateSelf()
    {
        gameObject.SetActive(false);
    }
}
