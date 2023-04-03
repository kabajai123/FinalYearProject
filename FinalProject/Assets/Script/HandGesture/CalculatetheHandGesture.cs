using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using NRKernal;

public class CalculatetheHandGesture : MonoBehaviour
{
    public HandState _RightHandState;
    public HandState _LeftHandState;
    public HandJointID[] handJoint;
    public HandEnum handEnum;

    public GameObject RingObject;
    private GameObject _savingRing;

    private Vector3 _IgnorePartofPosition = new Vector3(0, 0, 0);
    public Vector3 centerPoint;
    public Vector3 _UpdateCenterPoint;
    public Vector3 _RDirection;
    public Vector3 _LDirection;

    public float _Rangle;
    public float _Langle;

    public int listKeepTrackRCount;
    public int listKeepTrackLCount;

    public TMP_Text _RAngleText;
    public TMP_Text _LAngleText;

    public bool isSpawned = false;

    public List<Vector3> _KeepTrackRPosition;
    public List<Vector3> _KeepTrackLPosition;


    void Start()
    {
        _KeepTrackRPosition = new List<Vector3>();
        _KeepTrackLPosition = new List<Vector3>();
    }

    void Update()
    {        
        driving();

        if(_RHandPosition != _IgnorePartofPosition)
        {
            _KeepTrackRPosition.Add(_RHandPosition);
        }

        if(_LHandPosition != _IgnorePartofPosition)
        {
            _KeepTrackLPosition.Add(_LHandPosition);
        }

        if (!isSpawned)
        {
            //Make sure just Spawn 1 cube
            spawnObj();
        }
        else if (_RightHandState.isTracked == false && _RightHandState.currentGesture == HandGesture.None)
        //else if (_RightHandState.isTracked == false && _RightHandState.currentGesture == HandGesture.None && _LeftHandState.isTracked == false && _LeftHandState.currentGesture == HandGesture.None)
        {
            //Cannot Detect the hand the CenterPoint will disappear
            _savingRing.SetActive(false);
            lostHandPosition();
            Debug.Log("Active the sphere = false");
        }
        else if (_RightHandState.isTracked == true && _RightHandState.currentGesture == HandGesture.Grab)
        //else if (_RightHandState.isTracked == true && _RightHandState.currentGesture == HandGesture.Grab && _LeftHandState.isTracked == true && _LeftHandState.currentGesture == HandGesture.Grab)
        {
            //Detecting the hand the CenterPoint will show
            _savingRing.SetActive(true);
            Debug.Log("Active the sphere = true");

            listKeepTrackRCount = _KeepTrackRPosition.Count;
            listKeepTrackLCount = _KeepTrackLPosition.Count;

            _UpdateCenterPoint = (_KeepTrackLPosition[listKeepTrackLCount - 1] + _KeepTrackRPosition[listKeepTrackLCount - 1]) / 2;

            _LDirection = _UpdateCenterPoint - _KeepTrackLPosition[listKeepTrackLCount - 1];
            _RDirection = _UpdateCenterPoint - _KeepTrackRPosition[listKeepTrackRCount - 1];

            _Rangle = Vector3.Angle(_RStartingPoint, _RDirection);
            _Langle = Vector3.Angle(_LStartingPoint, _LDirection);

            _LAngleText.text = "LeftAngle: " + _Langle.ToString();
            _RAngleText.text = "RightAngle: " + _Rangle.ToString();
            Debug.Log("The angle range: " + _Rangle);
            //if (direction.y < 0)
            //{
            //    angle = 360 - angle;
            //}
            //if (angle > maxAngle)
            //{
            //    //Destroy(_savingRing);
            //}
        }
    }

    public void spawnObj()
    {
        //Tracking the conditions & Spawn 1 cube
        if (_RightHandState.isTracked == true && _RightHandState.currentGesture == HandGesture.Grab)
        //if (_RightHandState.isTracked == true && _RightHandState.currentGesture == HandGesture.Grab && _LeftHandState.isTracked == true && _LeftHandState.currentGesture == HandGesture.Grab)
        {
            isSpawned = true;
            _savingRing = Instantiate(RingObject, centerPoint, Quaternion.identity);
            Debug.Log("Spawning a sphere");
        }
    }

    public Pose[] _RightJointPose;
    public Pose[] _LeftJointPose;

    public Vector3 _RHandPosition;
    public Vector3 _LHandPosition;

    public Vector3 _RStartingPoint;
    public Vector3 _LStartingPoint;

    public bool isGettingPosition;

    public void driving()
    {
        //Get Left & Right Hand
        _RightHandState = NRInput.Hands.GetHandState(HandEnum.RightHand);
        _LeftHandState = NRInput.Hands.GetHandState(HandEnum.LeftHand);

        var handState = new HandState(handEnum);
        handState.isTracked = true;

        //Get Right Hand Joint ID position
        _RightJointPose[0] = _RightHandState.GetJointPose(handJoint[0]);
        _LeftJointPose[0] = _LeftHandState.GetJointPose(handJoint[0]);

        //if(_RightHandState.isTracked == true && _RightHandState.currentGesture == HandGesture.Grab)
        if (_RightHandState.isTracked == true && _RightHandState.currentGesture == HandGesture.Grab && _LeftHandState.isTracked == true && _LeftHandState.currentGesture == HandGesture.Grab)
        {
            _RHandPosition = _RightJointPose[0].position;
            Debug.Log("R:Center: " + _RHandPosition);

            _LHandPosition = _LeftJointPose[0].position;
            Debug.Log("L:Center: " + _LHandPosition);

            centerPoint = (_RHandPosition + _LHandPosition) / 2;
            Debug.Log("RadiusPosition: " + centerPoint);

            if (!isGettingPosition)
            {
                getHandPositionFirst();
            }
        }
    }

    public void getHandPositionFirst()
    {
        isGettingPosition = true;
        //if(_RightHandState.isTracked == true && _RightHandState.currentGesture == HandGesture.Grab)
        if (_RightHandState.isTracked == true && _RightHandState.currentGesture == HandGesture.Grab && _LeftHandState.isTracked == true && _LeftHandState.currentGesture == HandGesture.Grab)
        {
            _RStartingPoint = centerPoint - _RightJointPose[0].position;
            Debug.Log("RightHandFirstPosition: " + _RStartingPoint);

            _LStartingPoint = centerPoint - _LeftJointPose[0].position;
            Debug.Log("LeftHandFirstPosition: " + _LStartingPoint);
        }
    }

    public void lostHandPosition()
    {
        isGettingPosition = false;
        _Rangle = 0;
        _Langle = 0;
    }
}
