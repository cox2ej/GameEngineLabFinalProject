using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void ReloadCurrentLevel()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    public void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void LoadGameCompleteScreen()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        
        SceneManager.LoadScene("GameComplete");
    }

    // Method to load the main menu from the game complete screen
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}
