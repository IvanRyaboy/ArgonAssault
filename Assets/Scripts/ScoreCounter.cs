using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    int score;
    public void CountScore(int PoitsToScore)
    {
        score += PoitsToScore;
        Debug.Log($"Score now is: {score}");
    }
}
