using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExponsionOnDeath : MonoBehaviour
{
        public GameObject explosion;
        
void Start(){
     Explode();
}
    void Update(){
       

    }
    void Explode() {
        GetComponent<AudioSource>().Play();
        Instantiate (explosion, transform.position, transform.rotation); 
    }
    
}