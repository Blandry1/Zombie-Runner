using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSummoner : MonoBehaviour {

    public GameObject zombiePrefab;
    public Transform zombieArmy;
    public Transform zombieSpawnPoint;
    private Transform[] spawnPositions;
    public int zombieCounter;
    private bool reSpawn = false;
    public Zombie zombie;

    void Start()
    {
        spawnPositions = zombieSpawnPoint.GetComponentsInChildren<Transform>();
    }

    private void Awake()
    {
        zombie.gameObject.SetActive(true);
        zombie.currentHealth = 1;
    }
    private void NewSpawn()   //spawn location of newZombie
    {
        if (zombieCounter < 11)
        {

            reSpawn = true;
            if (reSpawn)
            {
                int i = Random.Range(1, spawnPositions.Length);
                transform.position = spawnPositions[i].transform.position; 
                Instantiate(zombiePrefab, this.transform.position, this.transform.rotation, zombieArmy);
                Instantiate(zombiePrefab, this.transform.position, this.transform.rotation, zombieArmy);
               
            }
        }
    }

    void Update()
    {
        NewSpawn();
        zombieCounter = transform.parent.childCount;
    }
}