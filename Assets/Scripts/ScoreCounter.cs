using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    private float curScore;
    private TMP_Text guiScore;
    //timer to add 10 every 1 full second, not gradually
    private float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        guiScore = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        // Check if a full second has passed
        if (timer >= 1f)
        {
            // Add 10 points
            curScore += 10;
            guiScore.text = "SCORE: " + curScore.ToString();

            // Reset the timer
            timer = 0f;
        }
    }

    //Get the score to update the GameOver score
    public float GetCurrentScore()
    {
        return curScore;
    }
}
