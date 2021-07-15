using LoreMill;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InboxResponseHandler : MonoBehaviour
{
    public static InboxResponseHandler instance;
    private Transform _inboxActionBar;
    private Transform _inboxBinaryActionBar;

    private void Awake()
    {
        instance = this;
        _inboxActionBar = GameObject.Find("ActionsBar").transform;
        _inboxBinaryActionBar = GameObject.Find("BinaryActionBar").transform;
    }

    public void HandleResponse(InboxResponse selectedResponse)
    {
        //Write to log
        LogHandler.instance.GetLog().WriteToLog($"{InboxItemHandler.instance.SelectedInboxItem.Text}\nResponse: {selectedResponse.ResponseText}");

        InboxItemHandler.instance.ClearInboxItem();
    }

    public void HandleResponse()
    {
        //Write to log
        LogHandler.instance.GetLog().WriteToLog($"{InboxItemHandler.instance.SelectedInboxItem.Text}");

        InboxItemHandler.instance.ClearInboxItem();
    }

    public void HideResponses()
    {
        _inboxActionBar.gameObject.SetActive(false);
        _inboxBinaryActionBar.gameObject.SetActive(true);
    }

    public void ShowResponses(List<InboxResponse> inboxResponses)
    { 
        _inboxActionBar.gameObject.SetActive(true);
        _inboxBinaryActionBar.gameObject.SetActive(false);

        for (int i = 0; i < _inboxActionBar.GetChild(0).childCount; i++)
        {
            _inboxActionBar.GetChild(0).GetChild(i).GetChild(0).GetComponent<Text>().text = inboxResponses[i].ResponseText;
            _inboxActionBar.GetChild(0).GetChild(i).GetComponent<InboxResponseObj>().Init(inboxResponses[i]);
        }
    }
}
