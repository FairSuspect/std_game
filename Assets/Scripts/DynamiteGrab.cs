using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamiteGrab : MonoBehaviour
{
    int firstPlayer;
    public GameObject dynamite;
    public GameObject player1;
    public GameObject player2;
    public enum State
    {
        CARRING,
        DELIVERING
    }
    public State def;
    State dynamiteState = State.DELIVERING;
    public GameObject whoCarring;
    PlayerData player1Data;
    PlayerData player2Data;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        player1Data = player1.GetComponent<PlayerData>();
        player2Data = player2.GetComponent<PlayerData>();
        firstPlayer = Random.Range(0,2);
    }

    // Update is called once per frame
    void Update()
    {
        switch (dynamiteState)
        {
            case State.CARRING: {
                transform.position = whoCarring.GetComponent<Transform>().transform.position;

                timer -= Time.deltaTime;
                if ( timer < 5 )
                {
                    switch (whoCarring.name)
                    {
                        case "player1":
                            player1Data.setHP(0);
                            print("player1 здох");
                            break;
                        case "player2":
                            player2Data.setHP(0);
                            print("player2 здох");
                            break;
                    }
                }
            }
            break;

            case State.DELIVERING: {
                switch (firstPlayer)
                {
                    case 0: 
                        transform.position = Vector2.Lerp(transform.position, player1.GetComponent<Transform>().transform.position, 0.3f);
                        // transform.position.z = -1;
                        break;
                    case 1: 
                        transform.position = Vector2.Lerp(transform.position, player2.GetComponent<Transform>().transform.position, 0.3f);
                        // transform.position.z = -1;
                        break;
                }
                dynamiteState = State.DELIVERING;
            }
            break;
        }
    }

    void OnTriggerEnter2D(Collider2D player) {
        print(player.gameObject.name);
        dynamiteState = State.CARRING;
        transform.position = player.GetComponent<Transform>().transform.position;
        whoCarring = player.gameObject;
        timer = 10f;
    }

    // void giveDynamite (GameObject player) {
    //     transform.Translate((transform.position - player.GetComponent<Transform>().transform.position) * Time.deltaTime );

    // }

}
