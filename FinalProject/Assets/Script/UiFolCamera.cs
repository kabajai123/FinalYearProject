using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NRKernal;

public class UiFolCamera : MonoBehaviour
{
    private Transform cameraCenter
    {
        get
        {
            return NRInput.CameraCenter;
        }
    }

    Vector3 position;

    void Update()
    {
        position = cameraCenter.position + cameraCenter.forward* 2f;

        transform.position = position;
        transform.rotation = cameraCenter.rotation;
    }
}
