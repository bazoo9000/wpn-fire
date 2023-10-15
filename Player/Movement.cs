using System.Collections;
using System.Collections.Generic;
//using UnityEngine.Events;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float horizontal;
    private float speed = 8f;
    private float jumpingPower = 10f;
    private bool isFacingRight = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private Animator animator;

    void Update()
    {
        bool isStand = !(animator.GetCurrentAnimatorStateInfo(0).IsName("Kick") || animator.GetCurrentAnimatorStateInfo(0).IsName("Crouch"));

        if (!PauseMenuScripts._isPaused)
        {
            if (isStand)
            {
                horizontal = Input.GetAxisRaw("Horizontal");
                animator.SetFloat("Speed", Mathf.Abs(horizontal));
            }

            if (Input.GetKeyDown(KeyCode.W) && IsGrounded() && !PauseMenuScripts._isPaused)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
                animator.SetBool("IsJumping", true);
            }

            if (Input.GetKey(KeyCode.S) && IsGrounded() && !PauseMenuScripts._isPaused)
            {
                animator.SetBool("IsCrouching", true);
            }
            else
            {
                animator.SetBool("IsCrouching", false);
            }

            if (Input.GetKeyUp(KeyCode.W) && rb.velocity.y > 0f && !PauseMenuScripts._isPaused)
            {
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            }
        }

        if (Mathf.Abs(rb.velocity.y) == 0f) // if landed after jump
        {
            animator.SetBool("IsJumping", false);
        }

        Flip();
    }

    private void FixedUpdate()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Crouch"))
        {
            Frecare();
        }
        else
        {
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        }
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            transform.Rotate(0f, 180f, 0f);
        }
    }
    private void Frecare()
    {
        float fricton = rb.velocity.x - 2 * Time.deltaTime * 1;

        if (rb.velocity.x > 0f)
        {
            fricton = rb.velocity.x - 2 * Time.deltaTime * 1;
        }
        else
        {
            fricton = rb.velocity.x - 2 * Time.deltaTime * (-1);
        }

        if (Mathf.Abs(fricton) > 0f)
        {
            rb.velocity = new Vector2(fricton, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y);
        }
    }
}
