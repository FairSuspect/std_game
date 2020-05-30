﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameMode : MonoBehaviour
{
    private GameObject[] players; 
    public GameObject player1;
    public GameObject player2;
    public GameObject infoText;

    private TextMeshProUGUI infoDisplay;
<<<<<<< HEAD
    public int [] playersScore = {0,0};
    string textToDisplay;
=======
    string textToDisplay;

>>>>>>> 1b15dbdaa15812641245313e1611b7d5e4e6d1a4

    bool invoked = false;

    public enum GameStatus
    {
        PREPARING,
        PAUSE,
        PLAYING,
        ROUNDEND
    }
    public enum Mode
    {
        COINGRAB,
        FALLINGBLOCKS,
        CATCHUP,
        MENU
    }
    public GameStatus g_status;
    public Mode g_mode;
    void Awake() 
    {
        DontDestroyOnLoad(this);
<<<<<<< HEAD
=======
        players = GameObject.FindGameObjectsWithTag("Player");
        player1 = players[0];
        player2 = players[1];
        Camera = GameObject.FindGameObjectWithTag("MainCamera");
>>>>>>> 1b15dbdaa15812641245313e1611b7d5e4e6d1a4
    }
    // Start is called before the first frame update
    void Start()
    {
        infoDisplay = infoText.GetComponent<TextMeshProUGUI>();
       // GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        /*switch(g_status)
        {
            case GameStatus.PREPARING:
                {
                    player1.GetComponent<PlayerData>().setHP(100);
                    player2.GetComponent<PlayerData>().setHP(100);
                    switch(g_mode)
                    {
                        case Mode.COINGRAB:
                            player1.transform.position = position_p1_grab;
                            player2.transform.position = position_p2_grab;
                            Camera.transform.position = position_camera_grab;
                            textToDisplay = "Next mode is Coin Grab!";
                            break;
                        case Mode.FALLINGBLOCKS:
                            player1.transform.position = position_p1_fallingBlocks;
                            player2.transform.position = position_p2_fallingBlocks;
                            Camera.transform.position = position_camera_fallingBlocks;
                            textToDisplay = "Next mode is Falling blocks!";
                            break;

                    }
                    Invoke("pauseGame", 3f);
                }
                break;
            case GameStatus.PLAYING:
                {
                    switch(g_mode)
                    {
                        case Mode.FALLINGBLOCKS:
                            {
                                if(!invoked)
                                {
                                    InvokeRepeating("CreateFallingBlock", 1.5f, 0.5f);
                                    invoked = true;
                                }
                                    
                            }
                            break;                       
                    }
                    if (player1.GetComponent<PlayerData>().getHP() <= 0 || player2.GetComponent<PlayerData>().getHP() <= 0)
                        g_status = GameStatus.ROUNDEND;
                }
                break;
            case GameStatus.ROUNDEND:
                {
                    CancelInvoke();
                    invoked = false;
                    if (player1.GetComponent<PlayerData>().getHP() <= 0)
                    {
                        infoDisplay.text = "Player 2 wins";
                        player2.GetComponent<PlayerData>().IncreaceScore();
                    }
                        
                    else if (player2.GetComponent<PlayerData>().getHP() <= 0)
                    {
                        infoDisplay.text = "Player 1 wins";
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
        }*/
    }void pauseGame()
    {
        g_status = GameStatus.PAUSE;
        infoDisplay.text = "";
    }
    void startGame()
    {
        g_status = GameStatus.PLAYING;
        infoDisplay.text = "";
    }
    void setText()
    {
        infoDisplay.text = textToDisplay;
    }

    void nextRound()
    {
        switch(Random.Range(0,3))
        {
            case 0:
                g_mode = Mode.COINGRAB;
                SceneManager.LoadScene("CoinGrab");
                break;
            case 1:
                g_mode = Mode.FALLINGBLOCKS;
                SceneManager.LoadScene("FallingBlocks");
                break;
            case 2:
                g_mode = Mode.CATCHUP;
                SceneManager.LoadScene("CatchUp");
                break;
            default:
                g_mode = Mode.MENU;
                SceneManager.LoadScene("Menu");
                break;
        };
    }
<<<<<<< HEAD
    public void setPlayers(GameObject p1, GameObject p2)
    {
        player1 = p1;
        player2 = p2;
    }
    public GameObject[] getPlayers()
    {
        GameObject[] players = {player1, player2};
        return players;

    }
    public void setScore(int p1, int p2)
    {
        playersScore[0] = p1;
        playersScore[1] = p2;
    }
    public void setGameMode(Mode mode)
    {
        g_mode = mode;
    }
    public void setGameStatus(GameStatus status)
    {
        g_status = status;
    }
=======
>>>>>>> 1b15dbdaa15812641245313e1611b7d5e4e6d1a4
}
