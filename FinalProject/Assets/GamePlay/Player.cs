using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NRKernal;
using TMPro;

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

    bool gethit;

    public TMP_Text _ScoreText;
    public float _score = 0;
    public float _addScore = 10;

    public GameObject _EndGamePanel;
    public float _scoreEnd = 0;
    public TMP_Text _ScoreEndText;

    public static int MinCount;
    public static int SecCount;
    public static float MiliCount;
    public static string _Mili;

    public GameObject min;
    public GameObject sec;
    public GameObject mili;

    public GameObject _min;
    public GameObject _sec;
    public GameObject _mili;

    public bool checkEnd = false;

    public AudioClip _spin;
    public AudioClip _Coins;
    public AudioSource audioSource;

    void Update()
    {
        if (hasItem)
        {
            useItem();
        }

        if(!checkEnd)
        {
            timer();
        }
    }

    public void timer()
    {
        MiliCount += Time.deltaTime * 10;
        _Mili = MiliCount.ToString("0");
        mili.GetComponent<TMP_Text>().text = "" + _Mili;

        if(MiliCount >= 10)
        {
            MiliCount = 0;
            SecCount += 1;
        }

        if(SecCount <= 9)
        {
            sec.GetComponent<TMP_Text>().text = "0" + SecCount + ": ";
        }
        else
        {
            sec.GetComponent<TMP_Text>().text = "" + SecCount + ": ";
        }

        if(SecCount >= 60)
        {
            SecCount = 0;
            MinCount += 1;
        }

        if(MinCount <= 9)
        {
            min.GetComponent<TMP_Text>().text = "0" + MinCount + ": ";
        }
        else
        {
            min.GetComponent<TMP_Text>().text = "" +  MinCount + ":";
        }
    }

    private void OnTriggerEnter(Collider other) // get hit with item
    {        
        if (other.gameObject.tag == "ItemBox")
        {
            other.gameObject.GetComponent<Animator>().SetBool("Enlarge", true);            
            StartCoroutine(RespawnCheck(other.gameObject));
            gethit = true;

            if (hasItem == false)
            {
                StartCoroutine(getItem());
                ItemUIScroll.SetBool("Scroll", true); // animation 
                audioSource.PlayOneShot(_spin, 0.05f);
            }
        }

        if (other.gameObject.tag == "EndPoint")
        {
            _EndGamePanel.SetActive(true);
            _scoreEnd = _score;
            _ScoreEndText.text = "Your Score: " + _scoreEnd.ToString();
            checkEnd = true;

            if(checkEnd == true)
            {
                if(SecCount <= 9)
                {
                    _sec.GetComponent<TMP_Text>().text = "0" + SecCount + ":";
                }
                else
                {
                    _sec.GetComponent<TMP_Text>().text = "" + SecCount + ":";
                }

                if (MinCount <= 9)
                {
                    _min.GetComponent<TMP_Text>().text = "0" + MinCount + ":";
                }
                else
                {
                    _min.GetComponent<TMP_Text>().text = "" + MinCount + ":";
                }

                _mili.GetComponent<TMP_Text>().text = "" + Mathf.Round(MiliCount);
            }
        }

        if (other.gameObject.tag == "Coin")
        {            
            Destroy(other.gameObject.transform.parent.gameObject);
            Destroy(other.gameObject);
            audioSource.PlayOneShot(_Coins, 0.05f);
            _score += _addScore;
            _ScoreText.text = "Score: " + _score.ToString();
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
            audioSource.Stop();
        }
    }

    public HandState _RightHandState;
    public HandState _LeftHandState;
    public HandJointID[] handJoint;
    public HandEnum handEnum;

    void Start()
    {
        //Get Left & Right Hand
        _RightHandState = NRInput.Hands.GetHandState(HandEnum.RightHand);
        _LeftHandState = NRInput.Hands.GetHandState(HandEnum.LeftHand);

        var handState = new HandState(handEnum);
        handState.isTracked = true;
    }

    public void useItem()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) || _RightHandState.currentGesture == HandGesture.UsingItem && _RightHandState.isTracked == true)
        {
            hasItem = false;
            yourSprite.GetComponent<Image>().color = new Color(0, 0, 0);
            yourSprite.GetComponent<Image>().sprite = null;

            if (index == 0)
            {
                Vector3 position = new Vector3(transform.position.x, transform.position.y + 0.4f, transform.position.z);
                Instantiate(IceCream, position, transform.rotation);
            }
            
            if (index == 1)
            {
                Vector3 position = new Vector3(transform.position.x, transform.position.y + 0.25f, transform.position.z);
                Instantiate(ItemRocket, position, transform.rotation);                
            }
        }
    }

}
