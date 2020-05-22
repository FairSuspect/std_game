using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTile : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player1;
    public GameObject player2;

    void Start()
    {
        transform.position = new Vector3(Random.Range(22, 51), 10, -0.5f);
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
        if (collision == player1.GetComponent<BoxCollider2D>())
            player1.GetComponent<PlayerData>().setHP(0);
        else if (collision == player2.GetComponent<BoxCollider2D>())
            player2.GetComponent<PlayerData>().setHP(0);

    }
}
