using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using NRKernal;
using Oculus.Interaction.Input;
using Oculus.Interaction;

public class CalculatetheHandGesture : MonoBehaviour
{
    //public HandJointID[] handJoint;
    //public HandEnum handEnum;

    public ActiveStateGroup _RockposeR;
    public ActiveStateGroup _RockposeL;

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
    public List<Vector3> _KeepTrackRPosition;
    public List<Vector3> _KeepTrackLPosition;

    public TMP_Text _RAngleText;
    public TMP_Text _RAngleYText;
    public TMP_Text _LAngleYText;
    public TMP_Text _LAngleText;

    public bool isSpawned = false;

    public NetworkSend _Command;

    void Start()
    {
        _KeepTrackRPosition = new List<Vector3>();
        _KeepTrackLPosition = new List<Vector3>();
    }

    void Update()
    {
        findHand();
        addingPositionList();

        //if (!isSpawned)
        //{
        //    //Make sure just Spawn 1 cube
        //    spawnObj();
        //}
        ////else if (_RightHandState.isTracked == false && _RightHandState.currentGesture == HandGesture.None)
        //else if (_RightHandState.isTracked == false && _RightHandState.currentGesture == HandGesture.None && _LeftHandState.isTracked == false && _LeftHandState.currentGesture == HandGesture.None)
        //{
        //    //Cannot Detect the hand the CenterPoint will disappear
        //    _savingRing.SetActive(false);
        //    lostHandPosition();
        //    Debug.Log("Active the sphere = false");
        //}
        ////else if (_RightHandState.isTracked == true && _RightHandState.currentGesture == HandGesture.Grab)
        //else if (_RightHandState.isTracked == true && _RightHandState.currentGesture == HandGesture.Grab && _LeftHandState.isTracked == true && _LeftHandState.currentGesture == HandGesture.Grab)
        //{
        //    //Detecting the hand the CenterPoint will show
        //    _savingRing.SetActive(true);
        //    driving();
        //    Debug.Log("Active the sphere = true");
        //}

        if (!isSpawned)
        {
            //Make sure just Spawn 1 cube
            spawnObj();
        }
        else if (_RockposeR.Active == false && _RockposeL.Active == false)
        {
            //Cannot Detect the hand the CenterPoint will disappear
            _savingRing.SetActive(false);
            lostHandPosition();
            Debug.Log("Active the sphere = false");
        }
        else if (_RockposeR.Active == true && _RockposeL.Active == true)
        {
            //Detecting the hand the CenterPoint will show
            _savingRing.SetActive(true);
            driving();
            Debug.Log("Active the sphere = true");
        }

    }

    public void spawnObj()
    {
        //Tracking the conditions & Spawn 1 cube
        //if (_RightHandState.isTracked == true && _RightHandState.currentGesture == HandGesture.Grab)
        //if (_RightHandState.isTracked == true && _RightHandState.currentGesture == HandGesture.Grab && _LeftHandState.isTracked == true && _LeftHandState.currentGesture == HandGesture.Grab)
        if (_RockposeR.Active == true && _RockposeL.Active == true)
        {
            isSpawned = true;
            _savingRing = Instantiate(RingObject, centerPoint, Quaternion.identity);
            Debug.Log("Spawning a sphere");
        }
    }

    //public HandState _RightHandState;
    //public HandState _LeftHandState;
    
    //public Pose[] _RightJointPose;
    //public Pose[] _LeftJointPose;

    public Transform _rwrist;
    public Transform _lwrist;

    public Vector3 _RHandPosition;
    public Vector3 _LHandPosition;

    public Vector3 _RStartingPoint;
    public Vector3 _LStartingPoint;

    public bool isGettingPosition;

    public void findHand()
    {
        //Get Left & Right Hand
        //_RightHandState = NRInput.Hands.GetHandState(HandEnum.RightHand);
        //_LeftHandState = NRInput.Hands.GetHandState(HandEnum.LeftHand);

        //var handState = new HandState(handEnum);
        //handState.isTracked = true;

        //Get Right Hand Joint ID position
        //_RightJointPose[0] = _RightHandState.GetJointPose(handJoint[0]);
        //_LeftJointPose[0] = _LeftHandState.GetJointPose(handJoint[0]);

        //_RhandednessState = Handedness.Right;


        //if(_RightHandState.isTracked == true && _RightHandState.currentGesture == HandGesture.Grab)
        //if (_RightHandState.isTracked == true && _RightHandState.currentGesture == HandGesture.Grab && _LeftHandState.isTracked == true && _LeftHandState.currentGesture == HandGesture.Grab)
        if (_RockposeR.Active == true && _RockposeL.Active == true)
        {
            _RHandPosition = _rwrist.position;
            Debug.Log("R:Center: " + _RHandPosition);

            _LHandPosition = _lwrist.position;
            Debug.Log("L:Center: " + _LHandPosition);

            centerPoint = (_RHandPosition + _LHandPosition) / 2;
            Debug.Log("RadiusPosition: " + centerPoint);

            if (!isGettingPosition)
            {
                getHandPositionFirst();
            }
        }
    }

