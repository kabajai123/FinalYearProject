using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkSend : MonoBehaviour
{

    public string CarIpAddress;
    // Start is called before the first frame update
    void Start()
    {

    }
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
