using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using NRKernal;
using Oculus.Interaction.Input;
using Oculus.Interaction;

public class NetworkSend : MonoBehaviour
{

    public string CarIpAddress;
    //public HandState _RightHandState;
    //public HandState _LeftHandState;

    //public HandEnum handEnum;
    public string input;

    public ActiveStateGroup _stopPoseR;
    public ActiveStateGroup _stopPoseL;

    public CalculatetheHandGesture cal;

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

        //_RightHandState = NRInput.Hands.GetHandState(HandEnum.RightHand);
        //_LeftHandState = NRInput.Hands.GetHandState(HandEnum.LeftHand);

        //var handState = new HandState(handEnum);
        //handState.isTracked = true;

        //if (handState == null)
        //    return;
        //if (cal._RockposeL.Active == false && cal._RockposeR.Active == false)
        //{
        //    Send("0");
        //}
        //if (_RightHandState.isTracked == true && _RightHandState.currentGesture == HandGesture.Stop && _LeftHandState.isTracked == true && _LeftHandState.currentGesture == HandGesture.Stop)
        if (_stopPoseL.Active == false && _stopPoseR.Active == false && cal._RockposeL.Active == false && cal._RockposeR.Active == false)
        {
            //Stopping the Car
            Send("0");
            Debug.LogWarning("Print Command Num" + input);
        }

        if (_stopPoseR.Active == true && _stopPoseL.Active == true)
        {
            //Back Forward of the Car
            Send("0");
            Debug.LogWarning("Print Command Num" + input);
        }

        if (cal._RockposeR.Active == true && _stopPoseL.Active == true)
        {
            //Back Forward of the Car
            Send("6");
            Debug.LogWarning("Print Command Num" + input);
        }
              
    }

    public void Send(string message)
    {       
        if (CheckRepeat.Equals(message)==false) {
            input = CarIpAddress + message;
            Debug.Log(input);
            UnityWebRequest www = UnityWebRequest.Get(input);
            CheckRepeat = message;
            www.SendWebRequest();
        //yield return www.SendWebRequest();
        }
    }
}
