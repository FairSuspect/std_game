﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public int score = 0;
    public int hp = 100;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void IncreaceScore()
    {
        score++;
    }
    public int getScore()
    {
        return score;
    }
    public void setScore(int value)
    {
        score = value;
    }
    public void getDamage(int damage)
    {
        hp -= damage;
    }
    public int getHP()
    {
        return hp;
    }
    public void setHP(int value)
    {
        hp = value;
    }
    public void Death()
    {
        Debug.Log(gameObject + " is dead");
        Destroy(gameObject.GetComponent<BoxCollider2D>(), 2f);
    }
}
