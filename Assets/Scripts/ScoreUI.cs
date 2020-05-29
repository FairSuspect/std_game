using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    private TextMeshProUGUI scoreDisplay;
    public GameObject gmMode;
    private int[] score = {0,0};
    // Start is called before the first frame update
    void Awake()
    {
        gmMode = GameObject.FindGameObjectWithTag("GameController");
        score[0] = gmMode.GetComponent<GameMode>().playersScore[0];
        score[1] = gmMode.GetComponent<GameMode>().playersScore[1];

    }
    void Start()
    {
        scoreDisplay = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        string text = score[0] + " : " + score[1];
        //currentTime = DateTime.Now;
        scoreDisplay.text = text;
    }
}
