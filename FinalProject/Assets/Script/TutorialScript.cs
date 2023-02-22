using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NRKernal;
using TMPro;

public class TutorialScript : MonoBehaviour
{
    public GameObject _UpdateMessage;
    private TextMeshProUGUI UpdateMessage;
    // Start is called before the first frame update
    private void Start()
    {
        UpdateMessage = _UpdateMessage.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (NRInput.GetButtonDown(ControllerButton.TRIGGER)){
            UpdateMessage.text = "Yo I am Change";
            Debug.Log("Get Iputed");
        }
    }
}
