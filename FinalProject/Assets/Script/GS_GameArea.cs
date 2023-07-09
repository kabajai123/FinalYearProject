using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GS_GameArea : MonoBehaviour
{
    public GameObject target;
    public GameObject block;
    public float x, z;
    public string Area = "";
    public float RandomArea;

    public Vector3 center;
    public float half;

    
    private void Start()
    {
        RandomL();
        GameObject xblock = Instantiate(block, center, Quaternion.identity);
        GameObject zblock = Instantiate(block, center, Quaternion.identity);
        xblock.transform.localScale = new Vector3(half*2, 0.2f,0.2f);
        zblock.transform.localScale = new Vector3(0.2f, 0.2f, half * 2);
    }
    public List<int> list = new List<int>();
    void RandomL()
    {
        int Rand;
        int Lenght = 4;
        
        list = new List<int>(new int[Lenght]);

        for (int j = 0; j < Lenght; j++)
        {
            Rand = Random.Range(1, 5);

            while (list.Contains(Rand))
            {
                Rand = Random.Range(1, 5);

            }

            list[j] = Rand;

        }

    }
    
    void Update()
    {
        x = target.transform.position.x;
        z = target.transform.position.z;
        if (x > center.x && z > center.z)
        {
            Area = "Area A";
            
        }
        if (x < center.x && z > center.z)
        {
            Area = "area B";

        }
        if (x > center.x && z < center.z)
        {
            Area = "Area C";

        }
        if (x < center.x && z < center.z)
        {
            Area = "Area D";

        }
    }

}
