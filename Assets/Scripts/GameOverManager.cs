using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverUI;
    public Slider fuelSlider;
    private bool gameOver = false;
    public TMP_Text finalScoreText;
    private ScoreCounter scoreCounter;

    // Start is called before the first frame update
    void Start()
    {
        GameObject scoreObject = GameObject.FindGameObjectWithTag("ScoreCounter");
        scoreCounter = scoreObject.GetComponent<ScoreCounter>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if fuel is zero and game isn't already over
        if (fuelSlider.value <= 0 && !gameOver)
        {
            TriggerGameOver();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!gameOver && (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Asteroid")))
        {
            TriggerGameOver();
        }
    }

    void TriggerGameOver()
    {
        gameOver = true;

        // Display the Game Over UI
        gameOverUI.SetActive(true);

        // Copy the score from ScoreCounter to the Game Over screen
        float finalScore = scoreCounter.GetCurrentScore();
        finalScoreText.text = "FINAL SCORE: " + finalScore.ToString();

        HighScoreManager.AddScore(finalScore);

        // Freeze time
        Time.timeScale = 0;
    }
}
