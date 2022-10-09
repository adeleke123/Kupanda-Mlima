using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float seconds;
    private bool isTimerRunning = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isTimerRunning == false)
        {
            return;
        }
        seconds -= Time.deltaTime;
        if (seconds <= 0)
        {
            Debug.Log("Game Over!");
            isTimerRunning = false;
        }
    }
}
