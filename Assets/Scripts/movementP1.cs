using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementP1 : MonoBehaviour
{
    // Start is called before the first frame update
	public int speed = 8;
    void Start()
    {
    //    Debug.Log(GetComponent<Score>());
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < -10)
            transform.Translate(Vector3.up * 20, Space.World);
        if(Input.GetKey(KeyCode.UpArrow))
            transform.Translate(Vector3.up * Time.deltaTime * speed, Space.World);
        if(Input.GetKey(KeyCode.DownArrow))
            transform.Translate(Vector3.down * Time.deltaTime * speed, Space.World);
        if(Input.GetKey(KeyCode.LeftArrow))
            transform.Translate(Vector3.left * Time.deltaTime * speed, Space.World);
        if(Input.GetKey(KeyCode.RightArrow))
            transform.Translate(Vector3.right * Time.deltaTime * speed, Space.World); 
    }
}
