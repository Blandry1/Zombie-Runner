using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLifeCollider : MonoBehaviour {

    public Zombie zombie;
    public float damage = 0;
    private float zombieTime = 0f;

    public static PlayerLifeCollider instance;
    public List<GameObject> ObjectsInRange = new List<GameObject>();

    void Start()
    {
        instance = this;
    }

        public void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Zombie")
        {
            ObjectsInRange.Add(collider.gameObject);
            
        }
        Debug.Log(damage);
        }
    
    public void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Zombie")
        {
            ObjectsInRange.Remove(collider.gameObject);
            
        }
    }

    private void Update()
    {
        damage = ObjectsInRange.Count; //amount of zombies inside collider

        zombieTime += Time.deltaTime;

        if(zombieTime > 1)
        {
            zombie.DamagePlayer(damage);
            zombieTime = 0;
        }
    }

   
}
