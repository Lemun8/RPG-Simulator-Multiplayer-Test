using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSpawner : MonoBehaviour
{
    public GameObject healthPack;
    private float respawnTime = 5f;
    private bool spawned;
    private GameObject currentHealthPack;
    
    // Start is called before the first frame update
    void Start()
    {
        spawned = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentHealthPack == null)
        {
            if (spawned == true)
            {
                StartCoroutine(spawnDelay());
                currentHealthPack = Instantiate(healthPack, transform);
            }
        }
    }

    private IEnumerator spawnDelay()
    {
        spawned = false;
        yield return new WaitForSeconds(respawnTime);
        spawned = true;
    }
}
