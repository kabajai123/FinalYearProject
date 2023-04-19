using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    MonusterAutoAnimaiton monusterAutoAnimaiton;
    float time;
    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(transform.rotation.x, transform.rotation.y-90, transform.rotation.z);
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        
        transform.position += transform.right * 10 * Time.deltaTime;
        if (time>10) { Destroy(gameObject); }
    }
    private void OnTriggerEnter(Collider other) // hit monster
    {
        if (other.gameObject.tag == "Monster") {
           
            monusterAutoAnimaiton = other.GetComponent<MonusterAutoAnimaiton>();
            monusterAutoAnimaiton.StartCoroutine(monusterAutoAnimaiton.Die());
            Destroy(gameObject);
        }
    }

}
