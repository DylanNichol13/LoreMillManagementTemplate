using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace LoreMill
{
    public class MenuItemHandler : MonoBehaviour
    {
        [MenuItem("GameObject/UI/ManagementAssets/PrimaryBackground")]
        private static void CreateUIBackgroundImagePrimary()
        {
            //Create
            var obj = new GameObject("PrimaryBackground");
            var image = obj.AddComponent<Image>();
            var uiColour = obj.AddComponent<UIColour>();
            uiColour.UIColorType = UIColorType.Primary;
            //Set parent and positional details
            obj.transform.SetParent(Selection.activeTransform);
            obj.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
            //Set colour
            image.color = UIStyleManager.GetPrimaryColour;
            //Set to active in hierarchy
            Selection.activeTransform = obj.transform;
        }

        [MenuItem("GameObject/UI/ManagementAssets/SecondaryBackground")]
        private static void CreateUIBackgroundImageSecondary()
        {
            //Create
            var obj = new GameObject("SecondaryBackground");
            var image = obj.AddComponent<Image>();
            var uiColour = obj.AddComponent<UIColour>();
            uiColour.UIColorType = UIColorType.Secondary;
            //Set parent and positional details
            obj.transform.SetParent(Selection.activeTransform);
            obj.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
            //Set colour
            image.color = UIStyleManager.GetSecondaryColour;
            //Set to active in hierarchy
            Selection.activeTransform = obj.transform;
        }

        [MenuItem("GameObject/UI/ManagementAssets/AccentBackground")]
        private static void CreateUIBackgroundImageAccent()
        {
            //Create
            var obj = new GameObject("AccentBackground");
            var image = obj.AddComponent<Image>();
            var uiColour = obj.AddComponent<UIColour>();
            uiColour.UIColorType = UIColorType.Accent;
            //Set parent and positional details
            obj.transform.SetParent(Selection.activeTransform);
            obj.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
            //Set colour
            image.color = UIStyleManager.GetAccentColour;
            //Set to active in hierarchy
            Selection.activeTransform = obj.transform;
        }

        [MenuItem("GameObject/UI/ManagementAssets/Special Button - Continue")]
        private static void CreateUISpecialButtonContinue()
        {
            //Create
            var obj = Instantiate(Resources.Load<GameObject>("LoreMill/ManagementUI/SpecialButton-Continue"));
            //Set parent and positional details
            obj.transform.SetParent(Selection.activeTransform);
            obj.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
            obj.name = "SpecialButton-Continue";
            //Set to active in hierarchy
            Selection.activeTransform = obj.transform;
        }

        [MenuItem("GameObject/UI/ManagementAssets/NavBar/Nav Bar Button")]
        public static GameObject CreateUINavBarItemButton()
        {
            //Create
            var obj = Instantiate(Resources.Load<GameObject>("LoreMill/ManagementUI/NavBar/MenuItemButton"));
            //Set parent and positional details
            obj.transform.SetParent(Selection.activeTransform);
            obj.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
            obj.name = "NavBarButton";
            //Set to active in hierarchy
            Selection.activeTransform = obj.transform;

            return obj;
        }


        [MenuItem("GameObject/UI/ManagementAssets/Inbox Item")]
        public static GameObject CreateUIInboxItem()
        {
            //Create
            var obj = Instantiate(Resources.Load<GameObject>("LoreMill/ManagementUI/Inbox/InboxItem"));
            //Set parent and positional details
            obj.transform.SetParent(Selection.activeTransform);
            obj.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
            obj.name = "InboxItem";
            obj.GetComponent<InboxItemObj>().InboxItem = new InboxItem("Inbox item title", "This is a new inbox item, set up some nice text here!");
            //Set to active in hierarchy
            Selection.activeTransform = obj.transform;

            return obj;
        }

        /// Sorter items
        /// Sorter UI items used to arrange, and provide stretching of UI items dimensions

        [MenuItem("GameObject/UI/ManagementAssets/Sorters/Vertical Sorter")]
        public static GameObject CreateUIVertSorter()
        {
            //Create
            var obj = Instantiate(Resources.Load<GameObject>("LoreMill/ManagementUI/Sorters/VertSorter"));
            var rect = obj.GetComponent<RectTransform>();
            //Set parent and positional details
            obj.transform.SetParent(Selection.activeTransform);
            rect.localPosition = new Vector3(0, 0, 0);
            obj.name = "VertSorter";
            //Set to active in hierarchy
            Selection.activeTransform = obj.transform;
            //Stetch
            rect.offsetMin = Vector2.zero;
            rect.offsetMax = Vector2.zero;

            return obj;
        }
        [MenuItem("GameObject/UI/ManagementAssets/Sorters/Horizontal Sorter")]
        public static GameObject CreateUIHorizSorter()
        {
            //Create
            var obj = Instantiate(Resources.Load<GameObject>("LoreMill/ManagementUI/Sorters/HorizSorter"));
            var rect = obj.GetComponent<RectTransform>();
            //Set parent and positional details
            obj.transform.SetParent(Selection.activeTransform);
            rect.localPosition = new Vector3(0, 0, 0);
            obj.name = "HorizSorter";
            //Set to active in hierarchy
            Selection.activeTransform = obj.transform;
            //Stetch
            rect.offsetMin = Vector2.zero;
            rect.offsetMax = Vector2.zero;

            return obj;
        }
    }
}