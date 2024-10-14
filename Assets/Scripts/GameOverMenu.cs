using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void PlayAgain()
    {
        //unfreeze time for playing again
        Time.timeScale = 1;
        SceneManager.LoadScene("Level1");
    }

    public void MainMenu()
    {
        //unfreeze time incase they play again from the menu
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }
}
