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
    public static bool isGameStarted;

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
        gameTime = 60;
        timerText.text = "Time: " + gameTime;
        isGameStarted = gameOver = levelCompleted = gameiIsPaused = false;
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

        // if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && !isGameStarted)
        // {
        //     if (EventSystem.current.IsPointerOverGameObject (Input.GetTouch(0).fingerId))
        //         return;
        if(Input.GetMouseButtonDown(0) && !isGameStarted)
        {
            if(EventSystem.current.IsPointerOverGameObject())

            isGameStarted = true;
            gameStartPanel.SetActive(false);
            gamePlayPanel.SetActive(true);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
