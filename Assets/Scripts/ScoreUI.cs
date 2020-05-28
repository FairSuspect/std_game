using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    private TextMeshProUGUI scoreDisplay;
    public GameObject player1;
    public GameObject player2;
    // Start is called before the first frame update
    void Start()
    {
        scoreDisplay = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        string text = player1.GetComponent<PlayerData>().getScore().ToString() + " : " + player2.GetComponent<PlayerData>().getScore().ToString();
        //currentTime = DateTime.Now;
        scoreDisplay.text = text;
    }
}
