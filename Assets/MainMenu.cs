using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void NewProy(string newScene)
    {
        Debug.Log("Accessing scene: " + newScene);
        SceneManager.LoadScene(newScene);
    }
    public void LoadProy(string newScene2)
    {
        Debug.Log("Accessing scene: " + newScene2);
        SceneManager.LoadScene(newScene2);
    }
    public void QuitGame()
    {
        Debug.Log("Quit...");
        Application.Quit();
    }
}
