using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuScript : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject GameStartMenu;
    public GameObject ConfirmNewRacewayMenu;
    public GameObject _WarrningObject;

    public TMP_Text _Warrning;

    public void StartButton()
    {
        SceneManager.LoadScene("CreateRacingWay");
    }

    public void yesBtn()
    {
        SceneManager.LoadScene("ModeChooseMenu");
    }

    public void CreateNewRacewayButton()
    {
        //GameStartMenu.SetActive(false);
        //ConfirmNewRacewayMenu.SetActive(true);
        _WarrningObject.SetActive(true);
        StartCoroutine(FadeOut(0.5f));
    }

    public void ConfirmNewRacewayButton()
    {
        SceneManager.LoadScene("ModeChooseMenu");
    }

    public void RetryCreateRacewayButton()
    {
        SceneManager.LoadScene("CreateRacingWay");
    }

    public void SettingBtn()
    {
        SceneManager.LoadScene("Setting");
    }

    public void TutorialButton() {
        SceneManager.LoadScene("TutorialScene");
    }

    public void ExitButton() {
        Application.Quit();
        Debug.Log("Now Exiting");
    }

    // FadeIn Effect
    public IEnumerator FadeIn(float targetAlpha)
    {
        // To Set _Warrning Color.Alpha to 0
        _Warrning.color = new Color(_Warrning.color.r, _Warrning.color.g, _Warrning.color.b, 0);

        // While Color.Alpha < 1, Loop until > 1 and Finished FadeIn
        while (_Warrning.color.a < 1.0f )
        {
            _Warrning.color = new Color(_Warrning.color.r, _Warrning.color.g, _Warrning.color.b, _Warrning.color.a + (0.045f / targetAlpha));
            yield return null;
        }
    }

    // FadeOut Effect
    public IEnumerator FadeOut(float targetAlpha)
    {
        // To Set _Warrning Color.Alpha to 1
        _Warrning.color = new Color(_Warrning.color.r, _Warrning.color.g, _Warrning.color.b, 1);

        // While Color.Alpha > 0, Loop until < 0 and Finished FadeOut
        while (_Warrning.color.a > 0.0f)
        {
            _Warrning.color = new Color(_Warrning.color.r, _Warrning.color.g, _Warrning.color.b, _Warrning.color.a - (0.0045f / targetAlpha));
            yield return null;
        }
    }
}
