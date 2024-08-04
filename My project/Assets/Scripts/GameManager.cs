using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public static GameManager Instance { get; private set; }

    private int collectedItemCount = 0;
    public int requiredItemCount = 5;
    public bool isDashUnlocked = false;

    void Update()
    {
    }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void CollectItem()
    {
        collectedItemCount++;
        Debug.Log("Items Collected: " + collectedItemCount);
    }

    public bool HasMetPrerequisite()
    {
        return collectedItemCount >= requiredItemCount;
    }
    public void UnlockDashAbility()
    {
        isDashUnlocked = true;
    }
}