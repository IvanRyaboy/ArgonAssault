using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    TMP_Text scoreText;
    int score;

    void Start() 
    {
        scoreText = GetComponent<TMP_Text>();
        scoreText.text = "Start";
    }


    public void CountScore(int PoitsToScore)
    {
        score += PoitsToScore;
        scoreText.text = score.ToString();
    }
}
