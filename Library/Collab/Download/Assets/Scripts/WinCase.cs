using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCase : MonoBehaviour {


    private LevelManager levelManager;          //fixed the new constructor instantiation by AddComponent
    
    void Start () {
        levelManager = gameObject.AddComponent<LevelManager>(); 
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Time.timeSinceLevelLoad > 120)
        {
            
            Debug.Log("leavingGameNow");
            levelManager.LoadByIndex(0);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
