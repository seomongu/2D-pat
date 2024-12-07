using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2DInput : MonoBehaviour
{
    Rigidbody2D rigidbody;
    SpriteRenderer spriteRenderer;
    Animator anim;

    public float movementSpeed = 5f;

    Vector2 InputVector;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");

        InputVector = new Vector2(horizontal, 0);

        rigidbody.velocity = InputVector * movementSpeed;

        if(InputVector.x != 0)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }

        if(InputVector.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if(InputVector.x > 0)
        {
            spriteRenderer.flipX = false;
        }


        //// Direction
        //if (Input.GetButtonDown("Horizontal"))
        //{
        //    spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;

        //    // AnimationWalking
        //    if (Mathf.Abs(horizontal) < 0.3)
        //        anim.SetBool("isWalking", false);
        //    else
        //        anim.SetBool("isWalking", true);
        //}
    }
}
