using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DynamiteGrab : MonoBehaviour
{
    int firstPlayer;
    public GameObject dynamite;
    public GameObject player1;
    public GameObject player2;
    public GameObject explosion;
    public GameObject timerDisplay;
    public enum State
    {
        CARRING,
        DELIVERING,
        DETECTION
    }
    public State def;
    State dynamiteState = State.DETECTION;
    public GameObject carrier;
    PlayerData player1Data;
    PlayerData player2Data;
    public float timer;
    private TextMeshProUGUI timerDisplayText;
    public int playersNum;

    // Start is called before the first frame update
    void Start()
    {
        timerDisplayText = timerDisplay.GetComponent<TextMeshProUGUI>();
        player1Data = player1.GetComponent<PlayerData>();
        player2Data = player2.GetComponent<PlayerData>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (dynamiteState)
        {
            case State.CARRING: {
                transform.position = new Vector3 (carrier.GetComponent<Transform>().transform.position.x, carrier.GetComponent<Transform>().transform.position.y,-1);
                timer -= Time.deltaTime;
                timerDisplayText.text = "Времени осталось: " + Mathf.Floor(timer).ToString();
                if ( timer <= 1f )
                {
                    GetComponent<AudioSource>().Play(); //звук взрыва
                    Instantiate(explosion, transform.position, transform.rotation);
                    switch (carrier.name)
                    {
                        case "player1":
                            player1Data.setHP(0); //DEGUB
                            print("player1 здох");
                            break;
                        case "player2":
                            player2Data.setHP(0);
                            print("player2 здох"); //DEBUG
                            break;
                    }
                    Destroy(carrier.gameObject);
                    dynamiteState = State.DETECTION;
                }
            }
            break;

            case State.DELIVERING: {
                timer = 15f;
                switch (firstPlayer)
                {
                    case 0: 
                        transform.position = Vector2.Lerp(transform.position, player1.GetComponent<Transform>().transform.position, 0.3f);
                        break;
                    case 1: 
                        transform.position = Vector2.Lerp(transform.position, player2.GetComponent<Transform>().transform.position, 0.3f);
                        break;
                }
            }
            break;

            case State.DETECTION: {
                transform.position = new Vector3 (-2, 3, -1);
                playersNum = GameObject.FindGameObjectsWithTag("Player").Length;
                if (playersNum <= 1)
                {
                    transform.position = new Vector3 (100, 100,-1); //типа спрятал
                    Invoke("GameOver", 2.0f);
                    // SceneManager.LoadScene("Menu");
                    print("гейм овер"); //DEBUG
                }
                else
                {
                    firstPlayer = Random.Range(0, playersNum);
                    dynamiteState = State.DELIVERING;
                }
            }
            break;
        }
    }

    void OnTriggerEnter2D(Collider2D player) {
        print(player.gameObject.name); //DEBUG
        dynamiteState = State.CARRING;
        transform.position = player.GetComponent<Transform>().transform.position;
        carrier = player.gameObject;
        
    }

    void GameOver() {
        SceneManager.LoadScene("Menu");
    }

}
