using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    private int score = 0;
    public bool isGameActive;
    public int difficulty;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score = 0;
        scoreText.text = "Score: " + score; 
        isGameActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame(int difficulty)
    {
        // Set game difficulty based on user input
        // For example, adjust spawn rates, enemy speed, etc.
        // This is a placeholder implementation
        isGameActive = true;
        Debug.Log("difficulty: " + difficulty);   
        // You can add more logic here to initialize the game based on difficulty
    }

    public bool GameOver = false;

    public void EndGame()
    {
        GameOver = true;
        gameOverText.gameObject.SetActive(true); 
        restartButton.gameObject.SetActive(true);
        isGameActive = false;   

    }

    public void UpdateScore(int scoreToAdd)
    {   
        score += scoreToAdd;   
        scoreText.text = "Score: " + score;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
