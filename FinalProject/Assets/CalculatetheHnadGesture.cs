using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NRKernal;

public class CalculatetheHnadGesture : MonoBehaviour
{
    public HandState _RightHandState;
    public HandState _LeftHandState;

    public GameObject cube;
    public GameObject cube_position;

    public Pose[] _RightJointPose;

    public Vector3 _RightJointPoseX = new Vector3(0, 0, 0);
    public Vector3 Player2Pos = new Vector3(0, 0, 0);
    public Vector3 center = new Vector3(0, 0, 0);

    public HandJointID handJoint;
    public HandEnum handEnum;

    void Update()
    {
        driving();
    }

    public void driving()
    {
        _RightHandState = NRInput.Hands.GetHandState(HandEnum.RightHand);
        _LeftHandState = NRInput.Hands.GetHandState(HandEnum.LeftHand);

        var handState = new HandState(handEnum);
        handState.isTracked = true;
        handState.currentGesture = HandGesture.Grab;
        if (_RightHandState.isTracked == true && _RightHandState.currentGesture == HandGesture.Grab)
        {
            //_RightJointPoseX = GameObject.FindGameObjectWithTag(HandEnum).transform.position;
            Player2Pos = GameObject.FindGameObjectWithTag("Player2").transform.position;
            //Instantiate(cube, cube_position.transform.position, cube_position.transform.rotation);
            Debug.Log("Spawning a cube");
        }
    }
}
