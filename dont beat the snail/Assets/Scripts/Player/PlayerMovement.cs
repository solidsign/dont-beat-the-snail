using UnityEngine;

public class PlayerMovement : Movement
{
    private Animator animator;
    private AbilityController ability;

    protected override void Start()
    {
        base.Start();
        animator = GetComponentInChildren<Animator>();
        ability = GetComponent<AbilityController>();
    }
    private void Update()
    {
        horizontalSpeed = 0;
        if (!ability.attacking)
        {
            if (Input.GetKey(Inputs.right))
            {
                MoveRight();
            }
            if (Input.GetKey(Inputs.left))
            {
                MoveLeft();
            }
            if (Input.GetKeyDown(Inputs.jump) && dmg.stunEffect <= 0)
            {
                animator.SetBool("jumping", true);
                GameObject.FindObjectOfType<AudioController>().Play("jump");
                Jump();
            }
            if (Input.GetKey(Inputs.right) || Input.GetKey(Inputs.left))
            {
                animator.SetBool("running", true);
            }
            else
            {
                animator.SetBool("running", false);
            }
            if (onFloor)
            {
                animator.SetBool("jumping", false);
            }
            else
            {
                animator.SetBool("jumping", true);
            }
        }
        else
        {
            animator.SetBool("running", false);
            animator.SetBool("jumping", false);
        }

        
        if (dmg.stunEffect <= 0) SetVelocity();
    }

    protected override void OnCollisionEnter2D(Collision2D collide)
    {
        base.OnCollisionEnter2D(collide);
        if (onFloor)
        {
            animator.SetBool("jumping", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("MoveTrigger"))
        {
            collision.GetComponentInParent<EnemyMovement>().attackMode = true;
            collision.GetComponentInParent<EnemyMovement>().escapeMode = false;
            collision.GetComponentInParent<EnemyAbilityController>().rangeAttackMode = false;
            collision.GetComponentInParent<EnemyAbilityController>().attackMode = false;
        }
        if (collision.CompareTag("EscapeTrigger"))
        {
            collision.GetComponentInParent<EnemyMovement>().attackMode = false;
            collision.GetComponentInParent<EnemyMovement>().escapeMode = true;
            collision.GetComponentInParent<EnemyAbilityController>().rangeAttackMode = false;
            collision.GetComponentInParent<EnemyAbilityController>().attackMode = false;
        }
        if (collision.CompareTag("AttackTrigger"))
        {
            collision.GetComponentInParent<EnemyAbilityController>().attackMode = true;
            collision.GetComponentInParent<EnemyAbilityController>().rangeAttackMode = false;
        }
        if (collision.CompareTag("RangeAttackTrigger"))
        {
            collision.GetComponentInParent<EnemyAbilityController>().rangeAttackMode = true;
        }
        if (collision.CompareTag("LevelComplete"))
        {
            collision.transform.GetComponent<LevelCompleteManager>().ShowWinScreen();
            gameObject.SetActive(false);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("MoveTrigger"))
        {
            collision.GetComponentInParent<EnemyMovement>().attackMode = false;
            collision.GetComponentInParent<EnemyMovement>().escapeMode = true;
            collision.GetComponentInParent<EnemyAbilityController>().rangeAttackMode = false;
            collision.GetComponentInParent<EnemyAbilityController>().attackMode = false;
        }
        if (collision.CompareTag("AttackTrigger"))
        {
            collision.GetComponentInParent<EnemyMovement>().attackMode = true;
            collision.GetComponentInParent<EnemyMovement>().escapeMode = false;
            collision.GetComponentInParent<EnemyAbilityController>().attackMode = false;
            collision.GetComponentInParent<EnemyAbilityController>().rangeAttackMode = false;
        }
        if (collision.CompareTag("RangeAttackTrigger"))
        {
            collision.GetComponentInParent<EnemyAbilityController>().rangeAttackMode = false;
            collision.GetComponentInParent<EnemyAbilityController>().attackMode = false;
        }
        if (collision.CompareTag("EscapeTrigger"))
        {
            collision.GetComponentInParent<EnemyMovement>().escapeMode = false;
            collision.GetComponentInParent<EnemyAbilityController>().rangeAttackMode = true;
            collision.GetComponentInParent<EnemyAbilityController>().attackMode = false;
        }
    }
}
