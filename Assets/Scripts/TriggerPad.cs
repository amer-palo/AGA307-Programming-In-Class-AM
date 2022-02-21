using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPad : MonoBehaviour
{
    public GameObject sphereObj;
    public Color toColour;
    Color originalColour;


    private void Start()
    {
        originalColour = sphereObj.GetComponent<Renderer>().material.color;
        GetComponent<MeshRenderer>().enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            sphereObj.GetComponent<Renderer>().material.color = toColour;
        }    
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            sphereObj.transform.localScale += Vector3.one * 0.01f;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            sphereObj.GetComponent<Renderer>().material.color = originalColour;
            sphereObj.transform.localScale = Vector3.one;
        }
    }
}
