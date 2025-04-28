using UnityEngine;
using UnityEngine.SceneManagement; // Needed for scene loading

public class GameOverManager : MonoBehaviour
{
    // Called when Retry button is pressed
    public void RetryLevel()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    // Called when Main Menu button is pressed
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu"); // Make sure your main menu scene is named "MainMenu"
    }
}
