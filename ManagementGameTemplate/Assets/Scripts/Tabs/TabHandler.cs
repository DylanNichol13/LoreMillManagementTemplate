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

        private void Start()
        {
            instance = this;

            SwitchTab(TabList.Last());
        }

        public void SwitchTab(Tab tab)
        {
            try
            {
                foreach (Transform t in TabsElement.transform.Find("TabContainer").transform)
                {
                    if (t == tab.transform)
                    {
                        t.gameObject.SetActive(true);
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