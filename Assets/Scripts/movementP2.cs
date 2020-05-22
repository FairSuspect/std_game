using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementP2 : MonoBehaviour
{
	public int speed = 8;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -10)
            transform.Translate(Vector3.up * 20, Space.World);
        if(Input.GetKey(KeyCode.W))
            transform.Translate(Vector3.up * Time.deltaTime * speed, Space.World);
        if(Input.GetKey(KeyCode.S))
            transform.Translate(Vector3.down * Time.deltaTime * speed, Space.World);
        if(Input.GetKey(KeyCode.A))
            transform.Translate(Vector3.left * Time.deltaTime * speed, Space.World);
        if(Input.GetKey(KeyCode.D))
            transform.Translate(Vector3.right * Time.deltaTime * speed, Space.World);
    }
}
