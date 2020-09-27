using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    [SerializeField]
    private int totalScore = 0, gameScore = 0;

    public void GameScoreCount(int score)
    {
        gameScore += score;
    }

    public void RoundEnd()
    {
        totalScore += gameScore;
        gameScore = 0;
    }

    public void DeathReset()
    {
        gameScore = 0;
    }

}
