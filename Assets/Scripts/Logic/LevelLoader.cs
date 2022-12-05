using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    
    public string level;
    
    public void teleport()
    {
        SceneManager.LoadScene(level);
    }
}
