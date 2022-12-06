using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using TMPro; 


public class GameController : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    private int time;

    public GameObject boss;

    public GameObject victoryScreen;
    public TextMeshProUGUI score;
    private float fixedDeltaTime;

    private void Awake()
    {
        this.fixedDeltaTime = Time.fixedDeltaTime;
    }
    void Start()
    {
        time = 0;
        UpdateTime(0);
    }

    void Update()
    {
        //Quitting Game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if(boss == null)
        {
            victoryScreen.SetActive(true);
            victoryScreen.GetComponent<TextMeshProUGUI>().text = "Congratuations";
            score.text = "Your Score was: " + time;
            Time.fixedDeltaTime = this.fixedDeltaTime * Time.timeScale;
        }
    }

    public void UpdateTime(int timeToAdd)
    {
        time += timeToAdd;
        timeText.text = "Time: " + time;

    }
}