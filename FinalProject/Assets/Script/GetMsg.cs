using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Robotics.ROSTCPConnector;
using Pos = RosMessageTypes.UnityRoboticsDemo.UnityColorMsg;
using Map = RosMessageTypes.UnityRoboticsDemo.UnityColorMsg;

public class GetMsg : MonoBehaviour
{
    public GameObject CarCamera;

    // Start is called before the first frame update
    void Start()
    {
        ROSConnection.GetOrCreateInstance().Subscribe<Pos>("letgo", Local);
        ROSConnection.GetOrCreateInstance().Subscribe<Map>("mapgo", Map);

    }
    private string[] Cut;
    void Local(Pos _msg)
    {

        Cut = _msg.msg.Split("\n");
        string[] x = Cut[Cut.Length - 8].Split(" ");    //position x,y,z
        string[] y = Cut[Cut.Length - 7].Split(" ");
        string[] z = Cut[Cut.Length - 6].Split(" ");
        string[] rx = Cut[Cut.Length - 4].Split(" ");   //rotation x,y,z,w
        string[] ry = Cut[Cut.Length - 3].Split(" ");
        string[] rz = Cut[Cut.Length - 2].Split(" ");
        string[] rw = Cut[Cut.Length - 1].Split(" ");
        if (new Vector3(float.Parse(x[x.Length - 1]), float.Parse(y[y.Length - 1]), float.Parse(z[z.Length - 1])) != new Vector3(0, 0, 0))
        {
            CarCamera.transform.position = new Vector3(float.Parse(x[x.Length - 1]) * 100+500, float.Parse(y[y.Length - 1]) * 100+500, float.Parse(z[z.Length - 1]) * 100+500);
            CarCamera.transform.rotation = new Quaternion(float.Parse(rx[rx.Length - 1]), float.Parse(ry[ry.Length - 1]), float.Parse(rz[rz.Length - 1]), float.Parse(rw[rw.Length - 1]));
        }
        // This function is for moving the camera in real time
    }

    void Map(Map _data)
    {

    }
    // Update is called once per frame
    void Update()
    {

    }
}

