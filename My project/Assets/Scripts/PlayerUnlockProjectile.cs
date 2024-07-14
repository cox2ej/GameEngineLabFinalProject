using UnityEngine;

public class PlayerUnlocksProjectile : MonoBehaviour
{
    public static PlayerUnlocksProjectile instance;
    public bool projectileAbilityUnlocked = false;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            Debug.Log("PlayerUnlocksProjectile instance set.");
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UnlockProjectile()
    {
        projectileAbilityUnlocked = true;
        Debug.Log("Projectile ability unlocked!");
    }
}
