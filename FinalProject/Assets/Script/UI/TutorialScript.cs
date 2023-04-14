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
                UpdateMessage.text = "'Grab' Gestures to turn left and right similar to drive.";
                break;
            case 1:
                UpdateMessage.text = "Holding Left Hand and Right Hand 'Grab' Gestures Horizontally to move the car.";
                break;
            case 2:
                UpdateMessage.text = "Holding Left Hand 'Open' Gesture and Right Hand 'Grab' Gesture to stop the car.";
                break;
            case 3:
                UpdateMessage.text = "Pointing somewhere can use the Virtual Items.";
                break;
            case 4:
                UpdateMessage.text = "Let's have fun!!! ";
                break;
            case 5:
                UnityEngine.SceneManagement.SceneManager.LoadScene("MainCarScene");
                break;
        }
        WordsNum++;

    }
}
