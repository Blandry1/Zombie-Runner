using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public GameObject landingAreaPrefab;   
    public Transform playerSpawnPoint;
    private Transform[] spawnPoints;
    private bool reSpawn = false;
    private bool lastToggle = false;

    public RaycastHit hit;
    public int gunDamage = 1;
    public Zombie zombie;
    public Camera fpsCamera;
    public int weaponRange = 50;
    private int layerMask = 1 << 9;

    private float hitForce = 100f;
    public float playerLife;
    public FadeAlpha[] fades;
    public FadeAlpha fade;


    //A Singleton function that selects the in-game active scene Player.
    private static Player _instance; 
    public static Player Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<Player>();
            }
            return _instance;
        }
    }

    void Start()
    {
        spawnPoints = playerSpawnPoint.GetComponentsInChildren<Transform>();
        fades = FindObjectsOfType<FadeAlpha>();
        playerLife = 100;
    }

    private void ReSpawn()
    {
        int i = Random.Range(1, spawnPoints.Length);
        transform.position = spawnPoints[i].transform.position; //players position = spawnPoint position
    }

    void LazerBeam()
    {
        Vector3 rayOrigin = fpsCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0f));
        //Debug.DrawRay(rayOrigin, Vector3.forward * weaponRange, Color.green, duration);
        
        if (Physics.Raycast(rayOrigin, fpsCamera.transform.forward, out hit, weaponRange, layerMask))
        {
            Zombie zombieHit = hit.transform.gameObject.GetComponent<Zombie>();
            //  Debug.Log(name + " " + zombieHit);

            if (zombieHit != null) //damages zombie
            {
                zombieHit.Damage(gunDamage);
            }

            if (hit.rigidbody != null) //pushes back zombie
            {
                hit.rigidbody.AddForce(-hit.normal * hitForce);
            }

        }
        Debug.Log(hit.collider);
    }

    void Update() //T-toggle
    {
       // playerLife -= 1;  //TODO: remove later

        if (Input.GetButton("Fire1"))
        {
            LazerBeam();
        }
        
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

    public void Life (float damage)
    {
        this.playerLife -= damage;

        if (damage > 0)
        {
            fadeInBlood();
            Invoke("fadeOutBlood", 0.5f);
        }

        if (playerLife <=0)
        {
            playerLife = 100;
            SceneManager.LoadScene(2);
        }
    }

    private void fadeInBlood()
    {
        foreach (FadeAlpha fade in fades)
        {
            fade.FadeIn();
        }
    }
    private void fadeOutBlood()
    {
        foreach (FadeAlpha fade in fades)
        {
            fade.FadeOut();
        }
    }
    
}
