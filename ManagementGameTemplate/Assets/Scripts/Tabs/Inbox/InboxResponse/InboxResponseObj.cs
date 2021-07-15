using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InboxResponseObj : MonoBehaviour
{
    public InboxResponse inboxResponse;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(() => SelectResponse());
    }

    public void Init(InboxResponse inboxResponse)
    {
        this.inboxResponse = inboxResponse;
    }

    public void SelectResponse()
    {
        InboxResponseHandler.instance.HandleResponse(inboxResponse);
    }
}
