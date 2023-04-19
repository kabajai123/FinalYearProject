using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameFunction : MonoBehaviour
{
    public GameObject Player;
    public float[] Itemlist;
    //public int itemNum;
    public int CoinNum;
    public int monsterNum;
    Vector3[] keyframe;
    Vector3 start, end;
    public GameObject cube;
    public GameObject item;
    public GameObject Endpoint;
    public GameObject Coin;
    public GameObject Pos;
    public GameObject Monster;
    public List<Vector3> SpawnPosition;

    public void SpawnItemAndStart(List<Vector3> keyFrame)
    {
        keyframe = keyFrame.ToArray();
        start = keyframe[0];
        end = keyframe[keyframe.Length - 1];

        for (int i =0;i<Itemlist.Length;i++)
        {
            float num = MathF.Floor(keyframe.Length*Itemlist[i]);
            SpawnPosition.Add(keyFrame[(int)num]);        
        }

        Instantiate(Endpoint, new Vector3(end.x,end.y,end.z),transform.rotation); // spawn Endpoint
        int straight = keyframe.Length; 

        for (int i =0;i<CoinNum;i++)
        {
            int RandS = UnityEngine.Random.Range(0,straight);
            float RandH = UnityEngine.Random.Range(-10,10);
            Vector3 RandPos = new Vector3(keyframe[RandS].x+RandH, keyframe[RandS].y, keyframe[RandS].z);
            GameObject ThatCoin = Instantiate(Coin, RandPos, transform.rotation);
            GameObject pos = Instantiate(Pos, RandPos, transform.rotation);  
            ThatCoin.transform.parent = pos.transform;
            pos.transform.parent = transform;
        }

        for (int i = 0; i < monsterNum; i++)
        {
            int RandS = UnityEngine.Random.Range(0, straight);
            float RandH = UnityEngine.Random.Range(-10, 10);
            Vector3 RandPos = new Vector3(keyframe[RandS].x + RandH, keyframe[RandS].y, keyframe[RandS].z);
            GameObject ThatMonster = Instantiate(Monster, RandPos, transform.rotation);
            GameObject pos = Instantiate(Pos, RandPos, transform.rotation);
            ThatMonster.transform.parent = pos.transform;
            pos.transform.parent = transform;
        }

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
}
