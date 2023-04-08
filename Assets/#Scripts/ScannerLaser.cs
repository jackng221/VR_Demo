using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScannerLaser : MonoBehaviour
{
    Book book;
    public float defaultWaitSeconds = 1.5f;
    [SerializeField] float waitSeconds;

    [SerializeField] UnityEvent<int> RegisterBookEvent;

    private void Start()
    {
        waitSeconds = defaultWaitSeconds;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<Book>() == null) { return; }

        book = other.gameObject.GetComponent<Book>();
        if (book.BarcodeLeft.GetComponent<BarcodeTrigger>().IsTriggered & book.BarcodeRight.GetComponent<BarcodeTrigger>().IsTriggered)
        {
            waitSeconds -= Time.deltaTime;
            if (waitSeconds < 0f)
            {
                RegisterBookEvent.Invoke(book.BookID);
                waitSeconds = 9999;
            }
        }
        else
        {
            waitSeconds = defaultWaitSeconds;
        }
    }
}
