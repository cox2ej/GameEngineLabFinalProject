using UnityEngine;
using UnityEngine.UI;

public class PostGameScreenController : MonoBehaviour
{
    public GameObject postGameScreen;
    public Text messageText; // Assign this in the Inspector
    public Button retryButton;
    public Button quitButton;

    void Start()
    {
        // Initially hide the post-game screen
        postGameScreen.SetActive(false);

        // Add listeners to the buttons
        retryButton.onClick.AddListener(RetryLevel);
        quitButton.onClick.AddListener(QuitGame);
    }

    public void ShowPostGameScreen(string message)
    {
        postGameScreen.SetActive(true);
        messageText.text = message;
    }

    void RetryLevel()
    {
        // Reload the current scene
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    void QuitGame()
    {
        // Quit the game (only works in built versions, not in the editor)
        Application.Quit();
    }
}
