using System;
using UnityEngine;

public class Score
{
    private uint score;
    public event Action<uint> OnScoreChanged;

    public uint CurrentScore
    {
        get
        {
            return score;
        }
        private set
        {

        }
    }

    public Score()
    {
        score = 0;
    }

    public Score(uint startingAmount)
    {
        score = startingAmount;
    }

    /// <summary>
    /// Adds the amount given.
    /// </summary>
    /// <param name="addAmount"></param>
    public void AddToScore(uint addAmount)
    {
        score += addAmount;
        TriggerOnScoreChangedEvent();
    }

    /// <summary>
    /// Subtracts the amount given to the score.
    /// Specifically disallows wrapping around to uint max.
    /// </summary>
    /// <param name="subtractAmount"></param>
    public void RemoveFromScore(uint subtractAmount)
    {
        int testScore = (int)(score - subtractAmount);

        if (testScore < 0)
            score = 0;
        else
            score -= subtractAmount;

        TriggerOnScoreChangedEvent();
    }

    private void TriggerOnScoreChangedEvent()
    {
        if (OnScoreChanged != null)
            OnScoreChanged(score);
    }
}
