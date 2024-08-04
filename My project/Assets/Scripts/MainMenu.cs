using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Method to load the game scene
    public void PlayGame()
    {
        
        SceneManager.LoadScene("Level1");
    }

    // Method to quit the game
    public void QuitGame()
    {
        // If running in the Unity editor, stop playing the scene
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        // If running in a build, quit the application
        Application.Quit();
        #endif
    }
}
