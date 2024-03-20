using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SimpleCollectibleScript : MonoBehaviour {

	public enum CollectibleTypes { Medkit }; // you can replace this with your own labels for the types of collectibles in your game!
	public CollectibleTypes CollectibleType; // this gameObject's type
	public bool rotate; // do you want it to rotate?
	public float rotationSpeed;
	public AudioSource collectSound;
	public GameObject collectEffect;
	private CharacterStats stats;
	private HealthUI healthUI;
	[SerializeField]
	PhotonView photonView;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (rotate)
			transform.Rotate (Vector3.up * rotationSpeed * Time.deltaTime, Space.World);

	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") {
			other.GetComponent<CharacterStats>().Heal(50);
			collectSound.Play();
			Collect ();
		}
	}

	public void Collect()
	{
		Debug.Log("Collecting...");

		/*if (stats == null || healthUI == null)
		{
			Debug.LogError("CharacterStats or HealthUI is null.");
			return;
		}*/

		if (collectEffect)
			Instantiate(collectEffect, transform.position, Quaternion.identity);

		if (CollectibleType == CollectibleTypes.Medkit) {

			/*healthUI.OnHealthChanged(stats.maxHealth, stats.currentHealth);*/
			Debug.Log ("Do NoType Command");
		}
		photonView.RPC(nameof(DestroyGameObject), RpcTarget.All);
	}

	[PunRPC]
	public void DestroyGameObject()
    {
		if (photonView.AmOwner)
		{
			PhotonNetwork.Destroy(gameObject);
		}
	}
}
