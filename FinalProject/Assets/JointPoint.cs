using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using NRKernal;

public class JointPoint : MonoBehaviour
{
    public HandState _RightHandState;
    public HandState _LeftHandState;
    public HandState _reset;
    public bool handStateTracking;
    public HandJointID handJoint;
    public HandEnum handEnum;
    public Pose _RightJointPose;
    public Pose _LeftJointPose;
    public ControllerHandEnum domainHand;

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
        //NRInput.GetPosition(domainHand[a]); 
        Debug.LogError(domainHand);
        UpdateJointPose();
    }


    public void UpdateJointPose()
    {
        _RightHandState = NRInput.Hands.GetHandState(HandEnum.RightHand);
        _LeftHandState = NRInput.Hands.GetHandState(HandEnum.LeftHand);

        _RightJointPose = _RightHandState.GetJointPose(handJoint);
        _LeftJointPose = _LeftHandState.GetJointPose(handJoint);

        transform.position = _RightJointPose.position;
        _RightPositionText.text = "Right Hand Position: " + _RightJointPose.position.ToString();
        transform.rotation = _RightJointPose.rotation;
        _RightRotationText.text = "Right Hand Rotation: " + _RightJointPose.rotation.ToString();

        transform.position = _LeftJointPose.position;
        _LeftPositionText.text = "Left Hand Position: " + _LeftJointPose.position.ToString();
        transform.rotation = _LeftJointPose.rotation;
        _LeftRotationText.text = "Left Hand Rotation: " + _LeftJointPose.rotation.ToString();

        //if(handStateTracking == false)
        //{
        //    _reset.Reset();
        //    Debug.Log("handStateTracking: True");
        //    _jointPose.position = transform.position;
        //    _jointPose2.position = transform.position;
        //}        
    }
}
