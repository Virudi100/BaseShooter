using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public void RestartLevel()
    {
        //redemarre le niveau
        SceneManager.LoadScene("BaseLevel");
    }

    public void QuitGame()
    { 
        //quitte le jeu
        Application.Quit();
    }

    public void RestartLevelTwo()
    {
        SceneManager.LoadScene("Level2");
    }
}
