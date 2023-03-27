using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void startGame()
    {
        SceneManager.LoadScene("Main game");
    }

    public void startSokoban()
    {
        SceneManager.LoadScene("Sokoban", LoadSceneMode.Additive);
    }

    public void quitGame()
    {
        Application.Quit();
        Debug.Log("QUIT!");
    }
}
