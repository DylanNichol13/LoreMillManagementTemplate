using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LoreMill
{
    public class UIStyleManager : MonoBehaviour
    {
        public static UIStyleManager instance;
        [Header("Main UI Colours")]
        public Color PrimaryColour;
        public Color SecondaryColour;
        public Color AccentColour;
        [Header("Nav bar buttons background colour")]
        public Color ButtonUnSelected;
        public Color ButtonSelected;
        [Header("Nav bar buttons text colour")]
        public Color TextButtonUnselected;
        public Color TextButtonSelected;
        [Header("Special buttons such as end turn")]
        public Color ButtonSpecial;
        public Color ButtonSpecialText;
        [Header("Buttons for inbox items in the inbox tab")]
        public Color InboxItemUnselected;
        public Color InboxItemSelected;

        public static Color GetPrimaryColour;
        public static Color GetSecondaryColour;
        public static Color GetAccentColour;
        public static Color GetButtonUnSelected;
        public static Color GetButtonSelected;
        public static Color GetButtonSpecial;
        public static Color GetButtonSpecialText;
        public static Color GetTextButtonUnselected;
        public static Color GetTextButtonSelected;
        public static Color GetInboxItemUnselected;
        public static Color GetInboxItemSelected;

        private Transform MasterCanvas;

        private void OnValidate()
        {
            if (instance == null) instance = this;

            UpdateAllUIColours();

            UIStyleManager.GetPrimaryColour = PrimaryColour;
            UIStyleManager.GetSecondaryColour = SecondaryColour;
            UIStyleManager.GetAccentColour = AccentColour;
            UIStyleManager.GetButtonUnSelected = ButtonUnSelected;
            UIStyleManager.GetButtonSelected = ButtonSelected;
            UIStyleManager.GetButtonSpecial = ButtonSpecial;
            UIStyleManager.GetButtonSpecialText = ButtonSpecialText;
            UIStyleManager.GetTextButtonUnselected = TextButtonUnselected;
            UIStyleManager.GetTextButtonSelected = TextButtonSelected;
            UIStyleManager.GetInboxItemUnselected = InboxItemUnselected;
            UIStyleManager.GetInboxItemSelected = InboxItemSelected;
        }

        //Updates all current UI colours
        public void UpdateAllUIColours()
        {
            MasterCanvas = GameObject.Find("MasterCanvas").transform;
            var UIImages = MasterCanvas.transform.GetComponentsInChildren<UIColour>();
            var UIListButtons = MasterCanvas.transform.GetComponentsInChildren<MenuListButton>();
            var SpriteTextButtons = GameObject.FindGameObjectsWithTag("LeftNavBarButton");

            foreach (UIColour c in UIImages)
            {
                c.GetComponent<Image>().color = GetColorFromUIColor(c.UIColorType);
            }

            foreach (MenuListButton m in UIListButtons)
            {
                m.ResetColours();
            }

            foreach (GameObject g in GameObject.FindGameObjectsWithTag("ButtonSpecial"))
            {
                g.GetComponent<Image>().color = ButtonSpecial;
                g.transform.Find("Label").GetComponent<Text>().color = ButtonSpecialText;
            }

            foreach (GameObject g in GameObject.FindGameObjectsWithTag("TabBackground"))
            {
                var uiColourType = g.GetComponent<UIColour>().UIColorType;
                g.GetComponent<Image>().color = GetColorFromUIColor(uiColourType);
            }

            foreach (GameObject g in GameObject.FindGameObjectsWithTag("InboxItem"))
            {
                g.transform.Find("BackgroundColour").GetComponent<Image>().color = InboxItemUnselected;
            }

            foreach (GameObject g in SpriteTextButtons)
            {
                g.GetComponent<SpriteTextButton>().normalColour = GetButtonSelected;
                g.GetComponent<SpriteTextButton>().pressedColour = GetButtonUnSelected;
            }
        }
        //Gets a colour and returns form the UIColorType enum
        private Color GetColorFromUIColor(UIColorType type)
        {
            switch (type)
            {
                case UIColorType.Accent:
                    return AccentColour;
                case UIColorType.Primary:
                    return PrimaryColour;
                case UIColorType.Secondary:
                    return SecondaryColour;
                case UIColorType.ButtonUnSelected:
                    return GetButtonUnSelected;
                case UIColorType.ButtonSelected:
                    return GetButtonSelected;
                case UIColorType.ButtonSpecial:
                    return GetButtonSpecial;
                case UIColorType.TextButtonUnselected:
                    return GetTextButtonUnselected;
                case UIColorType.TextButtonSelected:
                    return GetTextButtonSelected;
                default:
                    return Color.green;
            }
        }
    }
}
