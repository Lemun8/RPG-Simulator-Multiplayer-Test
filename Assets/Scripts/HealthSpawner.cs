using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class HealthSpawner : MonoBehaviourPunCallbacks
{
    public GameObject healthPack;
    private float respawnTime = 5f;
    private bool spawned;
    private GameObject currentHealthPack;
    [SerializeField] PhotonView myPhotonView;

    // Start is called before the first frame update
    void Start()
    {
        spawned = true;
        StartCoroutine(SpawnDelay());
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    private IEnumerator SpawnDelay()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            if (currentHealthPack == null)
            {
                currentHealthPack = PhotonNetwork.Instantiate(healthPack.name, transform.position, Quaternion.identity);
                Debug.Log("Not working");
            }
            else
            {
                Debug.Log("Missing");
            }
        }
    }
}