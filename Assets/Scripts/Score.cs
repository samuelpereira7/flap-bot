﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int score = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerBehavior>())
        {
            score += 100;
            GameObject.Find("Canvas").transform.Find("ScoreText").GetComponent<Text>().text = score.ToString();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //score = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
