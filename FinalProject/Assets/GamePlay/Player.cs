using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed = .1f;

    public GameObject ItemRocket;
    public GameObject IceCream;
    private bool hasItem = false;
    public GameObject[] itemGameObjects;
    public Sprite[] itemSprites;
    public GameObject yourSprite;

    public Animator ItemUIScroll;
    public int index;

    void Update()
    {
        if (hasItem)
        {
            useItem();
        }
       
    }
    bool gethit;
    private void OnTriggerEnter(Collider other) // get hit with item
    {
        
        if (other.gameObject.tag == "ItemBox")
        {
            other.gameObject.GetComponent<Animator>().SetBool("Enlarge", true);
            
            StartCoroutine(RespawnCheck(other.gameObject));
            gethit = true;
            if (hasItem == false) {
                StartCoroutine(getItem());
                ItemUIScroll.SetBool("Scroll", true); // animation 
            }
        }
        if (other.gameObject.tag == "EndPoint") {
            /*
             GameEnd Funciton in here
             */        
        }
        if (other.gameObject.tag == "Coin") {
            Destroy(other.gameObject);
        }

    }
    private void OnTriggerStay(Collider other) // get hit when it stay
    {
        if (other.gameObject.tag == "ItemBox" && gethit == false)
        {
            OnTriggerEnter(other);

        }
    }
    IEnumerator RespawnCheck(GameObject ThatItem)// Respawn
    {
        yield return new WaitForSeconds(5);
        gethit = false;
        ThatItem.GetComponent<Animator>().SetBool("Enlarge", false);
    }

    public IEnumerator getItem()
    {
        if (!hasItem)
        {
            index = Random.Range(0, itemGameObjects.Length);            
            yield return new WaitForSeconds(2);
            yourSprite.GetComponent<Image>().sprite = itemSprites[index];
            ItemUIScroll.SetBool("Scroll", false);
            yourSprite.GetComponent<Image>().color = new Color(255,255,255);
            hasItem = true;
        }
    }

    public void useItem()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            hasItem = false;
            yourSprite.GetComponent<Image>().color = new Color(0, 0, 0);
            yourSprite.GetComponent<Image>().sprite = null;
            if (index == 0) {
                Vector3 position = new Vector3(transform.position.x, transform.position.y + 0.4f, transform.position.z);
                Instantiate(IceCream, position, transform.rotation);
            }
            
            if (index ==1 ) {
                Vector3 position = new Vector3(transform.position.x, transform.position.y + 0.25f, transform.position.z);
                Instantiate(ItemRocket, position, transform.rotation);
                
            }
        }
    }

}
