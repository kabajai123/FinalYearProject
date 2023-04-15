using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed = .1f;

    private bool hasItem = false;
    public GameObject[] itemGameObjects;
    public Sprite[] itemSprites;
    public Image yourSprite;

    public Animator ItemUIScroll;
    int index;

    void Update()
    {
        if (hasItem)
        {
            useItem();
        }
       
    }
    private void OnTriggerEnter(Collider other) // get hit with item
    {
        Debug.Log("yo");
        if (other.gameObject.tag == "ItemBox")
        {
            Debug.Log("enter");
            other.gameObject.GetComponent<Animator>().SetBool("Enlarge", true);
            //StartCoroutine(getItem());
            ItemUIScroll.SetBool("Scroll", true);
            StartCoroutine(RespawnCheck(other.gameObject));
            
        }

    }
 
    IEnumerator RespawnCheck(GameObject ThatItem)
    {
        yield return new WaitForSeconds(5);
        ThatItem.GetComponent<Animator>().SetBool("Enlarge", false);
        Debug.Log("respawn");
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
