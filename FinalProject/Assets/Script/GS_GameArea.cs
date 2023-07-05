using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GS_GameArea : MonoBehaviour
{
    public GameObject target;
    public GameObject hints;
    public float x, z;
    public string Area = "";
    public float RandomArea;

    
    
    private void Start()
    {
        RandomL();
    }
    void RandomL()
    {
        int Rand;
        int Lenght = 4;
        List<int> list = new List<int>();
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

    //void Follow() {

    //    switch () {
    //        case "Area A": 
    //            break;
    //        case "Area B":
    //            break;
    //        case "Area C":
    //            break;
    //        case "Area D":
    //            break;
    //    }

    //}

    void Update()
    {
        x = target.transform.position.x;
        z = target.transform.position.z;
        if (x > 0 && z > 0)
        {
            Area = "Area A";

        }
        if (0 > x && x > -50 && z > 0)
        {
            Area = "area B";

        }
        if (x > 0 && 0 > z && z > -50)
        {
            Area = "Area C";

        }
        if (0 > x && x > -50 && 0 > z && z > -50)
        {
            Area = "Area D";

        }
    }

}
