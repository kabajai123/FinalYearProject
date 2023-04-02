using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public float timeCount;
    Vector3 size;
    public float speed=1;
    // Start is called before the first frame update
    void Start()
    {
        size = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        timeCount += Time.deltaTime;
        if (dosamll == true) {
            small();
        }
    }
    void small() {

        float newx = transform.localScale.x, newy = transform.localScale.y, newz = transform.localScale.z;
        newx = newx * speed/10;
        newy = newy * speed / 10;
        newz = newz * speed / 10;

        size = new Vector3(newx,newy,newz);
        if (newx < 0) {
            dosamll = false;
        }
    }
    bool dosamll = false;
    public void OnTriggerEnter(Collider other) {
        if (size.x > 0.7f)// not hit yet 
        {
            dosamll = true;
        }
      
    
    }

   
}
