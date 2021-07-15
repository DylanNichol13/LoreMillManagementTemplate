using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace LoreMill
{
    [RequireComponent(typeof(EventTrigger))]
    public class SpriteTextButton : MonoBehaviour,
IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
    {
        #region Public Properties
        private Image targetImage;
        private Text targetText;
        private Button button;


        public Color normalColour;
        public Color pressedColour;
        #endregion
        //--------------------------------------------------------------------------------
        #region Private Properties
        bool tracking;
        bool selected;
        bool inBounds;
        #endregion
        //--------------------------------------------------------------------------------
        #region Interface Methods
        void Start()
        {
            targetImage = transform.GetChild(0).Find("MenuItemIcon").GetComponent<Image>();
            targetText = transform.GetChild(0).Find("MenuItemLabel").GetComponent<Text>();
            button = GetComponent<Button>();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            inBounds = true;
            UpdateStyle();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            inBounds = false;
            UpdateStyle();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            ClearOtherButtons();
            tracking = true;
            inBounds = true;
            UpdateStyle();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (selected && inBounds)
            {
                selected = false;
                Deselect();
            }
            else if (tracking && inBounds && button.onClick != null)
            {
                tracking = false;
                inBounds = false;
                selected = true;
                UpdateStyle();
            }
        }
        #endregion
        //--------------------------------------------------------------------------------
        #region Private Methods
        void Set(Color Colour, Color BGcolor)
        {
            targetImage.color = Colour;
            targetText.color = Colour;
            GetComponent<Image>().color = BGcolor;
        }
        void UpdateStyle()
        {
            if (!inBounds && !selected)
            {
                Set(normalColour, pressedColour);
            }
            else if (selected)
            {
                Set(pressedColour, normalColour);
            }
            else if (!selected)
            {
                Set(normalColour, pressedColour);
            }
        }

        public void ClearOtherButtons()
        {
            foreach (Transform t in transform.parent)
            {
                try
                {
                    if (t.gameObject != this.gameObject)
                    {
                        t.GetComponent<SpriteTextButton>().Deselect();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        private void Deselect()
        {
            selected = false;
            UpdateStyle();
        }
        #endregion
    }
}