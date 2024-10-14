using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void UpdateHighScores()
    {
        // Find the HighScoreDisplay GameObject so you can update it on click of the high scores button
        GameObject highScoreDisplayObject = GameObject.FindGameObjectWithTag("HighScoreDisplay");
        HighScoreDisplay highScoreDisplay = highScoreDisplayObject.GetComponent<HighScoreDisplay>();

        highScoreDisplay.UpdateScoreTextBoxes();
    }
}
