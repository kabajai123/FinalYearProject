using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameFunction : MonoBehaviour
{
    public GameObject Player;
    public float[] Itemlist;
    public int itemNum;
    Vector3[] keyframe;
    Vector3 start, end;
    public GameObject cube;
    public GameObject item;
    public GameObject Endpoint;
    public List<Vector3> SpawnPosition;


    public void SpawnItemAndStart(List<Vector3> keyFrame) {
        keyframe = keyFrame.ToArray();
        start = keyframe[0];
        end = keyframe[keyframe.Length - 1];
        for (int i =0;i<Itemlist.Length;i++) {
            float num = MathF.Floor(keyframe.Length*Itemlist[i]);
            SpawnPosition.Add(keyFrame[(int)num]);
        
        }
        Instantiate(Endpoint,new Vector3(end.x,end.y+0.5f,end.z),transform.rotation); // spawn Endpoint
        /*
        float num = 0;
        keyframe = keyFrame.ToArray();
        start = keyframe[0];
        end = keyframe[keyframe.Length - 1];
        for (int i=0; i<Itemlist;i++) {
            num += Mathf.Floor(keyframe.Length / (Itemlist + 1));
            SpawnPosition.Add(keyframe[(int)num]);
        }*/
        for (int i = 0; i < SpawnPosition.Count; i++)
        {
            Instantiate(item, new Vector3(SpawnPosition[i].x, SpawnPosition[i].y + 0.5f, SpawnPosition[i].z), transform.rotation);
         }

        /* spawn cube to know where is keyframe
        for (int i= 0; i<keyframe.Length;i++) {
            Instantiate(cube, keyframe[i], transform.rotation);
        }
        */
    }

    void Update()
    {
        
    }
}
