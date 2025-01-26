using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    private float horizontal;
    bool canJump;
    bool canDash;
    public bool isDashing;
    public float runSpeed = 8f;
    public float jumpSpeed = 16f;
    private bool facingRight = true;
    private float originalGravity;
    private float dashCooldown;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform  groundCheck1;
    //[SerializeField] private Transform  groundCheck2;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float dashSpeed = 20f;
    [SerializeField] private float dashTime = 1f;
    

    [SerializeField] private UI_Controller UIcontroller;
    void Start()
    {
        canJump = false;
        originalGravity = rb.gravityScale;
        isDashing = false;
        canDash = false;
        dashCooldown = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(isDashing)
        {
            return;
        }

        horizontal = Input.GetAxisRaw("Horizontal");

        if(IsGrounded())
        {
            rb.gravityScale = 0f;
            canJump = true;
            if(dashCooldown <= 0f)
            {
                dashRefreshed();
            }
        }
        else
        {
            rb.gravityScale = originalGravity;
        }


        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            canJump = false;
        }
        if (Input.GetKeyUp(KeyCode.Space) && rb.velocity.y >0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
        if(Input.GetKey(KeyCode.Mouse1) && canDash)
        {
            //Debug.Log("dash");
            StartCoroutine(Dash());
            canDash = false;
            UIcontroller.usedDash();
        }
        FlipPlayer();
    }

    void FixedUpdate()
    {
        if(isDashing)
        {
            return;
        }
        rb.velocity = new Vector2(horizontal * runSpeed, rb.velocity.y);
    }

    public void dashRefreshed()
    {
        canDash = true;
        UIcontroller.refreshDash();
    }

    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck1.position, 0.2f, groundLayer);
    }

    void FlipPlayer()
    {
        if (facingRight && horizontal < 0f || !facingRight && horizontal > 0f)
        {
            facingRight = !facingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private IEnumerator Dash()
    {
        Debug.Log("dash");
        isDashing = true;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashSpeed, 0f );
        yield return new WaitForSeconds(dashTime);
        rb.gravityScale = originalGravity;
        isDashing = false;

        dashCooldown = .15f;
        while(dashCooldown > 0f)
        {
            dashCooldown -= Time.deltaTime;
            yield return null;
        }
    }
}
