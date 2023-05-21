using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI scoreText; // Reference to the TextMeshProUGUI component
    public float countdownTime;
    public TextMeshProUGUI countdownText; // Reference to the TextMeshProUGUI component
    private bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        countdownTime = 90;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            countdownTime -= Time.deltaTime;
            scoreText.text = "Score: " + score.ToString();

            if (countdownTime <= 0)
            {
                countdownTime = 0;
                countdownText.text = "GAME OVER";
                gameOver = true;
                Time.timeScale = 0;
                // Perform game over actions here, such as displaying a game over screen or stopping player input.
                // You can also add a delay before performing game over actions by using a coroutine.
            }
            else
            {
                countdownText.text = "Time: " + countdownTime.ToString("F1");
            }
        }
        
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
    }

    // Restart the game
    void RestartGame()
    {
        score = 0;
        countdownTime = 90;
        gameOver = false;
        Time.timeScale = 1;
        countdownText.text = "Time: " + countdownTime.ToString("F1");
        Vector3 newPosition = new Vector3(-9.95f, -38.88f, 1f);
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = newPosition;
    }
}
