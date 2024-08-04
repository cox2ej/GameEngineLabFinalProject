using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Increase the player's collected item count
            GameManager.Instance.CollectItem();
            // Destroy the item
            Destroy(gameObject);
        }
    }
}
