using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public string message = "You have picked up a key!";
    public string conditionNotMetMessage = "You must defeat all enemies before interacting!";
    public float interactionDistance = 2f;
    public Color interactedColor = Color.green; // Color to change to upon interaction
    public Color conditionNotMetColor = Color.red; // Color to change to when condition is not met
    public float colorChangeDuration = 0.5f; // Duration to show the condition not met color

    private Transform player;
    private Renderer objectRenderer;
    private EnemyController[] enemies;
    private Color originalColor;
    public static bool hasInteracted = false; // Static flag to track interaction

    void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
        else
        {
            Debug.LogError("Player object not found. Make sure your player has the tag 'Player'.");
        }

        objectRenderer = GetComponent<Renderer>();
        if (objectRenderer == null)
        {
            Debug.LogError("No Renderer found on the interactable object.");
        }
        else
        {
            originalColor = objectRenderer.material.color;
        }

        enemies = FindObjectsOfType<EnemyController>();
    }

    void Update()
    {
        if (player == null)
        {
            Debug.LogWarning("Player reference is missing.");
            return;
        }

        if (Vector3.Distance(player.position, transform.position) <= interactionDistance)
        {
            if (Input.GetButtonDown("Interact"))
            {
                if (AllEnemiesDefeated())
                {
                    Interact();
                    Destroy(gameObject);
                }
                else
                {
                    ConditionNotMetFeedback();
                }
            }
        }
    }

    private void Interact()
    {
        Debug.Log(message);
        ChangeColor(interactedColor);
        StopEnemies();
        hasInteracted = true; // Set the interaction flag
        // Additional interaction logic can be added here
    }

    private void ChangeColor(Color newColor)
    {
        if (objectRenderer != null)
        {
            objectRenderer.material.color = newColor;
        }
    }

    private void ConditionNotMetFeedback()
    {
        Debug.Log(conditionNotMetMessage);
        ChangeColor(conditionNotMetColor);
        Invoke("ResetColor", colorChangeDuration);
    }

    private void ResetColor()
    {
        if (objectRenderer != null)
        {
            objectRenderer.material.color = originalColor;
        }
    }

    private bool AllEnemiesDefeated()
    {
        foreach (EnemyController enemy in enemies)
        {
            if (enemy != null && enemy.gameObject.activeSelf)
            {
                return false;
            }
        }
        return true;
    }

    private void StopEnemies()
    {
        foreach (EnemyController enemy in enemies)
        {
            enemy.StopMovement();
        }
    }
}
