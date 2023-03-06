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

    public HandJointID handJoint;
    public HandEnum handEnum;

    void Update()
    {
        _RightHandState = NRInput.Hands.GetHandState(HandEnum.RightHand);  
        _LeftHandState = NRInput.Hands.GetHandState(HandEnum.LeftHand);
        driving();
    }

    public void driving()
    {
        var handState = new HandState(handEnum);
        handState.isTracked = true;
        handState.currentGesture = HandGesture.Grab;
        if (handState.isTracked == true)
        {
            Debug.Log("123321123123123123");
            while(handState.currentGesture == HandGesture.Grab)
            {
                Instantiate(cube, cube_position.transform.position, cube_position.transform.rotation);
                Debug.Log("Spawning a cube");
            }
        }
    }
}
