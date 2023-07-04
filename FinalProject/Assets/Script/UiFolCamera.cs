using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NRKernal;


public class UiFolCamera : MonoBehaviour
{
    public OVRCameraRig overCameraRig;
    Transform cameraCenter;
    private void Start()
    {
        cameraCenter = overCameraRig.centerEyeAnchor;
    }

    Vector3 position;

    void Update()
    {
        position = cameraCenter.position + cameraCenter.forward* 2f;

        transform.position = position;
        transform.rotation = cameraCenter.rotation;
    }
}
