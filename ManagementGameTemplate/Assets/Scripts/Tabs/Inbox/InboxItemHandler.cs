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

        private void Awake()
        {
            instance = this;
        }

        public void SetupInbox()
        {
            foreach (Transform t in InboxItemContainer.transform)
                Destroy(t.gameObject);

            foreach (InboxItem i in InboxData.instance.InboxItemData)
            {
                var obj = MenuItemHandler.CreateUIInboxItem();
                obj.transform.SetParent(InboxItemContainer);

                obj.GetComponent<InboxItemObj>().Setup(i);
            }
        }

        public void SetNewSelectedItem(Transform selected)
        {
            foreach (Transform t in InboxItemContainer)
            {
                if (t == selected)
                {
                    SetNewsItemBGColour(t, UIStyleManager.GetInboxItemSelected);
                }
                else
                {
                    SetNewsItemBGColour(t, UIStyleManager.GetInboxItemUnselected);
                }
            }
        }

        private void SetNewsItemBGColour(Transform t, Color color)
        {
            t.Find("BackgroundColour").GetComponent<Image>().color = color;
        }
    }
}