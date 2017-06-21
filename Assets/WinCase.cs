using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCase : MonoBehaviour {


    private LevelManager levelManager = new LevelManager();
    // Use this for initialization
    void Start () {
		
	}

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player" && Time.time > 120)
        {
            
            Debug.Log("leavingGameNow");
            levelManager.LoadByIndex(0);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
