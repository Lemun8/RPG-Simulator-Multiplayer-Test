using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Voice.Unity;
using UnityEngine.UI;
using Photon.Pun;

public class PushToTalk : MonoBehaviour
{
    public GameObject muteMic;
    public GameObject unmuteMic;
    public bool toggle;
    public Button button;
    private bool isMobile;
    private Recorder recorder;

    private void Awake()
    {
        if(recorder == null)
        {
            recorder = GetComponent<Recorder>();
        }
        isMobile = Application.platform == RuntimePlatform.Android;
    }

    void Start()
    {
        if (isMobile)
        {
            button.gameObject.SetActive(true);
        }
    }

    private void EnableTalking()
    {
        recorder.TransmitEnabled = true;
    }

    private void DisableTalking()
    {
        recorder.TransmitEnabled = false;
    }

    void Update()
    {
        if (isMobile == false)
        {
            button.gameObject.SetActive(false);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                 toggle = !toggle;
                 if (toggle == true)
                 {
                     unmuteMic.SetActive(true);
                     muteMic.SetActive(false);
                     EnableTalking();
                 }

                 if (toggle == false)
                 {
                     muteMic.SetActive(true);
                     unmuteMic.SetActive(false);
                     DisableTalking();
                 }
            }
        }
        
    }

    public void OnMicClick()
    {
        toggle = !toggle;
        if (toggle == true)
        {
            unmuteMic.SetActive(true);
            muteMic.SetActive(false);
            EnableTalking();
        }

        if (toggle == false)
        {
            muteMic.SetActive(true);
            unmuteMic.SetActive(false);
            DisableTalking();
        }
    }
}
