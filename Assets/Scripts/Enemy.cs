using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class Enemy : Interactable
{
    GameObject enemyGameObject; // Changed playerManager to GameObject

    CharacterStats myStats;

    void Start()
    {
        enemyGameObject = GameObject.FindGameObjectWithTag("Enemy"); // Finding the GameObject with tag "Enemy"
        myStats = GetComponent<CharacterStats>();
    }

    public override void Interact()
    {
        base.Interact();
        if (enemyGameObject != null)
        {
            CharacterCombat enemyCombat = enemyGameObject.GetComponent<CharacterCombat>(); // Getting CharacterCombat component from the enemyGameObject
            if (enemyCombat != null)
            {
                enemyCombat.Attack(myStats); // Attacking with the provided stats
            }
        }
    }
}