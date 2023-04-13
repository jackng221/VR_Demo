using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour
{
    [SerializeField] int bookID;
    [SerializeField] GameObject barcodeLeft;
    [SerializeField] GameObject barcodeRight;

    public int BookID { get { return bookID; } }
    public GameObject BarcodeLeft { get {  return barcodeLeft; } }
    public GameObject BarcodeRight { get {  return barcodeRight; } }
}
