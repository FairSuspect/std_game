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
    public GameObject deathTile;
    public GameObject explosion;
    bool invoked = false;

    public Camera camera;
    public Vector3 cameraOffset;
    string textToDisplay = "";
    public enum GameStatus
    {
        PREPARING,
        PAUSE,
        PLAYING,
        ROUNDEND
    }
    public GameStatus g_status;
    void Awake()
    {
        gmMode = GameObject.FindGameObjectWithTag("GameController");
        gmMode.GetComponent<GameMode>().setPlayers(player1, player2);
        Debug.Log("I'v got gmMode: " + gmMode);
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch (g_status)
        {
            case GameStatus.PREPARING:
                {

                    Invoke("pauseGame", 3f);
                }
                break;
            case GameStatus.PLAYING:
                {
                    if (!invoked)
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
                    for (int i = 0; i < GameObject.FindGameObjectsWithTag("Enemy").Length; ++i)
                        Destroy(GameObject.FindGameObjectWithTag("Enemy"));
                    invoked = false;
                    if (player1.GetComponent<PlayerData>().getHP() <= 0)
                    {
                        //infoDisplay.text = "Player 2 wins";
                        gmMode.GetComponent<GameMode>().setScore(gmMode.GetComponent<GameMode>().playersScore[0], gmMode.GetComponent<GameMode>().playersScore[1] + 1);
                        Instantiate(explosion, player1.transform.position, player1.transform.rotation);
                        player2.GetComponent<PlayerData>().IncreaceScore();
                        SpriteRenderer sr = player1.GetComponent<SpriteRenderer>(); ;
                        sr.enabled = false;
                        ZoomOnWinner(player2);
                    }

                    else if (player2.GetComponent<PlayerData>().getHP() <= 0)
                    {
                        //infoDisplay.text = "Player 1 wins";
                        gmMode.GetComponent<GameMode>().setScore(gmMode.GetComponent<GameMode>().playersScore[0] + 1, gmMode.GetComponent<GameMode>().playersScore[1]);
                        Instantiate(explosion, player2.transform.position, player2.transform.rotation);
                        player1.GetComponent<PlayerData>().IncreaceScore();
                        ZoomOnWinner(player1);

                    }
                    g_status = GameStatus.PAUSE;
                    Invoke("nextRound", 1f);



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
    void nextRound()
    {
        switch (Random.Range(0, 3))
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
    void pauseGame()
    {
        g_status = GameStatus.PAUSE;
    }
    void startGame()
    {
        g_status = GameStatus.PLAYING;
    }
    void CreateFallingBlock()
    {
        Instantiate(deathTile);
    }

    private void ZoomOnWinner(GameObject player)
    {
        Vector3 newPosition = player.transform.position + cameraOffset;
        camera.transform.position = Vector3.Lerp(camera.transform.position, newPosition, Time.deltaTime * 0.5f);
        camera.orthographicSize = Mathf.Lerp( camera.orthographicSize, 1, Time.deltaTime * 0.5f);
    }
}
