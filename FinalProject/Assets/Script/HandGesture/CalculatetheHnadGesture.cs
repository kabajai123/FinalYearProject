using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NRKernal;

public class CalculatetheHnadGesture : MonoBehaviour
{
    //private Transform object_a;
    //private Transform object_b;
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

    public Vector3 _rHnadPosition;
 
    public HandJointID[] handJoint;
    public HandEnum handEnum;

    public bool isSpawned = false;

    void Start()
    {
        domainHand = NRInput.DomainHand;
        domainHand = ControllerHandEnum.Left;
    }

    void Update()
    {        
        driving();

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
            Debug.Log("Position: " + _savingRing.transform.position);

            //movingRotation = new Vector3(centerXrotation, centerYrotation, centerZrotation);
            //obj.transform.eulerAngles = Vector3.MoveTowards(movingRotation, movingRotation, step);

            //float euler_y = object_a.eulerAngles.y;
            //object_b.eulerAngles = new Vector3(object_b.eulerAngles.x, euler_y, object_b.eulerAngles.z);
            //Vector3 circleEdgePos = object_a.position + object_a.forward * radius;
            //object_b.LookAt(circleEdgePos);
            Debug.Log("Position: " + _savingRing.transform.eulerAngles);


            Vector3 direction = _RightJointPose[0].position - transform.position;
            angle = Vector3.Angle(Vector3.right, direction);
            //Debug.Log("The angle range: " + angle);
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
            _savingRing = Instantiate(RingObject, _rHnadPosition, Quaternion.identity);
            Debug.Log("Spawning a sphere");
        }
    }

    public float center; 
    public float maxAngle;
    public float angle = 0;

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

        _rHnadPosition = (_RightJointPose[0].position + _LeftJointPose[0].position) / 2;
        //transform.position = _Camera.transform.position;
        Debug.Log("Center: " + _rHnadPosition);

        //radius = _RightJointPose[0].position - movingPosition;
        //Debug.Log("RadiusPosition: " + radius);

        //Vector3 direction = transform.position - _RightJointPose[0].position;
        //float angle = Vector3.Angle(Vector3.right, direction);
        //Debug.Log("The angle range: " + angle);
        //if (direction.y < 0)
        //{
        //    angle = 360 - angle;
        //}
        //if (angle > maxAngle)
        //{
        //    Destroy(_savingRing);
        //}
    }
}
