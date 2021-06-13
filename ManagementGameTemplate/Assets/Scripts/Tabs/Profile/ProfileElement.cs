using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LoreMill
{
    public class ProfileElement : MonoBehaviour
    {
        public ProfileElementType ProfileElementType;

        private void Start()
        {
            gameObject.tag = "ProfileElement";
        }
    }
}