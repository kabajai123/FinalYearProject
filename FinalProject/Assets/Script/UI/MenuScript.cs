using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject GameStartMenu;
    public GameObject ConfirmNewRacewayMenu;


    public void StartButton()
    {
        SceneManager.LoadScene("CreateRacingWay");
    }

    public void ConfirmStartButton()
    {
        SceneManager.LoadScene("MainCarScene");
    }

    public void CreateNewRacewayButton()
    {
        GameStartMenu.SetActive(false);
        ConfirmNewRacewayMenu.SetActive(true);
    }

    public void ConfirmNewRacewayButton()
    {

    }

    public void RetryCreateRacewayButton()
    {

    }

    public void TutorialButton() {
        SceneManager.LoadScene("TutorialScene");
    }

    public void ExitButton() {
        Application.Quit();
        Debug.Log("Now Exiting");
    }

}
