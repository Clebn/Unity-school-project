using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerss : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float horizontalInput;
    [SerializeField] private bool isGrounded = false;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator anim;
    [SerializeField] private SpriteRenderer sprite;

    // Update is called once per frame
    void Update()
    {
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
      horizontalInput = Input.GetAxis("Horizontal");
       
        Vector2 velocity = new Vector2(horizontalInput * speed, rb.velocity.y);
        rb.velocity = velocity;

        if(isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        UpdateAnimationState();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground") { isGrounded = true; }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground") { isGrounded = false; }
    }

    private void UpdateAnimationState()
    {
        if (horizontalInput > 0f)
        {
            anim.SetBool("Running", true);
            sprite.flipX = false;
        }
        else if (horizontalInput < 0f)
        {
            anim.SetBool("Running", true);
            sprite.flipX = true;
        }
        else
        {
            anim.SetBool("Running", false);
        }
    }
}