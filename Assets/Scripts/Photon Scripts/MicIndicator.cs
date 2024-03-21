using UnityEngine;
using Photon.Pun;

public class MicIndicator : MonoBehaviourPunCallbacks
{
    public GameObject micIndicator;
    private bool toggle = false;

    void Update()
    {
        if (photonView.IsMine && Input.GetKeyDown(KeyCode.Space))
        {
            ToggleMicIndicator();
            photonView.RPC(nameof(ToggleMicIndicatorRPC), RpcTarget.Others, toggle);
        }
    }

    private void ToggleMicIndicator()
    {
        toggle = !toggle;
        micIndicator.SetActive(toggle);
    }

    [PunRPC]
    private void ToggleMicIndicatorRPC(bool isActive)
    {
        micIndicator.SetActive(isActive);
    }
}