using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScoreDisplay : MonoBehaviour
{
    public TMP_Text[] scoreTextBoxes;
    // Start is called before the first frame update
    void Start()
    {
        UpdateScoreTextBoxes();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScoreTextBoxes()
    {
        for (int i = 0; i < scoreTextBoxes.Length; i++)
        {
            if (i < HighScoreManager.highScores.Count)
            {
                // Set the text to the high score
                scoreTextBoxes[i].text = (i + 1) + ". " + HighScoreManager.highScores[i].ToString();
            }
        }
    }
}
