using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void StartButton() {
        SceneManager.LoadScene("MainCarScene");
    }
    public void TutorialButton() {
        SceneManager.LoadScene("TutorialScene");
    }
    public void ExitButton() {
        Application.Quit();
        Debug.Log("Now Exiting");
    }
}
