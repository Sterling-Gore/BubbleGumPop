using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    private float horizontal;
    private bool isDashing;
    public float runSpeed = 8f;
    public float jumpSpeed = 16f;
    private bool facingRight = true;
    private float originalGravity;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform  groundCheck1;
    [SerializeField] private Transform  groundCheck2;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float dashSpeed = 20f;
    [SerializeField] private float dashTime = 1f;
    // Start is called before the first frame update
    void Start()
    {
        originalGravity = rb.gravityScale;
        isDashing = false;
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
        }
        else
        {
            rb.gravityScale = originalGravity;
        }

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }
        if (Input.GetKeyUp(KeyCode.Space) && rb.velocity.y >0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
        if(Input.GetKey(KeyCode.Mouse1))
        {
            //Debug.Log("dash");
            StartCoroutine(Dash());
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

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck1.position, 0.2f, groundLayer) || Physics2D.OverlapCircle(groundCheck2.position, 0.2f, groundLayer);
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
    }
}
