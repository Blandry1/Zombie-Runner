using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayCycle : MonoBehaviour {

    [Tooltip ("The Minutes per Degree, standard is 60")]
    public float timeScale = 60;
  


    void Update()
    {
        float angleThisFrame = Time.deltaTime / 360 * timeScale;
        transform.RotateAround(transform.position, Vector3.forward, angleThisFrame); 
                //i.e. rotates around origin, on x-axis, by timeScale speed;
    }
}