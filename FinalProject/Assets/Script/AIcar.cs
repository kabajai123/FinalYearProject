using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AIcar : MonoBehaviour
{
    CreateRoadMesh createRoadMesh;
    public GameObject getRoadList;
    /// <summary>
    /// This script is for ai moving and control
    /// </summary>

    Vector3 StartPoint , EndPoint;
    float PointCount;
    void Start()
    {
        createRoadMesh = getRoadList.GetComponent<CreateRoadMesh>();

    }
    
    bool Loop = false;
    int m_count = 0;
    float dis = 0;
    Vector3 startpos = new Vector3();
    Vector3 diffpos = new Vector3();
    float timecount;
    void Update()
    {

        EndPoint = createRoadMesh.KeyPoint[createRoadMesh.KeyPoint.Count - 1];
        
        if (Input.GetKeyDown("space")||Loop) {

         
            Loop = true;
            StartPoint = createRoadMesh.KeyPoint[0];
            PointCount = createRoadMesh.KeyPoint.Count;
            dis = Vector3.Distance(transform.position, createRoadMesh.KeyPoint[m_count]);
            if (dis < 1)
            {
                timecount = 0;
                
                m_count++;
                startpos = transform.position;
                diffpos = new Vector3(createRoadMesh.KeyPoint[m_count].x,0,createRoadMesh.KeyPoint[m_count].z) - startpos;

            }
            timecount += Time.deltaTime;
            transform.position = startpos + diffpos * timecount/2;
            


        }
    }
}
