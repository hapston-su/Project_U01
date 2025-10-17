using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    private float speed = 20f;
    private Transform player;
    public GameManager gameManager;
    private bool isGameActive = false;
    private int difficulty;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Find the player by tag (make sure your player GameObject is tagged "Player")
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
       isGameActive = FindFirstObjectByType<GameManager>().isGameActive;
       difficulty = FindFirstObjectByType<DifficultyLevel>().difficulty;   
        if (!isGameActive) return;
        if (gameManager.GameOver) return; // Stop moving if game is over
        if (player == null) return;
        if (difficulty == 2) speed = 100f;  
        if (difficulty == 3) speed = 150f;
        Debug.Log("Enemy speed: " + speed + "Difficulty " + difficulty);
        // Step 1: Rotate to face player
        Vector3 direction = player.position - transform.position;
        if (direction == Vector3.zero) return;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 2f);

        // Step 2: Move forward
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

            
       
    }
}
