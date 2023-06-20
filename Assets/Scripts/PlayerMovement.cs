using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer player;
    public float jumpForce;
    public float moveSpeed;

    private bool isJumping;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        player = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        if (moveHorizontal != 0f)
        {
            Move(moveHorizontal);
        }
        else
        {
            StopMoving();
        }
        if (Input.GetKey(KeyCode.Space) && !isJumping)
        {
            Jump();
            StopMoving();
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            StopJump();
             
        }
    }
    private void Move(float direction)
    {
        rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y);
        animator.SetBool("Walk",true);
        if (direction < 0)
        {
            player.flipX = true;
        }
        if(direction > 0)
        {
            player.flipX = false;
        }
    }

    private void StopMoving()
    {
        rb.velocity = new Vector2(0f, rb.velocity.y);
        animator.SetBool("Walk",false);
    }
    private void Jump()
    {
        rb.AddForce(new Vector2(rb.velocity.x, jumpForce));
        animator.SetBool("Jump",true);
        isJumping = true;
    }

    private void StopJump()
    {
        isJumping = false;
        animator.SetBool("Jump", false);
    }
}