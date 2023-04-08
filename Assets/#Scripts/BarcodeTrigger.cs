using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarcodeTrigger : MonoBehaviour
{
    [SerializeField] bool isTriggered = false;
    public bool IsTriggered { get { return isTriggered; } }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ScannerLaser"))
        {
            isTriggered = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        isTriggered = false;
    }
}
