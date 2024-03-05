using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAgain : MonoBehaviour
{
    public string gameSceneName = "YourGameSceneName"; // Name of your game scene

    // Assign this method to the button's onClick event in the Inspector
    public void OnPlayAgainClicked()
    {
        // Reload the game scene to play again
        SceneManager.LoadScene(gameSceneName);
        Time.timeScale = 1f;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
