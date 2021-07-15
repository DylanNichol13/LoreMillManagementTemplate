using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LoreMill
{
    public class InboxItemHandler : MonoBehaviour
    {
        public static InboxItemHandler instance;

        public Transform InboxItemContainer;
        public Transform SelectedInboxItemTrans;
        public InboxItem SelectedInboxItem;

        private bool _inboxInitialised = false;
        private Button _hiddenInboxOpenButton;

        private void Awake()
        {
            instance = this;
            _hiddenInboxOpenButton = GameObject.Find("InboxButton").GetComponent<Button>();
        }

        private void Update()
        {
            if(!_inboxInitialised && InboxData.instance != null)
            {
                _inboxInitialised = true;
            }
        }

        public void SetupInbox(List<InboxItem> renderInboxList)
        {
            foreach (Transform t in InboxItemContainer.transform)
                Destroy(t.gameObject);

            foreach (InboxItem i in renderInboxList)
            {
                var obj = MenuItemHandler.CreateUIInboxItem();
                obj.transform.SetParent(InboxItemContainer);

                obj.GetComponent<InboxItemObj>().Setup(i);
            }
        }

        public void ClearInboxItem()
        {
            InboxData.instance.RemoveData(SelectedInboxItemTrans.GetComponent<InboxItemObj>().InboxItem);

            Destroy(SelectedInboxItemTrans.gameObject);
            _hiddenInboxOpenButton.onClick.Invoke();
            SelectedInboxItemTrans = null;

            InboxData.instance.RefreshInbox();
        }

        public void SetNewSelectedItem(Transform selected, InboxItem selectedInboxItem)
        {
            if(SelectedInboxItemTrans == null || SelectedInboxItemTrans != selected)
            {
                SelectedInboxItemTrans = selected;
                SelectedInboxItem = selectedInboxItem;
            }
            else
            {
                SelectedInboxItemTrans = null;
                SelectedInboxItem = null;
            }
            foreach (Transform t in InboxItemContainer)
            {
                if (SelectedInboxItemTrans != null && t == selected)
                {
                    SetNewsItemBGColour(t, UIStyleManager.GetInboxItemSelected);
                }
                else
                {
                    SetNewsItemBGColour(t, UIStyleManager.GetInboxItemUnselected);
                }
            }
        }

        public bool IsSelectedItemClicked(Transform transform)
        {
            return SelectedInboxItemTrans == null ? true : transform == SelectedInboxItemTrans;
        }

        private void SetNewsItemBGColour(Transform t, Color color)
        {
            t.Find("BackgroundColour").GetComponent<Image>().color = color;
        }
    }
}