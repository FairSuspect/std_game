using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(Random.Range(-11.42f, 12.35f), 10, -0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.name != "deathTile")
        {
            transform.Translate(Vector3.down * 5 * Time.deltaTime);
            if (transform.position.y < -15)
                Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       collision.gameObject.GetComponent<PlayerData>().setHP(0);

    }
}
