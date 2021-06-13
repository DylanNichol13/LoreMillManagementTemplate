using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LoreMill
{
    public class InboxData : MonoBehaviour
    {
        public static InboxData instance;
        public List<InboxItem> InboxItemData = new List<InboxItem>();

        private void Awake()
        {
            instance = this;
        }

        private void Start()
        {
            InboxItemData.Add(new InboxItem("Lorem ipsum dolor sit amet",
                "Ut in eros eu velit eleifend varius ut nec sapien. In venenatis egestas dolor pellentesque porttitor. Morbi condimentum sem ac suscipit auctor.\n\n Mauris consequat nibh vulputate risus viverra dapibus. Aenean ultrices posuere justo sed accumsan. Integer est urna, aliquam vel lorem eget, porta malesuada sapien. Vivamus tempor lorem vel dolor vestibulum sollicitudin.\n\nMaecenas interdum cursus tincidunt.Morbi ornare ligula felis, sed rutrum purus ornare ut.Quisque vulputate euismod finibus.Nam mauris mi, dignissim ac ex at, dictum pretium mauris.Mauris vel orci vulputate, placerat velit vitae, pulvinar erat.Mauris consequat, ante eget sagittis vehicula, risus ante sagittis augue, et malesuada dui ante a felis."));
            InboxItemData.Add(new InboxItem("Ut in eros eu velit eleifend varius ut nec sapien", "Vestibulum et nibh nec massa dignissim dictum. Duis pretium nunc eget commodo eleifend. Etiam at neque justo. Phasellus tincidunt vulputate nibh, sit amet dictum lorem dignissim ut.\n\n Morbi luctus turpis eget ipsum varius, vel gravida urna pulvinar. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Phasellus ut lacus dignissim, laoreet dolor ut, ullamcorper ligula.\n\n Curabitur vel ante rutrum, gravida metus vel, molestie nisl. Pellentesque dui augue, mattis eu hendrerit a, ornare sit amet nisi."));
        }
    }
}