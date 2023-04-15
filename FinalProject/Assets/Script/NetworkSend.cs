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

    string CheckRepeat = "example";
    
    private void FixedUpdate()
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
        if (_RightHandState.isTracked == false || _LeftHandState.isTracked == false)
        {
            Send("0");
        }
        if (_RightHandState.isTracked == true && _RightHandState.currentGesture == HandGesture.Stop && _LeftHandState.isTracked == true && _LeftHandState.currentGesture == HandGesture.Stop)
        {
            //Stopping the Car
            Send("0");
        }
        else if (_RightHandState.isTracked == true && _RightHandState.currentGesture == HandGesture.Grab && _LeftHandState.isTracked == true && _LeftHandState.currentGesture == HandGesture.Stop)
        {
            //Back Forward of the Car
            Send("6");
        }
              
    }

    public void Send(string message)
    {
       
        if (CheckRepeat.Equals(message)==false) {
            string my_command = CarIpAddress + message;
            Debug.Log(my_command);
            UnityWebRequest www = UnityWebRequest.Get(my_command);
            CheckRepeat = message;
            www.SendWebRequest();
        //yield return www.SendWebRequest();
        }
    }
}
