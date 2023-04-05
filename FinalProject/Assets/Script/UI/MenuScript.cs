using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject MainMenu, ConfirmStartMenu, ConfirmNewRacewayMenu;
   

    public void StartButton() {
        MainMenu.SetActive(false);
        ConfirmStartMenu.SetActive(true);
        //SceneManager.LoadScene("MainCarScene");
    }

    public void ConfirmStartButton()
    {
        SceneManager.LoadScene("MainCarScene");
    }

    public void CreateNewRacewayButton()
    {
        
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
