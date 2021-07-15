using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LoreMill
{
    public class InboxItem
    {
        public string Title;
        public string Text;
        public List<InboxResponse> InboxItemResponses;

        private DateTime _timeCreated;
        public DateTime GetTimeCreated() { return _timeCreated; }

        public InboxItem(string title, string text)
        {
            this.Title = title;
            this.Text = text;
            InboxItemResponses = new List<InboxResponse>();
            this._timeCreated = DateTime.UtcNow;
        }

        public InboxItem(string title, string text, List<InboxResponse> inboxResponses)
        {
            this.Title = title;
            this.Text = text;
            this.InboxItemResponses = inboxResponses;
            this._timeCreated = DateTime.UtcNow;
        }
    }
}