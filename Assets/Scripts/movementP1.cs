using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementP1 : MonoBehaviour
{
    // Start is called before the first frame update
	public int speed = 8;
    bool onCollision = false;
    public int jumpForce = 3;
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
    void Update()
    {
        if(rb.velocity.x > 8)
            rb.velocity.Set(8f, rb.velocity.y);
        if(transform.position.y < -10)
            transform.Translate(Vector3.up * 20, Space.World);
        if(Input.GetKey(KeyCode.UpArrow) && onCollision)
            rb.AddForce(transform.up, ForceMode2D.Impulse);
        if(Input.GetKey(KeyCode.LeftArrow))
            rb.AddForce(-transform.right * speed);
        if(Input.GetKey(KeyCode.RightArrow))
            rb.AddForce(transform.right * speed);
    }
     void OnCollisionEnter2D(Collision2D other) {
        onCollision = true;
    }
    void OnCollisionExit2D(Collision2D other) {
        onCollision = false;
    }
}
