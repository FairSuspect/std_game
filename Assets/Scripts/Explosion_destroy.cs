using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion_destroy : MonoBehaviour
{
    void FixedUpdate() {
        Destroy(gameObject, 1.0f);
    }
}
