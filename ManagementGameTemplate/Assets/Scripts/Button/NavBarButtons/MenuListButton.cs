using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LoreMill
{
    public class MenuListButton : MonoBehaviour
    {
        public string Label;
        public Sprite Icon;

        const UIColorType uIColorType = UIColorType.ButtonUnSelected;

        private void OnValidate()
        {
            ResetColours();
        }

        //Reset all colours on reload of unity 
        public void ResetColours()
        {
            //Get colours from UIStyleManager.cs
            transform.GetComponent<Image>().color = UIStyleManager.GetButtonUnSelected;
            transform.GetChild(0).Find("MenuItemLabel").GetComponent<Text>().color = UIStyleManager.GetTextButtonUnselected;
            transform.GetChild(0).Find("MenuItemIcon").GetComponent<Image>().color = UIStyleManager.GetTextButtonUnselected;
            //Set Icon and label
            transform.GetChild(0).Find("MenuItemIcon").GetComponent<Image>().sprite = Icon;
            transform.GetChild(0).Find("MenuItemLabel").GetComponent<Text>().text = Label;
            //Set spriteTextButton assets - allows image icon alongside text to be recoloured
            var spriteTextBtn = GetComponent<SpriteTextButton>();
            spriteTextBtn.normalColour = UIStyleManager.GetButtonUnSelected;
            spriteTextBtn.pressedColour = UIStyleManager.GetTextButtonSelected;
        }
    }
}