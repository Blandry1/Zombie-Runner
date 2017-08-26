using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallHeli : MonoBehaviour
{

    private Rigidbody rigidBody;
    public Transform landingDestination;
    private Vector3 descend = new Vector3(0, 100, 0);
    private bool HeliInMap = false;
    private bool arrived = false;

    // Use this for initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    public void OnDispatchHeliCopter()
    {
        rigidBody.velocity = new Vector3(0, 0, 100f);
        Debug.Log("roger, on my way");
        }

    private void Update()
    {
        if (rigidBody.transform.position.z >= 0 && !HeliInMap && !arrived)
        {
            rigidBody.transform.position = landingDestination.transform.position + descend;
            rigidBody.velocity = new Vector3(0, 0, 0);
            HeliInMap = true;
        }
        if (HeliInMap && !arrived)
        {
            transform.Translate(5 * Vector3.down * Time.deltaTime, Space.World);

            if (rigidBody.transform.position.y < 30)
            {
                arrived = true;
                rigidBody.velocity = new Vector3(0, 0, 0);
                rigidBody.transform.position = landingDestination.transform.position;
            }
        }

    }
}