    public void driving()
    {
        //Detecting the hand the CenterPoint will show
        _savingRing.SetActive(true);
        Debug.Log("Active the sphere = true");

        //Getting the Vector from the list
        listKeepTrackRCount = _KeepTrackRPosition.Count;
        listKeepTrackLCount = _KeepTrackLPosition.Count;

        //Updating the CenterPoint
        _UpdateCenterPoint = ((_KeepTrackLPosition[listKeepTrackLCount - 1] + _KeepTrackRPosition[listKeepTrackRCount - 1]) / 2);

        //Calculate the MovingPoint
        _LDirection = (_KeepTrackLPosition[listKeepTrackLCount - 1] - _UpdateCenterPoint);
        _RDirection = (_UpdateCenterPoint - _KeepTrackRPosition[listKeepTrackRCount - 1]);

        //Calculate the angle between the Starting Point and the Updated Point
        _Rangle = Vector3.Angle(_RStartingPoint, _RDirection);
        _Langle = Vector3.Angle(_LStartingPoint, _LDirection);

        //Updating the Angle Text
        _LAngleText.text = "LeftAngle: " + _Langle.ToString();
        _RAngleText.text = "RightAngle: " + _Rangle.ToString();

        Debug.Log("The angle range: " + _Rangle);

        _RAngleYText.text = "Righ Hand Position Y: " + _KeepTrackRPosition[listKeepTrackRCount - 1].y.ToString();
        _LAngleYText.text = "Left Hand Position Y: " + _KeepTrackLPosition[listKeepTrackLCount - 1].y.ToString();

        //Limite the Angle of the Point && Checking the Angle of -+
        //Turning Left
        if (_Rangle > 20 && _Rangle < 89 && _KeepTrackRPosition[listKeepTrackRCount - 1].y > 1f)
        {
            _Command.Send("4");
            Debug.LogWarning("Print Command Num" + _Command.input);
        }

        //Turning Right
        if (_Langle > 20 && _Langle < 89 && _KeepTrackLPosition[listKeepTrackLCount - 1].y < 1f)
        {
            _Command.Send("5");
            Debug.LogWarning("Print Command Num" + _Command.input);
        }

        //Moving Forward the Car
        //if (_RightHandState.isTracked == true && _RightHandState.currentGesture == HandGesture.Grab && _LeftHandState.isTracked == true && _LeftHandState.currentGesture == HandGesture.Grab && _Langle < 20 && _Rangle < 20)
        if (_RockposeR.Active == true && _RockposeL.Active == true && _Langle < 10 &&　_Rangle < 10)
        {
            _Command.Send("1");
            Debug.LogWarning("Print Command Num" + _Command.input);
        }
    }

    public void getHandPositionFirst()
    {
        isGettingPosition = true;
        //if(_RightHandState.isTracked == true && _RightHandState.currentGesture == HandGesture.Grab)
        //if (_RightHandState.isTracked == true && _RightHandState.currentGesture == HandGesture.Grab && _LeftHandState.isTracked == true && _LeftHandState.currentGesture == HandGesture.Grab)
        if (_RockposeR.Active == true && _RockposeL.Active == true)
        {
            _RStartingPoint = centerPoint -  _rwrist.position;
            Debug.Log("RightHandFirstPosition: " + _RStartingPoint);

            _LStartingPoint = _lwrist.position - centerPoint;
            Debug.Log("LeftHandFirstPosition: " + _LStartingPoint);
        }
    }

    public void lostHandPosition()
    {
        isGettingPosition = false;

        _Rangle = 0;
        _RAngleText.text = "RightAngle: " + _Rangle.ToString();

        _Langle = 0;
        _LAngleText.text = "LeftAngle: " + _Langle.ToString();

        _RDirection.y = 0f;
        _RAngleYText.text = "Right Hand Position Y: " + _KeepTrackRPosition[listKeepTrackRCount - 1].y.ToString();

        _LDirection.y = 0f;
        _LAngleYText.text = "Left Hand Position Y: " + _KeepTrackLPosition[listKeepTrackLCount - 1].y.ToString();
    }

    public void addingPositionList()
    {
        if (_RHandPosition != _IgnorePartofPosition)
        {
            _KeepTrackRPosition.Add(_RHandPosition);
        }

        if (_LHandPosition != _IgnorePartofPosition)
        {
            _KeepTrackLPosition.Add(_LHandPosition);
        }
    }
}
