using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GS_GameArea : MonoBehaviour
{
   
    public GameObject target;
    public GameObject block;
    public float x, z;
    public string Area = "";

    public Vector3 center;
    public float half;

    public GameObject Arrow;

    public GameObject[] monster;
    public float monsterNum=0;

    public List<int> list = new List<int>();

    public float timer=0;
    private void Start()
    {
        RandomL();//get random list

        status();//update status of list
       
        GameObject xblock = Instantiate(block, center, Quaternion.identity);
        GameObject zblock = Instantiate(block, center, Quaternion.identity);
        xblock.transform.localScale = new Vector3(half*2, 0.2f,0.2f);
        zblock.transform.localScale = new Vector3(0.2f, 0.2f, half * 2);
        //spawn block on x and z

    }
    
    void RandomL()//create new list of area
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

    void status() {// check the arealist status
        if (list.Count == 0) {
            RandomL();
        }
        switch (list[0]) {
            case 1:
                Arrow.transform.position = new Vector3(500 + half/2, 505, 500 + half/2);
                break;
            case 2:
                Arrow.transform.position = new Vector3(500 - half/2, 505, 500 + half/2);
                break;
            case 3:
                Arrow.transform.position = new Vector3(500 + half/2, 505, 500 - half/2);
                break;
            case 4:
                Arrow.transform.position = new Vector3(500 - half/2, 505, 500 - half/2);
                break;
        }
        
    }

    void checkpoint() { // check it player get in the correct area
        switch (Area) {
            case "Area A":
                if (list[0] == 1) {
                    list.RemoveAt(0);
                    Score.instance.addScore();
                    status();
                }
                break;
            case "Area B":
                if (list[0] == 2)
                {
                    Score.instance.addScore();
                    list.RemoveAt(0);
                    status();
                }
                break;
            case "Area C":
                if (list[0] == 3)
                {
                    Score.instance.addScore();
                    list.RemoveAt(0);
                    status();
                }
                break;
            case "Area D":
                if (list[0] == 4)
                {
                    Score.instance.addScore();
                    list.RemoveAt(0);
                    status();
                }
                break;
        }
    
    }

    void monsterFunction()
    {
        //spawn monster
        if (monsterNum < 5)
        {
            if (timer > 10)
            {
                float xx = Random.Range(500 + -half, 500 + half);
                float yy = Random.Range(500 + -half, 500 + half);
                for(int i = 0; i < 2; i++)
                {
                    Instantiate(monster[i], new Vector3(xx, 500, yy), Quaternion.identity);
                }
                timer = 0;
                monsterNum++;
            }
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
            Area = "Area B";
            
            
        }
        if (x > center.x && z < center.z)
        {
            Area = "Area C";
           
            
        }
        if (x < center.x && z < center.z)
        {
            Area = "Area D";

            
        }//update player area now

        checkpoint();
        timer += Time.deltaTime;
        monsterFunction();
    }

}
