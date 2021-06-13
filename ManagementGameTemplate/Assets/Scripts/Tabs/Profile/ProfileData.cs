using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LoreMill
{
    public class ProfileData : MonoBehaviour
    {
        public static ProfileData instance;
        private Profile profile;
        public Profile GetProfile() { return profile; }
        // Start is called before the first frame update
        void Start()
        {
            instance = this;
            SetupDevProfile();
        }

        private void SetupDevProfile()
        {
            profile = new Profile("Stu", "Helmet", new DateTime(1975, 10, 05));
        }
    }
}