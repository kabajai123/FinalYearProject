using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = .1f;

    private bool hasItem = false;
    public GameObject[] itemGameObjects;
    public Sprite[] itemSprites;
    public Image yourSprite;

    public Animator ItemUIScroll;

    int index;

    //Animator itemAnimator;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();

        if (hasItem)
        {
            useItem();
        }
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
        if (other.gameObject.tag == "ItemBox")
        {
            other.gameObject.GetComponent<SphereCollider>().enabled = false;
            other.gameObject.GetComponent<Animator>().SetBool("Enlarge", true);

            StartCoroutine(getItem());
            ItemUIScroll.SetBool("Scroll", true);

            yield return new WaitForSeconds(1);
            int name = Animator.StringToHash("SpawnItemBox");

            other.gameObject.GetComponent<Animator>().SetBool("Enlarge", false);
            other.gameObject.GetComponent<SphereCollider>().enabled = true;

        }

    }

    public IEnumerator getItem()
    {
        if (!hasItem)
        {
            index = Random.Range(0, itemGameObjects.Length);
            yourSprite.sprite = itemSprites[index];
            yield return new WaitForSeconds(10f);

            itemGameObjects[index].SetActive(true);
            hasItem = true;
        }
    }

    public void useItem()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            hasItem = false;
            ItemUIScroll.SetBool("Scroll", false);
            itemGameObjects[index].SetActive(false);
        }
    }

}
