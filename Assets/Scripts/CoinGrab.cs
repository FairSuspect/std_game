using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGrab : MonoBehaviour
{
	
    Vector3[] coinPosition = {
        new Vector3(-1.92f, -0.21f, 0 ),
        new Vector3(-3.52f, -6.26f, 0 ),
        new Vector3(-8.11f,  0.51f, 0 ),
        new Vector3(-8.85f,  4.7f , 0 ),
        new Vector3( 3.9f , -4.24f, 0 ),
        new Vector3(10.64f,  5.8f , 0 ),
        new Vector3(-0.25f, -4.24f, 0 ),
        new Vector3( 7.3f ,  1.83f, 0 ),
        new Vector3(     0,  3.75f, 0 ),
        new Vector3( 4.94f,  1.83f, 0 ),
        new Vector3( 6.95f,  5.71f, 0 ),
        new Vector3(-11.7f,  5.85f, 0 ),
        new Vector3( 6.95f, -6.26f, 0 ),
        new Vector3(-11.7f, -6.2f , 0 ),
        new Vector3(10.98f, -6.2f , 0 ),
        new Vector3(10.98f, -2.1f , 0 ),
        new Vector3( 7.17f, -2.1f , 0 ),
        new Vector3(-8.11f, -2.1f , 0 ),

    };
	int rand;
	public GameObject simpleCoin;
    public GameObject player1;
    public GameObject player2;
    public enum State
    {
        REGULAR,
        BONUS,
        SIMPLE,
        HEAL,
        POISON // doesn't dowrk
    }
    public State def;
    State c_state;
    PlayerData player1Data;
    PlayerData player2Data;
    // Start is called before the first frame update
    void Start()
    {
        player1Data = player1.GetComponent<PlayerData>();
        player2Data = player2.GetComponent<PlayerData>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D trg) {
        GetComponent<AudioSource>().Play();
        GameObject Toucher;
        GameObject Another;
        if (trg == player1.GetComponent<CapsuleCollider2D>())
        {
            Toucher = player1;
            Another = player2;
        }
        else
        {
            Toucher = player2;
            Another = player1;
        }
        Another.GetComponent<PlayerData>().getDamage(5);
            
        switch (c_state)
        {
            case State.REGULAR:
                {
                    rand = Random.Range(0, 5);
                    switch (rand) {
                        case 0:
                            c_state = State.BONUS;
                            GetComponent<SpriteRenderer>().color = Color.red;
                            break;
                        case 1:
                            c_state = State.HEAL;
                            GetComponent<SpriteRenderer>().color = Color.green;
                            break;
                        case 2:
                            c_state = State.POISON;
                            GetComponent<SpriteRenderer>().color = new Color(0.38f, 0.87f, 0.164f, 1);
                            break;
                    }
                     


                    transform.position = coinPosition[Random.Range(0,18)];
                }
                break;
            case State.BONUS:
                {
                    c_state = State.REGULAR;
                    GetComponent<SpriteRenderer>().color = Color.yellow;
                    createCoins(10);
                    transform.position = new Vector2(Random.Range(-10f, 10f), Random.Range(-5f, 5f));
                }
                break;
            case State.SIMPLE:
                {
                    bool check = player1.GetComponent<BoxCollider2D>() == trg;
                    Destroy(GetComponent<CircleCollider2D>());
                    Destroy(GetComponent<SpriteRenderer>());
                    Destroy(gameObject, 1f);
                }
                break;
            case State.HEAL:
                {
                    c_state = State.REGULAR;
                    GetComponent<SpriteRenderer>().color = Color.yellow;
                    Toucher.GetComponent<PlayerData>().getDamage(-15);
                    transform.position = new Vector3(Random.Range(-10f, 10f), Random.Range(-5f, 5f), -0.2f);
                }
                break;
            case State.POISON:
                {
                    c_state = State.REGULAR;
                    GetComponent<SpriteRenderer>().color = Color.yellow;
                    transform.position = new Vector2(Random.Range(-10f, 10f), Random.Range(-5f, 5f));
                    break;
                }
        }
        


        //trg.GetComponent<PlayerData>().Coins++;
        //Debug.Log(GameObject.Find(trg.name).GetComponent<PlayerData>());//trg.GetComponent<PlayerData>().Coins);

        // objects[4].GetComponent<SpriteRenderer>().color = Color.red;
    
     }
    void createCoins(int count = 10)
    {
        GameObject simC;
        for (int i = 0; i < count; i++)
        {
            simC = Instantiate(simpleCoin, new Vector3(Random.Range(-10f, 10f), Random.Range(-5f, 5f), -0.2f), transform.rotation);
            simC.GetComponent<CoinGrab>().c_state = State.SIMPLE;
            simC.GetComponent<CoinGrab>().player1 = player1;
            simC.GetComponent<CoinGrab>().player2 = player2;
        }
            
    }
    void GetPoisoned(GameObject player)
    {
        player.GetComponent<PlayerData>().getDamage(1);
    }
}
