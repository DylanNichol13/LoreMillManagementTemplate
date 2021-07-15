using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace LoreMill
{
    public class InboxData : MonoBehaviour
    {
        public static InboxData instance;
        public List<InboxItem> InboxItemData = new List<InboxItem>();

        private List<InboxItem> _renderInboxList = new List<InboxItem>();

        private void Awake()
        {
            instance = this;
        }

        private void Start()
        {
            AddTestData(2);
        }

        private void AddNewInboxItem(InboxItem item)
        {
            InboxItemData.Add(item);

            //Refresh
            RefreshInbox();
        }

        private void AddTestData(int v)
        {
            for(int i = 0; i < v; i++) {
                AddNewInboxItem(new InboxItem($"Random message {InboxItemData.Count}", $"This is a new message, number {InboxItemData.Count}"));
                AddNewInboxItem(new InboxItem($"Random message {InboxItemData.Count}", $"This is a new message, number {InboxItemData.Count}", new List<InboxResponse>
                {
                    new InboxResponse("Response one"),
                    new InboxResponse("Response two")
                }));
            }
        }


        public void Test_AddData()
        {
            AddTestData(Random.Range(1, 4));
        }

        public void RefreshInbox()
        {
            _renderInboxList = InboxItemData.OrderBy(x => x.GetTimeCreated()).Take(6).Reverse().ToList();

            InboxItemHandler.instance.SetupInbox(_renderInboxList);
        }

        public void RemoveData(InboxItem data)
        {
            InboxItemData.Remove(data);
        } 
    }
}