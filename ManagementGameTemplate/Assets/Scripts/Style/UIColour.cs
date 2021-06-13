using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace LoreMill
{
    public class UIColour : MonoBehaviour
    {
        //Allows UI colours to be set from the UIStyleManager.cs
        public UIColorType UIColorType;

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
    }
}