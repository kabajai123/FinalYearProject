using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GS_GameFunction : MonoBehaviour
{
    public int time = 10;
    private float count1=0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        count1 += Time.deltaTime;
        if (count1>1) {
            time--;
            count1 = 0;
            if (time <= 0) {
                //game end 
                
            }
        }
        

    }
}
