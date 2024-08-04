using UnityEngine;

public class UnlockDashAbility : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.UnlockDashAbility();
            Destroy(gameObject); // Remove the unlock item from the scene
        }
    }
}
