using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using NRKernal;

public class JointPoint : MonoBehaviour
{
    public HandState _RightHandState;
    public HandState _LeftHandState;

    public HandJointID handJoint;
    public HandEnum handEnum;
    public ControllerHandEnum domainHand;

    public Pose _RightJointPose;
    public Pose _LeftJointPose;

    public TMP_Text _RightPositionText;
    public TMP_Text _RightRotationText;

    public TMP_Text _LeftPositionText;
    public TMP_Text _LeftRotationText;

    void Start()
    {
        domainHand = NRInput.DomainHand;
    }

    void Update()
    {
        //Debug.LogError(domainHand);
        handPositionTracking();      
    }


    public void handPositionTracking()
    {
        _RightHandState = NRInput.Hands.GetHandState(HandEnum.RightHand);
        Debug.Log("RightHandState: " + _RightHandState.isTracked);
        _LeftHandState = NRInput.Hands.GetHandState(HandEnum.LeftHand);
        Debug.Log("LeftHandState: " + _LeftHandState.isTracked);

        _RightJointPose = _RightHandState.GetJointPose(handJoint);
        _LeftJointPose = _LeftHandState.GetJointPose(handJoint);

        transform.position = _RightJointPose.position;
        _RightPositionText.text = "Right Hand Position: " + _RightJointPose.position.ToString();
        transform.rotation = _RightJointPose.rotation;
        _RightRotationText.text = "Right Hand Rotation: " + _RightJointPose.rotation.ToString();

        //Debug.LogWarning("_RightHandState: " + _RightHandState.isTracked);
        //Debug.LogWarning("_RightHandState: " + _RightHandState.currentGesture);
        RightHandTracked();

        transform.position = _LeftJointPose.position;
        _LeftPositionText.text = "Left Hand Position: " + _LeftJointPose.position.ToString();
        transform.rotation = _LeftJointPose.rotation;
        _LeftRotationText.text = "Left Hand Rotation: " + _LeftJointPose.rotation.ToString();

        //Debug.LogWarning("_LeftHandState: " + _LeftHandState.isTracked);
        //Debug.LogWarning("_LeftHandState: " + _LeftHandState.currentGesture);
        LeftHandTracked();
    }

    public void LeftHandTracked()
    {
        if (_LeftHandState.isTracked == true )
        {

        }
        else
        {
            _LeftHandState.isTracked = false;
            _LeftHandState.currentGesture = HandGesture.None;
            if (_LeftHandState.isTracked == false && _LeftHandState.currentGesture == HandGesture.None)
            {
                Debug.LogError("handStateTracking: " + false);
                _LeftHandState.Reset();
                _LeftJointPose.position = transform.position;
                _LeftPositionText.text = "Left Hand Position: " + _LeftJointPose.position.ToString();
                _LeftJointPose.rotation = transform.rotation;
                _LeftRotationText.text = "Left Hand Rotation: " + _LeftJointPose.rotation.ToString();
            }
        }
    }

    public void RightHandTracked()
    {
        if (_RightHandState.isTracked == true )
        {

        }
        else
        {
            _RightHandState.isTracked = false;
            _RightHandState.currentGesture = HandGesture.None;
            if (_RightHandState.isTracked == false && _RightHandState.currentGesture == HandGesture.None)
            {
                Debug.LogError("handStateTracking: " + false);
                _RightHandState.Reset();
                _RightJointPose.position = transform.position;
                _RightPositionText.text = "Right Hand Position: " + _RightJointPose.position.ToString();
                _RightJointPose.rotation = transform.rotation;
                _RightRotationText.text = "Right Hand Rotation: " + _RightJointPose.rotation.ToString();
            }
        }
    }
}

