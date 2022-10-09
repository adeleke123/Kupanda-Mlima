using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool gameOver;
    public static bool levelCompleted;
    public GameObject gameOverPanel;
    public GameObject levelCompletedPanel;
    public GameObject gameStartPanel;
    public GameObject gamePlayPanel;

    public static bool gameiIsPaused;
    public Button restartButton;
    public TextMeshProUGUI timerText;
    private float gameTime;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        gameTime = 30;
        timerText.text = "Time: " + gameTime;
        gameOver = levelCompleted = gameiIsPaused = false;
    }

    // Update is called once per frame
    void Update()
    {
        gameTime -= Time.deltaTime;
        if (gameTime <= 0)
        {
            timerText.text = "Time Over!";
            gameOver = true;
        }
        else
        {
            timerText.gameObject.SetActive(true);
            timerText.text = "Time: " + Mathf.FloorToInt(gameTime % 60);

        }

        if (gameOver)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
        }

        if (levelCompleted)
        {
            levelCompletedPanel.SetActive(true);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            gameStartPanel.SetActive(false);
            gamePlayPanel.SetActive(true);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
