﻿using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Text scoreText;
    int score = 0;
    bool slowMo = false;
    bool isStop = false;

	// Update is called once per frame
	void Update ()
    {
        if (!isStop)
        {
            scoreText.text = score.ToString();
            if (!slowMo)
            {
                score++;
            }
        }
	}


    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
    }

    public void isSlow(bool slow)
    {
        slowMo = slow;
    }

    public void StopScore()
    {
        isStop = true;
    }
}
