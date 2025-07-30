using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private float spawnInterval = 2f;
    [SerializeField] private float enemySpeed = 2f;

    private float currentSpawnTime;
    void Start()
    {
        currentSpawnTime = spawnInterval;
    }

    private void Update()
    {
        currentSpawnTime -= Time.deltaTime;

        if (currentSpawnTime <= 0f)
        {
            SpawnEnemy();
            currentSpawnTime = spawnInterval;
        }
    }

    private void SpawnEnemy()
    {
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        GameObject prefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

        GameObject enemy = Instantiate(prefab,spawnPoint.position,Quaternion.identity);

        Rigidbody2D rb = enemy.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            Vector2 randomDirection = Random.insideUnitCircle.normalized;

            rb.linearVelocity = randomDirection * enemySpeed;

            rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
            rb.sharedMaterial = new PhysicsMaterial2D
            {
                bounciness = 1f,
                friction = 0f
            };
        }

    }
}
