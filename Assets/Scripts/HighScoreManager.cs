using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//static so I can pass it to the other scene to update high scores
public static class HighScoreManager
{
    public static List<float> highScores = new List<float> { 0, 0, 0, 0, 0 };

    public static void AddScore(float score)
    {
        highScores.Add(score);
        SortScores();
    }

    private static void SortScores()
    {
        for (int i = 0; i < highScores.Count - 1; i++)
        {
            for (int j = 0; j < highScores.Count - 1 - i; j++)
            {
                if (highScores[j] < highScores[j + 1])
                {
                    float temp = highScores[j];
                    highScores[j] = highScores[j + 1];
                    highScores[j + 1] = temp;
                }
            }
        }

        if (highScores.Count > 5)
        {
            highScores.RemoveAt(highScores.Count - 1);
        }
    }
}
