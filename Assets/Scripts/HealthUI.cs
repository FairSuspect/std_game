using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthUI : MonoBehaviour
{
    private TextMeshProUGUI hpDisplay;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        hpDisplay = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        string text = player.GetComponent<PlayerData>().getHP().ToString();
        //currentTime = DateTime.Now;
        hpDisplay.text = text;
    }
}
