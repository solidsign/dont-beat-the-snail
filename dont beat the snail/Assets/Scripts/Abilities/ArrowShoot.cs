using UnityEngine;

public class ArrowShoot : Ability
{
    public GameObject arrow;
    public float launchForce = 3;
    [SerializeField] private float cooldown = 0.25f;
    private void Start()
    {
        Cooldown = cooldown;
        abilityID = 2;
        animationDelay = 0.2f;
        animationName = "arrowshoot";
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
        GameObject shot = Instantiate(arrow, transform.GetChild(1).GetComponent<Transform>().position, transform.GetChild(1).GetComponent<Transform>().rotation);
        shot.name = gameObject.name;
        shot.GetComponent<Rigidbody2D>().AddForce(shot.transform.up * launchForce, ForceMode2D.Impulse);
        cooldownTimer = (int)(cooldown * 50f);
        return true;
    }
}
