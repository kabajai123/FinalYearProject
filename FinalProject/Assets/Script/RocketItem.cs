using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketItem : MonoBehaviour
{
    public GameObject rocket;
    public float speed = 1;

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "player") 
        {
            
        }

    }
    */

    void Start()
    {
        rocket.gameObject.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
    }

    void Update()
    {
        rocket.transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;

        
    }
}
