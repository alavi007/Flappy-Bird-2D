using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Player player;
    public SpawnManager spawnManager;

    public Text scoreText;
    
    public GameObject getReadyText;
    public GameObject gameOverText;
    public GameObject playButton;

    private int score;

    private void Awake()
    {
        Application.targetFrameRate = 60;

        Time.timeScale = 0f;
    }

    public void Play()
    {
        score = 0;
        scoreText.text = score.ToString();

        Time.timeScale = 1f;

        playButton.SetActive(false);
        gameOverText.SetActive(false);
        getReadyText.SetActive(false);

        spawnManager.ClearPipes();

        player.ResetPlayerPosition();
    }


    public void GameOver()
    {
        Time.timeScale = 0f;
        gameOverText.SetActive(true);
        playButton.SetActive(true);
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }

}