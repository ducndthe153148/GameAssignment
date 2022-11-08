using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public FixedJoystick joystick;
    public float moveSpeed = 1f;
    public GameObject fireBall;
    public ContactFilter2D moveFilter;
    public SwordHitBox swordAttack;
    public float collisionOffset = 0.05f;
    public GameObject swordHitBox;
    Collider2D swordCollider;
    Vector2 moveInput;
    GameObject firePoint;
    [SerializeField]
    public bool active = true;
    [SerializeField]
    public PlayerHealth PlayerHeath;

    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer spriteRenderer;

    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();
    [SerializeField] public GameObject LightningPanel;
    public bool immune = false;
    SpriteRenderer sprite;
   
    public SoundManager soundManager;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        swordCollider = swordHitBox.GetComponent<Collider2D>();
        firePoint = GameObject.Find("Firepoint");
        sprite = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (!active)
        {
            return;
        }
        if (PlayerHeath.currentHealth == 0)
        {
            die();
            StartCoroutine(reviveMe(5));
        }

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
        if (moveInput.x < 0)  // direction left
        {
            if(swordHitBox.transform.localScale.x > 0)
            {
                swordHitBox.transform.localScale *= -1;
            }
            spriteRenderer.flipX = true;
            if (firePoint.transform.localScale.x > 0)
            {
                firePoint.transform.localScale *= -1;
                if(firePoint.transform.localPosition.x > 0)
                {
                    firePoint.transform.localPosition *= -1;
                }
            }
            //gameObject.BroadcastMessage("IsFacingRight", false);
        }
        else if (moveInput.x > 0)  // direction right
        {
            if (swordHitBox.transform.localScale.x < 0)
            {
                swordHitBox.transform.localScale *= -1;
            }
            spriteRenderer.flipX = false;
            if (firePoint.transform.localScale.x < 0)
            {
                firePoint.transform.localScale *= -1;
                if (firePoint.transform.localPosition.x < 0)
                {
                    firePoint.transform.localPosition *= -1;
                }
            }
            //gameObject.BroadcastMessage("IsFacingRight", true);
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
        immune=true;
        StopCoroutine("SetMyBoolToFalse");
        StartCoroutine("SetMyBoolToFalse");
    }
    public IEnumerator SetMyBoolToFalse()
    {

        yield return new WaitForSeconds(0.3f);
      
        immune = false;
      
        yield return null;
    }

    public void Attack()
    {
        OnFire();
        soundManager.play("slash");
    }

    public void DamageAllEnemy()
    {
        soundManager.play("lightining");
        foreach (GameObject o in GameObject.FindGameObjectsWithTag("enemy"))
        {
            o.BroadcastMessage("OnHit", 300f);
        }
        StartCoroutine(WaitBeforeClick());
    }
    IEnumerator WaitBeforeClick()
    {
        LightningPanel.SetActive(true);

        yield return new WaitForSeconds(0.2f);
        LightningPanel.SetActive(false);

    }
    public void die()
    {
        //if (i == 0)
        //{
        animator.SetTrigger("death1");
        animator.SetBool("death", true);
        //i++;
        active = false;
        soundManager.play("death");
        //}

    }

    IEnumerator reviveMe(int secs)
    {
        yield return new WaitForSeconds(secs);
        revive();
    }
    public void revive()
    {
        animator.SetBool("death", false);
        PlayerHeath.currentHealth = PlayerHeath.maxHealth;
        active = true;
        soundManager.play("spawn");
    }

    public void AttackFireBall()
    {

        animator.SetTrigger("swordAttack");
        Instantiate(fireBall, transform.position, Quaternion.identity);
        immune = true;
        StopCoroutine(SetMyBoolToFalse());
        StartCoroutine(SetMyBoolToFalse());
        soundManager.play("fire_ball");

    }
    public void ImmuneSkill()
    {
        soundManager.play("immune");
        sprite.color = new Color(1, 1, 0, 1);
        immune = true;
        StopCoroutine(SetImmuneSkill(5f));
        StartCoroutine(SetImmuneSkill(5f));
    }
    public IEnumerator SetImmuneSkill(float waitTime)
    {

        yield return new WaitForSeconds(waitTime);

        immune = false;
        sprite.color = new Color(1, 1, 1, 1);

        yield return null;
    }
}
