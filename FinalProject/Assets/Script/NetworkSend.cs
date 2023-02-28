using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using NRKernal;

public class NetworkSend : MonoBehaviour
{

    public string CarIpAddress;
    public HandEnum handEnum;
    string input;


    private void Update()
    {
        input = Input.inputString;

        switch (input)
        {
            case "w":
                Send("1");
                break;
            case "s":
                Send("6");
                break;
            case "a":
                Send("2");
                break;
            case "d":
                Send("3");
                break;
            case "p":
                Send("0");
                break;

        }

        var handState = NRInput.Hands.GetHandState(handEnum);
        if (handState == null)
            return;
        switch (handState.currentGesture)
        {
            case HandGesture.Stop:
                Send("0");
                break;
        }

    }

    // Update is called once per frame
    public void Send(string message)
    {

        string my_command = CarIpAddress + message;
        Debug.Log(my_command);
        UnityWebRequest www = UnityWebRequest.Get(my_command);
        www.SendWebRequest();
    }
}
