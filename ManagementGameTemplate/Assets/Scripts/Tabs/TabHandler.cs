using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace LoreMill
{
    public class TabHandler : MonoBehaviour
    {
        public static List<Tab> TabList = new List<Tab>();
        public static TabHandler instance;

        public GameObject TabsElement;

        private Tab _currentTab;

        private void Start()
        {
            instance = this;
            CloseAllTabs();
        }

        public void CloseAllTabs()
        {
            try
            {
                _currentTab = null;
                foreach (Transform t in TabsElement.transform.Find("TabContainer").transform)
                {
                    t.gameObject.SetActive(false);
                }
            }
            catch (Exception ex)
            {
                Debug.LogError($"Failed on closing tabs : {ex.Message}");
            }
        }

        public void SwitchTab(Tab tab)
        {
            try
            {
                if(tab == _currentTab)
                {
                    CloseAllTabs();
                    return;
                }

                foreach (Transform t in TabsElement.transform.Find("TabContainer").transform)
                {
                    if (t == tab.transform)
                    {
                        t.gameObject.SetActive(true);
                        _currentTab = tab;
                    }
                    else
                    {
                        t.gameObject.SetActive(false);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.LogError($"Failed on switching tab : {ex.Message}");
            }
        }
    }
}