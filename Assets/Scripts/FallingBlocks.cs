using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallingBlocks : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player1;
    public GameObject player2;
    public GameObject gmMode;
    bool invoked = false;
    string textToDisplay = "";
     public enum GameStatus
    {
        PREPARING,
        PAUSE,
        PLAYING,
        ROUNDEND
    }
    GameStatus g_status;
    void Awake()
    {
        gmMode = GameObject.FindGameObjectWithTag("GameController");
        
        Debug.Log("I'v got gmMode: " + gmMode);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch(g_status)
        {
            case GameStatus.PREPARING:
                {
                    player1.GetComponent<PlayerData>().setHP(100);
                    player2.GetComponent<PlayerData>().setHP(100);
                    Invoke("pauseGame", 3f);
                }
                break;
            case GameStatus.PLAYING:
                {
                    if(!invoked)
                        {
                            InvokeRepeating("CreateFallingBlock", 1.5f, 0.5f);
                            invoked = true;
                        }
                       
                }
                    if (player1.GetComponent<PlayerData>().getHP() <= 0 || player2.GetComponent<PlayerData>().getHP() <= 0)
                        g_status = GameStatus.ROUNDEND;
                break;
            case GameStatus.ROUNDEND:
                {
                    CancelInvoke();
                    invoked = false;
                    if (player1.GetComponent<PlayerData>().getHP() <= 0)
                    {
                        //infoDisplay.text = "Player 2 wins";
                        player2.GetComponent<PlayerData>().IncreaceScore();
                    }
                        
                    else if (player2.GetComponent<PlayerData>().getHP() <= 0)
                    {
                        //infoDisplay.text = "Player 1 wins";
                        player1.GetComponent<PlayerData>().IncreaceScore();
                    }
                        
                    Invoke("nextRound",1f);



                }
                break;
            case GameStatus.PAUSE:
                {
                    textToDisplay = "Go!";
                    Invoke("setText", 2.5f);
                    Invoke("startGame", 3f);
                }
                break;
        }
    }
    void nextRound(){
        switch(Random.Range(0,3))
        {
            case 0:
                SceneManager.LoadScene("CoinGrab");
                break;
            case 1:
                SceneManager.LoadScene("FallingBlocks");
                break;
            case 2:
                SceneManager.LoadScene("CatchUp");
                break;
            default:
                SceneManager.LoadScene("Menu");
                break;
        };
    }
}
