using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startGame : MonoBehaviour
{
    public bool isRelease = false;
    public bool isSelected = false;

    public NetworkSend _command;

    public void Update()
    {
        if(isRelease == false && isSelected == false)
        {
            _command.Send("");
        }
    }

    public void gameStart()
    {
        isSelected = true;
    }

    public void checkstart()
    {
        isRelease = true;
        if (isSelected == true && isRelease == true)
        {
            _command.Send("0");
        }
        else
        {
            _command.Send("");
        }
    }

    public void Exitgame()
    {
        Application.Quit();
    }
}
