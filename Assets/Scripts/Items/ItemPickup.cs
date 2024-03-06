using UnityEngine;
using Photon.Pun;

public class ItemPickup : Interactable
{
    public Item item;
    public AudioSource pickup;

    public override void Interact()
    {
        base.Interact();

        PhotonView photonView = GetComponent<PhotonView>();
        if (photonView != null)
        {
            bool wasPickedUp = Inventory.instance.Add(item);
            photonView.RPC(nameof(PickUp), RpcTarget.All);
        }
        else
        {
            Debug.LogError("PhotonView component not found on the GameObject.");
        }
    }

    [PunRPC]
    void PickUp()
    {
        Debug.Log("Picking up " + item.name);
        //bool wasPickedUp = Inventory.instance.Add(item);
        pickup.Play();

        //if (wasPickedUp)
            Destroy(gameObject);
    }
}