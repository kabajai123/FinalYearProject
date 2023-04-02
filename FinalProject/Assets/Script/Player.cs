using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = .1f;
    public GameObject item;

    Animator itemAnimator;
    // Start is called before the first frame update
    void Start()
    {
        item.GetComponent<BoxCollider>();
        itemAnimator = item.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        float xDirection = Input.GetAxis("Horizontal");
        float zDirection = Input.GetAxis("Vertical");

        Vector3 moveDirection = new

        Vector3(xDirection, 0.0f, zDirection);

        transform.position += moveDirection * speed;
    }

    private IEnumerator OnTriggerEnter(Collider other)
    {
        if (item.gameObject.tag == "ItemBox")
        {
            //item.gameObject.GetComponent<SphereCollider>().enabled = false;

            Debug.Log("get hit");
            //item.gameObject.GetComponent<Animator>().SetBool("Enlarge", true);
            yield return new WaitForSeconds(0.5f);
            int name = Animator.StringToHash("SpawnItemBox");
            item.gameObject.GetComponent<Animator>().SetTrigger(name);
            //item.gameObject.GetComponent<SphereCollider>().enabled = true;

        }

    }

    private void OnTriggerExit(Collider other)
    {
        item.gameObject.GetComponent<Animator>().SetBool("Enlarge", false);
    }

}
