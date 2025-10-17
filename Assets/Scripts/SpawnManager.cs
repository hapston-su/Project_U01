using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefabs;
    private float spawnRangeX = 415;
    private float spawnPosZ = 442;
    private int enemyCount = 0;
    private int maxEnemyCount = 10;
    public GameManager gameManager;
    public ParticleSystem enemyExplosionParticle;
    private bool isGameActive = false;
    private int difficulty;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        InvokeRepeating("SpawnEnemy", 1, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        

    }
    public void SpawnEnemy()
    {
        isGameActive = FindFirstObjectByType<GameManager>().isGameActive; ;
        if (!isGameActive) return;

        if (gameManager.GameOver)
        {
            CancelInvoke("SpawnEnemy");
            Debug.Log("Game Over — stopping spawns!");
            return;
        }
        difficulty = FindFirstObjectByType<GameManager>().difficulty;
        if ( difficulty == 3)
        {
            maxEnemyCount = 20;
        }
        //Randomly generate enemy at spawn position 

        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if (enemyCount < maxEnemyCount)
        {
           
                Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPosZ);
                Instantiate(enemyPrefabs, spawnPos, enemyPrefabs.transform.rotation);
        }

       
    }

    public void EnemyExplosion()
    {
        // Play explosion particle effect
        if (enemyExplosionParticle != null)
        {
            enemyExplosionParticle.Play();
        }
        else
        {
            Debug.LogWarning("No ParticleSystem component found on the player for explosion effect.");
        }
        Debug.Log("Player has exploded.");
    }
}
