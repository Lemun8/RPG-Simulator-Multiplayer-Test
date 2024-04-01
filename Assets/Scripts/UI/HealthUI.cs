using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

[RequireComponent(typeof(CharacterStats))]
public class HealthUI : MonoBehaviourPunCallbacks
{
    public GameObject uiPrefab;
    float visibleTime = 5;
    public Transform target;
    float lastMadeVisibleTime;
    
    Transform ui;
    [SerializeField] Image healthSlider;
    

    void Start()
    {
        
        GetComponent<CharacterStats>().OnHealthChanged += OnHealthChanged;
    }

    public void OnHealthChanged(int maxHealth, int currentHealth)
    {
        lastMadeVisibleTime = Time.time;

        float healthPercent = currentHealth / (float)maxHealth;

        healthSlider.fillAmount = healthPercent;
        Debug.Log("OnHealthChanged Working");
    }

    /*void LateUpdate()
    {
        if (ui != null && photonView.IsMine)
        {
            ui.position = transform.position;
            ui.forward = -cam.forward;

            if (Time.time - lastMadeVisibleTime > visibleTime)
            {
                ui.gameObject.SetActive(false);
            }
        }
    }*/
}