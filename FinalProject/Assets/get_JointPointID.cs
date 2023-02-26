using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NRKernal;
using UnityEngine.UI;

public class get_JointPointID : MonoBehaviour
{
    public HandJointID[] handJointID;
    public Pose[] _RightJointPose;
    public Text[] _RightJointPoseIDPosition;
    public Text[] _RightJointPoseIDRotation;
    public HandState _RightHandState;

    void Update()
    {
        _RightHandState = NRInput.Hands.GetHandState(HandEnum.RightHand);

        for (int i = 0; i < 24; i++)
        {
            _RightJointPose[i] = _RightHandState.GetJointPose(handJointID[i]);
            transform.position = _RightJointPose[i].position;
            _RightJointPoseIDPosition[i].text = "Right Hand Position: " + _RightJointPose[i].position.ToString();
            transform.rotation = _RightJointPose[i].rotation;
            _RightJointPoseIDRotation[i].text = "Right Hand Rotation: " + _RightJointPose[i].rotation.ToString();
        }
    }
}
