using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Scanner : MonoBehaviour
{
    [SerializeField] GameObject Menu;
    [SerializeField] GameObject ConfirmScreen;
    [SerializeField] TextMeshProUGUI bookListText;
    List<int> registeredBookList = new List<int>();
    float confirmScreenWaitSeconds = 3f;

    public void RegisterBook(int BookID)
    {
        if (registeredBookList.Contains(BookID)) { return; }
        bookListText.text += BookID + "\n";
        registeredBookList.Add(BookID);
    }
    public void CompleteBooking()
    {
        bookListText.text = "";
        registeredBookList.Clear();
        StartCoroutine(ShowConfirmScreen());
    }
    IEnumerator ShowConfirmScreen()
    {
        Menu.SetActive(false);
        ConfirmScreen.SetActive(true);
        yield return new WaitForSeconds(confirmScreenWaitSeconds);
        Menu.SetActive(true);
        ConfirmScreen.SetActive(false);
    }
}
