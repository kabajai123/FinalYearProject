using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonusterAutoAnimaiton : MonoBehaviour
{
    // Start is called before the first frame update
    public float time;
    float rand;
    Animator action;
    GameObject playerPos;
    Transform cameraPos;
    private void Start()
    {
        rand = Random.Range(10, 15);
        action = GetComponent<Animator>();
        playerPos = GameObject.FindWithTag("PlayerCamera");
        cameraPos = playerPos.transform;
    }
    // Update is called once per frame
    void Update()
    {

        transform.LookAt(cameraPos.position);
        time += Time.deltaTime;
        if (time >rand) {
            
            StartCoroutine(aniamtion());
            time = 0;
        }

    }
    public IEnumerator aniamtion()
    {
        
        rand = Random.Range(10, 15);
        int randAnimate;
        randAnimate = Random.Range(0, 3);
        switch (randAnimate)
        {
            case 0:
                action.SetBool("attack01", true);
                break;
            case 1:
                action.SetBool("attack02", true);
                break;
            case 2:
                action.SetBool("Jump", true);
                break;

        }
        yield return new WaitForSeconds(2);
        action.SetBool("attack01", false);
        action.SetBool("attack02", false);
        action.SetBool("Jump", false);
       

    }
    public IEnumerator Die() {
        action.SetBool("Die", true);
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
