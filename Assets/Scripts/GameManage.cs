using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManage : MonoBehaviour
{
    public GameObject objectToActivate;

    private void Update()
    {
        // Check if there are no more enemies in the scene
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy"); // Replace "Enemy" with your enemy tag

        if (enemies.Length == 0)
        {
            // All enemies are defeated, activate the object
            if (objectToActivate != null)
            {
                objectToActivate.SetActive(true);
            }
        }
    }
}
