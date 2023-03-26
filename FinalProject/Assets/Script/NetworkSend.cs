using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using NRKernal;

public class NetworkSend : MonoBehaviour
{

    public string CarIpAddress;
    public HandState _RightHandState;
    public HandState _LeftHandState;

    public HandEnum handEnum;
    string input;


    private void Update()
    {
        //input = Input.inputString;

        //switch (input)
        //{
        //    case "w":
        //        Send("1");
        //        break;
        //    case "s":
        //        Send("6");
        //        break;
        //    case "a":
        //        Send("2");
        //        break;
        //    case "d":
        //        Send("3");
        //        break;
        //    case "p":
        //        Send("0");
        //        break;
        //}

        _RightHandState = NRInput.Hands.GetHandState(HandEnum.RightHand);
        _LeftHandState = NRInput.Hands.GetHandState(HandEnum.LeftHand);

        var handState = new HandState(handEnum);
        handState.isTracked = true;

        //if (handState == null)
        //    return;
        if (_RightHandState.isTracked == true && _RightHandState.currentGesture == HandGesture.Stop && _LeftHandState.currentGesture == HandGesture.Stop)
        {
            //Stopping the Car
            Send("0");
        }
        else if (_RightHandState.isTracked == true && _RightHandState.currentGesture == HandGesture.Victory && _LeftHandState .currentGesture == HandGesture.Victory)
        {
            //Moving Forward the Car
            Send("1");
        }
    }

    public void Send(string message)
    {
        string my_command = CarIpAddress + message;
        Debug.Log(my_command);
        UnityWebRequest www = UnityWebRequest.Get(my_command);
        www.SendWebRequest();
    }
}
