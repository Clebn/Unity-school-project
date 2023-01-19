using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerss : MonoBehaviour
{
    public float speed = 5;
    public float jumpForce = 10f;
    public Rigidbody2D rb;
    public bool isGrounded = false;

    // Update is called once per frame
    void Update()
    {
      float horizontalInput = Input.GetAxis("Horizontal");
       
        Vector2 velocity = new Vector2(horizontalInput * speed, rb.velocity.y);
        rb.velocity = velocity;

        if(isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground") { isGrounded = true; }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground") { isGrounded = false; }
    }
}
