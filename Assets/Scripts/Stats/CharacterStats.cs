using UnityEngine;
using Photon.Pun;

public class CharacterStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth { get; private set; }

    public Stat damage;
    public Stat armor;

    [SerializeField]
    protected PhotonView photonView;

    public event System.Action<int, int> OnHealthChanged;

    void Awake()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        
    }

    [PunRPC]
    public void RPCTakeDamage (int damage/*, PhotonMessageInfo info*/)
    {
        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        currentHealth -= damage;
        Debug.Log(transform.name + "takes" + damage + "damage.");

        if(OnHealthChanged != null)
        {
            OnHealthChanged(maxHealth, currentHealth);
        }

        if(currentHealth <= 0)
        {
            Die();
            /*PlayerManager.Find(info.Sender).GetKill();*/
        }
    }

    public void TakeDamage(int damage)
    {
        // Check if photonView is null before calling RPC
        if (photonView != null)
        {
            // Call RPC to take damage across the network
            photonView.RPC(nameof(RPCTakeDamage), RpcTarget.All, damage);
        }
        else
        {
            Debug.LogError("PhotonView is null in CharacterStats");
        }
    }

    [PunRPC]
    public void Healing(int heal)
    {
        currentHealth += heal;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
            Debug.Log("Healed");
        }
    }

    public void Heal(int heal)
    {
        // Check if photonView is null before calling RPC
        if (photonView != null)
        {
            // Call RPC to take damage across the network
            photonView.RPC(nameof(Healing), RpcTarget.All, heal);
        }
        else
        {
            Debug.LogError("PhotonView is null in CharacterStats");
        }
    }

    public virtual void Die()
    {
        Debug.Log(transform.name + "died.");
    }
}
