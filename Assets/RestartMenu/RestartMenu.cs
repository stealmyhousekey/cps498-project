using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class RestartMenu : MonoBehaviour
{
    //will select the restart menu scene
    public void selectScene()
    {
        SceneManager.LoadScene(2);
    }



}
