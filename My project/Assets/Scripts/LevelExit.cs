using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (GameManager.Instance.HasMetPrerequisite())
            {
                SceneManager.LoadScene("Level2");
            }
            else
            {
                Debug.Log("You need to collect more items to advance!");
            }
        }
    }
}
