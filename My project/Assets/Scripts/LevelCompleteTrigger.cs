using UnityEngine;

public class LevelCompleteTrigger : MonoBehaviour
{
    private PostGameScreenController postGameScreenController;
    public string conditionNotMetMessage = "You must interact with the object to complete the level!";
    public Color conditionNotMetColor = Color.red; // Color to change to when condition is not met
    public float colorChangeDuration = 0.5f; // Duration to show the condition not met color
    private Renderer objectRenderer;
    private Color originalColor;

    void Start()
    {
        postGameScreenController = FindObjectOfType<PostGameScreenController>();
        if (postGameScreenController == null)
        {
            Debug.LogError("PostGameScreenController not found in the scene.");
        }

        objectRenderer = GetComponent<Renderer>();
        if (objectRenderer != null)
        {
            originalColor = Color.cyan;
        }
        else
        {
            Debug.LogError("No Renderer found on the level complete trigger object.");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (InteractableObject.hasInteracted)
            {
                postGameScreenController.ShowPostGameScreen("Congratulations! You completed the level!");
            }
            else
            {
                ConditionNotMetFeedback();
            }
        }
    }

    private void ConditionNotMetFeedback()
    {
        Debug.Log(conditionNotMetMessage);
        ChangeColor(conditionNotMetColor);
        Invoke("ResetColor", colorChangeDuration);
    }

    private void ChangeColor(Color newColor)
    {
        if (objectRenderer != null)
        {
            objectRenderer.material.color = newColor;
        }
    }

    private void ResetColor()
    {
        if (objectRenderer != null)
        {
            objectRenderer.material.color = originalColor;
        }
    }
}
