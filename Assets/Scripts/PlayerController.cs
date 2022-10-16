using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public FixedJoystick joystick;
    public float moveSpeed = 1f;

    public ContactFilter2D moveFilter;

    public float collisionOffset = 0.05f;

    Vector2 moveInput;

    Rigidbody2D rb;

    Animator animator;
    SpriteRenderer spriteRenderer;

    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {

        moveInput.x = joystick.Horizontal;
        moveInput.y = joystick.Vertical;
        if (moveInput != Vector2.zero)
        {
            bool success = TryMove(moveInput);
            if (!success && moveInput.x > 0)
            {
                success = TryMove(new Vector2(moveInput.x, 0));

            }
            if (!success && moveInput.y > 0)
            {
                success = TryMove(new Vector2(0, moveInput.y));
            }

            animator.SetBool("isMoving", success);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }

        //set direction of sprites
        if (moveInput.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (moveInput.x > 0)
        {
            spriteRenderer.flipX = false;
        }
    }
    private bool TryMove(Vector2 direction)
    {
        if(direction != Vector2.zero)
        {
            int count = rb.Cast(
            direction,
            moveFilter,
            castCollisions,
            moveSpeed * Time.fixedDeltaTime + collisionOffset
            );
            if (count == 0)
            {
                rb.MovePosition(rb.position + direction * moveSpeed * Time.fixedDeltaTime);
                return true;
            }
            else
            {
                return false;

            }
        }
        else
        {
            return false;
        }
        



    }

    void OnMove(InputValue moveValue)
    {
        moveInput = moveValue.Get<Vector2>();
    }

    void OnFire()
    {
        animator.SetTrigger("swordAttack");
    }

    public void Attack()
    {
        OnFire();
    }
    
}
