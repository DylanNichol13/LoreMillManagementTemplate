using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LoreMill
{
    public class InboxItem : MonoBehaviour
    {
        public string Title;
        public string Text;

        public InboxItem(string title, string text)
        {
            this.Title = title;
            this.Text = text;
        }
    }
}