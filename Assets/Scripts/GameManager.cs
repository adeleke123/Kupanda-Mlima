using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static bool gameiIsPaused;
    public Button restartButton;
    public TextMeshProUGUI timerText;
    private float gameTime;
    // Start is called before the first frame update
    void Start()
    {
        gameTime = 30;
        timerText.text = "Time: " + gameTime;
        gameiIsPaused = false;

    }

    // Update is called once per frame
    void Update()
    {


        gameTime -= Time.deltaTime;
        if (gameTime <= 0)
        {
            timerText.text = "Time Over!";


        }
        else
        {


            timerText.gameObject.SetActive(true);
            timerText.text = "Time: " + Mathf.FloorToInt(gameTime % 60);

        }


    }


    public void RestartGame()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);





    }
}
