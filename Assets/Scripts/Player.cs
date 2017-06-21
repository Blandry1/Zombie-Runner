using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject landingAreaPrefab;   
    public Transform playerSpawnPoint;
    private bool reSpawn = false;
    private Transform[] spawnPoints;
    private bool lastToggle = false;
    

    void Start()
    {
        spawnPoints = playerSpawnPoint.GetComponentsInChildren<Transform>();
    }

    private void ReSpawn()
    {
        int i = Random.Range(1, spawnPoints.Length);
        transform.position = spawnPoints[i].transform.position; //players position = spawnPoint position

    }
    void Update() //T-toggle
    {
        if (reSpawn != lastToggle)
        {
            ReSpawn();
            reSpawn = false;
        }
        else
            lastToggle = reSpawn;
    }

    void OnFindClearArea()
    {
        Invoke("DropFlare", 3f);
        //deploy zombies, throw flare
    }

    void DropFlare()
    {
        Instantiate(landingAreaPrefab, transform.position, transform.rotation);
    }
    
}
