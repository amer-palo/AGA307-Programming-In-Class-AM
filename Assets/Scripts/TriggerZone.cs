using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Eneterd");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (PlayerDetected(other))
        {
            Debug.Log("Staying");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (PlayerDetected(other))
        {
            Debug.Log("Exited");
        }
    }

    bool PlayerDetected(Collider _other)
    {
        return _other.CompareTag("Player");
    }
}
