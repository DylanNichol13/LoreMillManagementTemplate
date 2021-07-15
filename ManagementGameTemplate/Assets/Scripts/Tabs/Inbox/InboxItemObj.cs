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

        private Button _hiddenInboxOpenButton;
        private Button _button;
        private Text _titleText;
        private Text _messageBoxText;
        private Text _messageBoxHeader;

        private void Awake()
        {
            _button = GetComponent<Button>();

            transform.Find("BackgroundColour").GetComponent<Image>().color = UIStyleManager.GetInboxItemUnselected;
            _hiddenInboxOpenButton = GameObject.Find("InboxButton").GetComponent<Button>();
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
            if(InboxItemHandler.instance.IsSelectedItemClicked(transform))
                _hiddenInboxOpenButton.onClick.Invoke();

            if (_messageBoxText == null)
            {
                _messageBoxText = GameObject.Find("InboxItemBody").transform.Find("Text").GetComponent<Text>();
                _messageBoxHeader = GameObject.Find("InboxItemHeader").GetComponent<Text>();
            }
            _messageBoxText.text = InboxItem.Text;
            _messageBoxHeader.text = InboxItem.Title;

            if(InboxItem.InboxItemResponses.Count < 1)
            {
                InboxResponseHandler.instance.HideResponses();
            }
            else
            {
                InboxResponseHandler.instance.ShowResponses(InboxItem.InboxItemResponses);
            }

            InboxItemHandler.instance.SetNewSelectedItem(transform, InboxItem);
        }

        public void Setup(InboxItem item)
        {
            InboxItem = item;

            _titleText = transform.Find("Title").GetComponent<Text>();

            _titleText.text = InboxItem.Title;
        }
    }
}