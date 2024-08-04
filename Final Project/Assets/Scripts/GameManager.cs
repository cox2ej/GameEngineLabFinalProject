using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;
    public float spawnRate = 5.0f;
    private float nextSpawnTime = 0f;
    private int collectedItemCount = 0;
    public int requiredItemCount = 5;
    private int totalEnemies = 0;
    private int defeatedEnemies = 0;
    void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            SpawnEnemy();
            nextSpawnTime = Time.time + spawnRate;
        }
    }

    void SpawnEnemy()
    {
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(enemyPrefab, spawnPoints[spawnIndex].position, spawnPoints[spawnIndex].rotation);
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

    public void SetTotalEnemies(int count)
    {
        totalEnemies = count;
    }

    public void EnemyDefeated()
    {
        defeatedEnemies++;
        Debug.Log("Enemies Defeated: " + defeatedEnemies);

        if (defeatedEnemies >= totalEnemies)
        {
            Debug.Log("All enemies defeated! You can now exit.");
            // Enable the exit trigger
            ExitTrigger.SetActive(true);
        }
    }

    public GameObject ExitTrigger;
}
