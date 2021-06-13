using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LoreMill
{
    public class InboxItemObj : MonoBehaviour
    {
        public InboxItem InboxItem;

        private Button button;
        private Text titleText;
        private Text messageBoxText;

        private void Awake()
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(() => Select());

            transform.Find("BackgroundColour").GetComponent<Image>().color = UIStyleManager.GetInboxItemUnselected;
        }

        private void OnValidate()
        {
            try
            {
                UIStyleManager.instance.UpdateAllUIColours();
            }
            catch (Exception ex)
            {
                Debug.LogWarning("Unable to update colour. No UIStyleManager instance.");
            }
        }

        public void Select()
        {
            if (messageBoxText == null)
            {
                messageBoxText = GameObject.Find("MessageBox").transform.Find("TextBox").GetComponent<Text>();
            }
            messageBoxText.text = InboxItem.Text;

            InboxItemHandler.instance.SetNewSelectedItem(transform);
        }

        public void Setup(InboxItem item)
        {
            InboxItem = item;

            titleText = transform.Find("Title").GetComponent<Text>();

            titleText.text = InboxItem.Title;
        }
    }
}