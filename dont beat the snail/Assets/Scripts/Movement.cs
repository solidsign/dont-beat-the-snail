using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Movement : MonoBehaviour
{
    [SerializeField] protected new Rigidbody2D rigidbody;
    public float speed;
    public float jumpForce;
    protected float horizontalSpeed;
    protected bool onFloor = false;
    public bool facingRight = true;
    protected Damagable dmg;

    protected virtual void Start()
    {
        horizontalSpeed = 0;
        dmg = GetComponent<Damagable>();
    }
    public void MoveRight()
    {
        horizontalSpeed = speed;
        if (!facingRight)
        {
            transform.Rotate(0, 180, 0);
            facingRight = true;
        }
    }

    public void MoveLeft()
    {
        horizontalSpeed = -speed;
        if (facingRight)
        {
            transform.Rotate(0, 180, 0);
            facingRight = false;
        }
    }

    protected void Jump()
    {
        if (onFloor)
        {
            rigidbody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }

    protected void SetVelocity()
    {
        rigidbody.velocity = new Vector2(horizontalSpeed, rigidbody.velocity.y);
    }


    protected virtual void OnCollisionEnter2D(Collision2D collide)
    {
        if (collide.gameObject.layer == 8)
        {
            onFloor = true;
            GameObject.FindObjectOfType<AudioController>().Play("jumpend");
        }
    }

    protected void OnCollisionExit2D(Collision2D collide)
    {
        if (collide.gameObject.layer == 8)
        {
            onFloor = false;
        }
    }
}
