using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Show level complete message or transition to the next scene
            Debug.Log("Level Completed!");
            // Example: Load next level or show victory screen
            SceneManager.LoadScene("VictoryScreen"); // Replace with actual scene name
        }
    }
}
