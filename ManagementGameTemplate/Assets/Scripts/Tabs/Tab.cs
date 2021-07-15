using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LoreMill
{
    public class Tab : MonoBehaviour
    {
        public TabType TabType;
        public Button NavBarButton;

        private void OnValidate()
        {
            TabHandler.TabList.Remove(this);
            TabHandler.TabList.Add(this);

            if (NavBarButton != null)
            {
                NavBarButton.onClick.RemoveAllListeners();
                NavBarButton.onClick.AddListener(() => ChangeTab());
                NavBarButton.onClick.AddListener(() => TabBehaviour());
            }
        }

        private void TabBehaviour()
        {
            switch (TabType)
            {
                case TabType.Inbox:
                    //Clear selected navbar style when selected a news item 
                    NavBarButton.GetComponent<SpriteTextButton>().ClearOtherButtons();
                    break;
                case TabType.Profile:
                    ProfileHandler.instance.SetupProfile();
                    break;
                case TabType.Finance:

                    break;
                case TabType.Log:
                    LogHandler.instance.SetupLog();
                    break;
            }
        }

        public void ChangeTab()
        {
            TabHandler.instance.SwitchTab(this);
        }
    }
}