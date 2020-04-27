using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class RestartOrQuit : MonoBehaviour
{

    public void SelectScene()
    {
        SceneManager.LoadScene(1);// loads scene 1 back to the game
    }

    public void SelectScene2()
    {
        SceneManager.LoadScene(0);// loads scene 0 back to the menu
    }
    public void QuitGame()
    {
        Debug.Log("QUIT!");// tests if it quits the game 
        Application.Quit();
    }

}
