using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NRKernal;
using TMPro;

public class TutorialScript : MonoBehaviour
{
    public GameObject _UpdateMessage;
    private TextMeshProUGUI UpdateMessage;
    // Start is called before the first frame update
    private void Start()
    {
        UpdateMessage = _UpdateMessage.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (NRInput.GetButtonDown(ControllerButton.TRIGGER) || Input.GetKeyDown(KeyCode.G))
        {
            UpdateMessageFunction();
        }
    }

    private int WordsNum = 0;
    public void UpdateMessageFunction() {
        switch (WordsNum)
        {
            case 0:
                UpdateMessage.text = "Use your hands to turn left and right.";
                break;
            case 1:
                UpdateMessage.text = "Use this moving to move the car.";
                break;
            case 2:
                UpdateMessage.text = "Use this moving to stop the car.";
                break;
            case 3:
                UpdateMessage.text = "Use this moving to call menu.";
                break;
            case 4:
                UpdateMessage.text = "Let try in the game!!! ";
                break;
            case 5:
                UnityEngine.SceneManagement.SceneManager.LoadScene("MainCarScene");
                break;
        }
        WordsNum++;

    }
}
