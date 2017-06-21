using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{

    public GameObject zombiePrefab;
    public Transform zombieArmy;
    public Transform zombieSpawnPoint;
    private Transform[] spawnPositions;
    public int zombieCounter;

    private bool reSpawn = false;
   // private bool lastToggle = false;

    // Use this for initialization
    void Start()
    {
        spawnPositions = zombieSpawnPoint.GetComponentsInChildren<Transform>();
        InvokeRepeating("NewSpawn", 5f, 5f);
    }

    private void NewSpawn()   //spawn location of newZombie
    {
        reSpawn = true;
        if (reSpawn)
        {
            int i = Random.Range(1, spawnPositions.Length);
            transform.position = spawnPositions[i].transform.position;
            Instantiate(zombiePrefab, this.transform.position, this.transform.rotation, zombieArmy);
            Instantiate(zombiePrefab, this.transform.position, this.transform.rotation, zombieArmy);
            Instantiate(zombiePrefab, this.transform.position, this.transform.rotation, zombieArmy);
            Instantiate(zombiePrefab, this.transform.position, this.transform.rotation, zombieArmy);
            Instantiate(zombiePrefab, this.transform.position, this.transform.rotation, zombieArmy);
        }
    }


    void Update()
    {
        zombieCounter = transform.parent.childCount;
        //T-toggle

        //       if (reSpawn != lastToggle)
        //       {
        //           NewSpawn();
        //           reSpawn = false;
        //       }
        //       else
        //           lastToggle = reSpawn;
        //}
    }
}
