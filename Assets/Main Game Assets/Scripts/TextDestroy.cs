using UnityEngine;
using System.Collections;

public class TextDestroy : MonoBehaviour
{
    float time = 10f; //Seconds to read the text

    void Start()
    {
        Invoke("Hide", time);
    }

    void Hide()
    {
        Destroy(gameObject);
    }

}