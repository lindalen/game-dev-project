using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float input = Input.GetAxisRaw("Horizontal");
        float moveAmplifier = 10f;
        float moveForce = input * moveAmplifier;

        Vector2 moveVector = new Vector2(moveForce, rb.velocity.y);
        rb.velocity = moveVector;
    }

    private void Jump()
    {
        float jumpForce = 7f;

        Vector2 jumpVector = new Vector2(rb.velocity.x, jumpForce);
        rb.velocity = jumpVector;
    }
}
