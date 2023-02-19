using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject gameObject;
    public Transform target;
    public Vector3 offset;

    public float smoothSpeed = 0.125f;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
     transform.position = Vector3.Lerp(transform.position, desiredPosition,smoothSpeed  * Time.deltaTime);
    }
}
