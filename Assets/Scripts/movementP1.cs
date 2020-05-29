using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementP1 : MonoBehaviour {
    // Start is called before the first frame update
    public int speed = 8;
    bool onCollision = false;
    public float jumpForce = 10.0f;//Через переменную не работает
    Rigidbody2D rb;
    void Awake () {
        rb = GetComponent<Rigidbody2D> ();
    }
    void Start () {
        //    Debug.Log(GetComponent<Score>());
    }

    // Update is called once per frame

    void FixedUpdate () {
        if (Mathf.Abs(rb.velocity.x) > 8.0f) {
            rb.velocity = new Vector3 (rb.velocity.x * 0.65f, rb.velocity.y, 0f);
        }

        //вверх
        if (Input.GetKey (KeyCode.UpArrow) && onCollision) {
            rb.velocity = new Vector3 (rb.velocity.x, 12.5f, 0f);
        }

        //вправо и влево
        if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.LeftArrow)) {
            float x = Input.GetAxis ("Horizontal");
            Vector3 move = new Vector3 (x * 12.5f, rb.velocity.y, 0f);
            rb.velocity = move;

            transform.rotation =  x > 0 ? new Quaternion (0, 0, 0, 0) : new Quaternion (0, 270f, 0, 0);
        }

    }

    void OnCollisionEnter2D (Collision2D other) {
        onCollision = true;
    }
    void OnCollisionExit2D (Collision2D other) {
        onCollision = false;
    }
}