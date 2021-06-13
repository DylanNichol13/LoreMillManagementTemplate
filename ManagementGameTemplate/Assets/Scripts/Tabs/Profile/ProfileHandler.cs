using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LoreMill
{
    public class ProfileHandler : MonoBehaviour
    {
        public static ProfileHandler instance;

        private void Start()
        {
            instance = this;
        }

        public void SetupProfile()
        {
            foreach (GameObject g in GameObject.FindGameObjectsWithTag("ProfileElement"))
            {
                switch (g.GetComponent<ProfileElement>().ProfileElementType)
                {
                    case ProfileElementType.Name:
                        g.GetComponent<Text>().text = ProfileData.instance.GetProfile().GetFullName();
                        break;
                    case ProfileElementType.DobAge:
                        g.GetComponent<Text>().text = ProfileData.instance.GetProfile().GetDobAge();
                        break;
                    case ProfileElementType.ProfileImage:

                        break;
                }
            }
        }
    }
}