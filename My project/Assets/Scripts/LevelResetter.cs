using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelResetter : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Reset the current scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
