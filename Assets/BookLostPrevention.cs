using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookLostPrevention : MonoBehaviour
{
    [SerializeField] Transform teleportPoint;

    private void OnTriggerStay(Collider other)
    {
        other.gameObject.transform.root.position = teleportPoint.position;
    }
}
