using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementP1 : MonoBehaviour
{
    // Start is called before the first frame update
	public int speed = 8;
    bool onCollision = false;
    public int jumpForce = 25;
    Rigidbody2D rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
    //    Debug.Log(GetComponent<Score>());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(rb.velocity.x > 8f)
            rb.velocity.Set(8f, rb.velocity.y);
        if(transform.position.y < -10)
            transform.Translate(Vector3.up * 20, Space.World);
        if(Input.GetKey(KeyCode.UpArrow) && onCollision)
            rb.velocity = new Vector2 (rb.velocity.x, jumpForce);
            
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2 (-speed, rb.velocity.y);
            transform.rotation = new Quaternion(0,180f,0,0);
        }
            
        if(Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2 (speed, rb.velocity.y);
            transform.rotation = new Quaternion(0,0,0,0);
        }
            
    }
     void OnCollisionEnter2D(Collision2D other) {
        onCollision = true;
    }
    void OnCollisionExit2D(Collision2D other) {
        onCollision = false;
    }
}
