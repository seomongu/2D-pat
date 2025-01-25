using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2DInput : MonoBehaviour
{
    Rigidbody2D rigid;
    SpriteRenderer spriteRenderer;
    Animator anim;

    public float movementSpeed = 5f;
    public float jumpPower = 5f;

    Vector2 InputVector;

    public bool isGrounded;
    public float groundCheckDistance;
    public LayerMask groundLayer;
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();

        GroundCheck();
    }

    private void GroundCheck()
    {
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundLayer);
    }

    private void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rigid.velocity = new Vector2(rigid.velocity.x, jumpPower);
        }
    }

    private void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");

        InputVector = new Vector2(horizontal * movementSpeed, rigid.velocity.y);

        rigid.velocity = InputVector;

        if (InputVector.x != 0)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }

        if (InputVector.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (InputVector.x > 0)
        {
            spriteRenderer.flipX = false;
        }
    }
}
