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
    Rigidbody m_Rigidbody;

    Vector3 StartPoint , EndPoint;
    float PointCount;
    void Start()
    {
        createRoadMesh = getRoadList.GetComponent<CreateRoadMesh>();
        m_Rigidbody = GetComponent<Rigidbody>();

        
    }
    
    bool Loop = true;
    void Update()
    {
        
        EndPoint = createRoadMesh.KeyPoint[createRoadMesh.KeyPoint.Count-1];

        if (Input.GetKeyDown("space")) {
            Debug.Log("fk");
            Debug.Log("count"+PointCount);
            StartPoint = createRoadMesh.KeyPoint[0];
            PointCount = createRoadMesh.KeyPoint.Count;
            m_Rigidbody.MovePosition(transform.position + createRoadMesh.KeyPoint[1] * Time.deltaTime);

            
            for (int m_count =1 ; m_count < PointCount; m_count++) {
                Loop = true;
                Debug.Log("help");
                float dis = Vector3.Distance(transform.position, createRoadMesh.KeyPoint[m_count]);
                
                do
                {
                    dis = Vector3.Distance(transform.position, createRoadMesh.KeyPoint[m_count]);
                    if (dis < 0.05f)
                    {

                        m_Rigidbody.velocity = new Vector3(0, 0, 0);
                        Loop = false;
                    }
                    else
                    {
                        m_Rigidbody.MovePosition(transform.position + createRoadMesh.KeyPoint[m_count] * Time.deltaTime);
                        Debug.Log("moving");
                    }
                } while (Loop);
                

            }
            
        }
    }
}
