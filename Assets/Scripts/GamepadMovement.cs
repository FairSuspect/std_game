using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamepadMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");
    Flip();
    }

    public float Speed = 8f;
    float horizontalMove = 0f;
    private bool isFacingRight = true;
    public Rigidbody2D rb;

    void FixedUpdate()
    {

      rb.velocity = new Vector2(horizontalMove * Speed, rb.velocity.y);


    }

    private void Flip()
    {
        if (isFacingRight && horizontalMove < 0f || !isFacingRight && horizontalMove > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
}


