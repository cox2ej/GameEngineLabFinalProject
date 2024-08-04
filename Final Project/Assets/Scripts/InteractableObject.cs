using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public virtual void Interact()
    {
        // Define interaction behavior
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Interact();
        }
    }
}
