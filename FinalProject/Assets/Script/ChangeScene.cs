using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public GameObject menubin;
    public void EndGameRestart()
    {
        SceneManager.LoadScene("MainCarScene");
    }

    public void EndGameMenu()
    {
        menubin.SetActive(false);
        SceneManager.LoadScene("MainMenuScene_demo");

    }
}
