using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandingAreaDetector : MonoBehaviour {

    private bool called = false;
    public float timeSinceLastTrigger = 0f;

    private void OnTriggerStay(Collider collider)
    {
        if (collider.tag != "Player")
             timeSinceLastTrigger = 0f;       
        }


        // Update is called once per frame
        void Update () {
        timeSinceLastTrigger += Time.deltaTime;

        if ((timeSinceLastTrigger) > 1f && (Time.realtimeSinceStartup > 15f) && !called)
        {
            called = true;
            SendMessageUpwards("OnFindClearArea");
        }
    }
}
