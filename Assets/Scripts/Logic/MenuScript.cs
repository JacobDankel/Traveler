using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void playLevel()
    {
        SceneManager.LoadScene("LabLevel");
    }
    public void Quitgame()
    {
        Application.Quit();
    }
}
