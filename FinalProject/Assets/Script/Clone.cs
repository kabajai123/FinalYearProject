using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clone : MonoBehaviour
{
    float time;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y-0.5f, transform.position.z);
        transform.Rotate(transform.rotation.x-90, transform.rotation.y, transform.rotation.z);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > 20) {
            Destroy(gameObject);
        
        }
    }
}
