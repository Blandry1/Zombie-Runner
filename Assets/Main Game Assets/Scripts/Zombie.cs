using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public int currentHealth;
    public PlayerLifeCollider playerCollider; //attached object manually then by GetComponent<>() bc it's not instantiated after runtime.
    static Player player;

    void Start()
    {
      //  player = FindObjectOfType<Player>();
        if (player == null)
        {
            player = Player.Instance;
        }
    }
    
    public void Damage(int damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            PlayerLifeCollider.instance.ObjectsInRange.Remove(gameObject);
            DestroyZombie();
        }
    }

    public void DestroyZombie()
    {
        Destroy(gameObject);
        // gameObject.SetActive(false);
    }

    public void DamagePlayer(float damage)
    {
         player.Life(damage);
    }
}
