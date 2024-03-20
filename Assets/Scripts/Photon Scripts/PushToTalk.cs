using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Voice.Unity;
using Photon.Pun;

public class PushToTalk : MonoBehaviour
{
    public GameObject muteMic;
    public GameObject unmuteMic;
    public bool toggle;
    private Recorder recorder;

    private void Awake()
    {
        if(recorder == null)
        {
            recorder = GetComponent<Recorder>();
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            toggle = !toggle;
            if(toggle == true)
            {
                unmuteMic.SetActive(true);
                muteMic.SetActive(false);
                EnableTalking();
            }

            if(toggle == false)
            {
                muteMic.SetActive(true);
                unmuteMic.SetActive(false);
                DisableTalking();
            }
        }
    }
}
