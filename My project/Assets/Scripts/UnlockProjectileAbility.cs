using UnityEngine;

public class UnlockProjectileAbility : MonoBehaviour
{
    public GameObject interactPrompt;

    private bool isPlayerNearby = false;

    void Update()
    {
        if (isPlayerNearby)
        {
            Debug.Log("Player is nearby.");
            if (Input.GetButtonDown("Interact"))
            {
                Debug.Log("Interact button pressed.");
                UnlockAbility();
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
            interactPrompt.SetActive(true); // Show the interact prompt
            Debug.Log("Player entered trigger area.");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
            interactPrompt.SetActive(false); // Hide the interact prompt
            Debug.Log("Player exited trigger area.");
        }
    }

    void UnlockAbility()
    {
        if (PlayerUnlocksProjectile.instance != null)
        {
            PlayerUnlocksProjectile.instance.UnlockProjectile();
            Debug.Log("Projectile ability unlocked.");
            Destroy(gameObject);
        }
        else
        {
            Debug.LogError("PlayerUnlocksProjectile instance is not set.");
        }
    }
}
