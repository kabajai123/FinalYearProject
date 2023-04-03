using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using NRKernal;

public class CalculatetheHandGesture : MonoBehaviour
{
    private Vector3 movingPosition;
    //private Vector3 movingRotation;

    public HandState _RightHandState;
    public HandState _LeftHandState;

    public GameObject RingObject;
    private GameObject _savingRing;
    public GameObject _Camera;

    public ControllerHandEnum domainHand;
    public Pose[] _RightJointPose;
    public Pose[] _LeftJointPose;

    private float RingX;
    private float RingY;
    private float RingZ;

    public Vector3 _RHandPosition;
    public Vector3 _LHandPosition;
    public Vector3 direction;
    public Vector3 abc;

    public HandJointID[] handJoint;
    public HandEnum handEnum;

    public bool isSpawned = false;
    public bool abcd;

    public TMP_Text AngleText;

    public List<Vector3> _KeepTrackPosition;

    private Vector3 _IgnorePartofPosition = new Vector3(0, 0, 0);

    void Start()
    {
        domainHand = NRInput.DomainHand;
        domainHand = ControllerHandEnum.Left;
        _KeepTrackPosition = new List<Vector3>();
    }

    void Update()
    {        
        driving();

        if(_RHandPosition != _IgnorePartofPosition)
        {
            _KeepTrackPosition.Add(_RHandPosition);
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
            Debug.Log("Active the sphere = false");
        }
        else if (_RightHandState.isTracked == true && _RightHandState.currentGesture == HandGesture.Grab)
        //else if (_RightHandState.isTracked == true && _RightHandState.currentGesture == HandGesture.Grab && _LeftHandState.isTracked == true && _LeftHandState.currentGesture == HandGesture.Grab)
        {
            //Detecting the hand the CenterPoint will show
            _savingRing.SetActive(true);
            Debug.Log("Active the sphere = true");

            //var step = .5f * Time.deltaTime;

            movingPosition = new Vector3(RingX, RingY, RingZ);
            //_savingRing.transform.position = Vector3.MoveTowards(movingPosition, movingPosition, step);
            //Debug.Log("Position: " + _savingRing.transform.position);

            //movingRotation = new Vector3(centerXrotation, centerYrotation, centerZrotation);
            //obj.transform.eulerAngles = Vector3.MoveTowards(movingRotation, movingRotation, step);
            //Debug.Log("Rotation: " + _savingRing.transform.eulerAngles);
            int listKeepTrackCount = _KeepTrackPosition.Count;
            direction = _KeepTrackPosition[listKeepTrackCount-1];
            angle = Vector3.Angle(abc, direction);
            AngleText.text = "Angle: " + angle.ToString();
            Debug.Log("The angle range: " + angle);
            if (direction.y < 0)
            {
                angle = 360 - angle;
            }
            if (angle > maxAngle)
            {
                //Destroy(_savingRing);
            }
        }
    }

    public void spawnObj()
    {
        //Tracking the conditions & Spawn 1 cube
        if (_RightHandState.isTracked == true && _RightHandState.currentGesture == HandGesture.Grab)
        //if (_RightHandState.isTracked == true && _RightHandState.currentGesture == HandGesture.Grab && _LeftHandState.isTracked == true && _LeftHandState.currentGesture == HandGesture.Grab)
        {
            isSpawned = true;
            _savingRing = Instantiate(RingObject, _RHandPosition, Quaternion.identity);
            Debug.Log("Spawning a sphere");
        }
    }

    public float center; 
    public float maxAngle;
    public float angle;

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

        //Center Position & Rotation follow Joint ID Position & Rotation
        //RingX = _RightJointPose[0].position.x - 0.25f;
        //RingY = _RightJointPose[0].position.y + 0.05f;
        //RingZ = _RightJointPose[0].position.z;

        if(_RightHandState.isTracked == true && _RightHandState.currentGesture == HandGesture.Grab)
        {
            _RHandPosition = _RightJointPose[0].position;
            Debug.Log("R:Center: " + _RHandPosition);

            if (!abcd)
            {
                getHandPositionFirst();

            }
        }


        //_LHandPosition = _LeftJointPose[0].position;
        //Debug.Log("L:Center: " + _LHandPosition);

        //if (_RightHandState.isTracked == true && _RightHandState.currentGesture == HandGesture.Grab && _LeftHandState.isTracked == true && _LeftHandState.currentGesture == HandGesture.Grab)
        //{
        //    radius = (_RHandPosition + _LHandPosition) / 2;
        //    Debug.Log("RadiusPosition: " + radius);
        //}
    }

    public void getHandPositionFirst()
    {
        abcd = true;
        if(_RightHandState.isTracked == true && _RightHandState.currentGesture == HandGesture.Grab)
        {
            abc = _RightJointPose[0].position;
            Debug.Log("RightHandFirstPosition: " + abc);
        }
    }
}
