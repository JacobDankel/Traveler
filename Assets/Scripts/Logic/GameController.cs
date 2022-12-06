using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using TMPro; 


public class GameController : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    private int time;
    void Start()
    {
        time = 0;
        UpdateTime(0);
    }

    // Update is called once per frame
    void Update()
    {
        //Quitting Game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    public void UpdateTime(int timeToAdd)
    {
        time += timeToAdd; 
        timeText.text = "Time: " + time;

    }


}