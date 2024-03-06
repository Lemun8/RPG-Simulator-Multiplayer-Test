using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Inventory : MonoBehaviourPunCallbacks
{
    #region Singleton

    public static Inventory instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.Log("more than one");
            return;
        }
        instance = this;
    }

    #endregion

    public delegate void OnItemChange();
    public OnItemChange onItemChangeCallback;

    public int space = 20;

    public List<Item> items = new List<Item>();

    PhotonView view;

    void Start()
    {
        view = GetComponent<PhotonView>();

        if (PhotonNetwork.IsConnected && view != null && view.IsMine)
        {
            view.TransferOwnership(PhotonNetwork.LocalPlayer);
        }
    }

    public bool Add(Item item)
    {
        
            if (!item.isDefaultItem)
            {
                if (items.Count >= space)
                {
                    Debug.Log("Not Enough Room");
                    return false;
                }
                items.Add(item);

                if (onItemChangeCallback != null)
                    onItemChangeCallback.Invoke();
            }
        
        return true;
    }

    public void Remove(Item item)
    {
        
        
            items.Remove(item);

            if (onItemChangeCallback != null)
                onItemChangeCallback.Invoke();
       
    }

}