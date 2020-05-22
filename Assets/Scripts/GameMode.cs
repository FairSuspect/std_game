using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameMode : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public GameObject Camera;
    public GameObject infoText;
    public GameObject deathTile;

    private TextMeshProUGUI infoDisplay;
    string textToDisplay;

    Vector3 position_p1_grab = new Vector3(-6.35f,-0.7f,0);
    Vector3 position_p2_grab = new Vector3(8.07f, 0.6f, 0);
    Vector3 position_p1_fallingBlocks = new Vector3(31.51f, 3.4f, 0);
    Vector3 position_p2_fallingBlocks = new Vector3(37.87f, 3.49f, 0);
    Vector3 position_camera_grab = new Vector3(0, 0, -1);
    Vector3 position_camera_fallingBlocks = new Vector3(36.73f, 0, -1);

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
        FALLINGBLOCKS
    }
    public GameStatus g_status;
    public Mode g_mode;
    // Start is called before the first frame update
    void Start()
    {
        infoDisplay = infoText.GetComponent<TextMeshProUGUI>();
        GetComponent<AudioSource>().Play();
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
                                    InvokeRepeating("CreateFallingBlock", 3f, 0.5f);
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
                        infoDisplay.text = "Player 2 wins";
                    else if (player2.GetComponent<PlayerData>().getHP() <= 0)
                        infoDisplay.text = "Player 1 wins";
                    if (Random.Range(0,2) == 0)
                        g_mode = Mode.COINGRAB;
                    else
                        g_mode = Mode.FALLINGBLOCKS;
                    g_status = GameStatus.PREPARING;


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
    void CreateFallingBlock()
    {
        Instantiate(deathTile);          
    }
}
