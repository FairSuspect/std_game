using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementP2 : MonoBehaviour
{
	public int speed = 8;
    // Start is called before the first frame update

        Rigidbody2D rb;

    void Start()
    {
        
    }
    private bool onCollision = false;

        public KeyCode UpKey = KeyCode.W; 
        public KeyCode LeftKey = KeyCode.A; 
        public KeyCode RightKey = KeyCode.D; 
    // Update is called once per frame
      void FixedUpdate () {
        if (Mathf.Abs(rb.velocity.x) > 8.0f) {
            rb.velocity = new Vector3 (rb.velocity.x * 0.65f, rb.velocity.y, 0f);
        }

        //вверх
        if (Input.GetKey (UpKey) && onCollision) {
            rb.velocity = new Vector3 (rb.velocity.x, 12.5f, 0f);
        }

        //вправо и влево
        if (Input.GetKey (RightKey) || Input.GetKey (LeftKey)) {
            float x = Input.GetAxis ("Horizontal");
            Vector3 move = new Vector3 (x * 12.5f, rb.velocity.y, 0f);
            rb.velocity = move;

            transform.rotation =  x > 0 ? new Quaternion (0, 0, 0, 0) : new Quaternion (0, 270f, 0, 0);
        }

    }
}
