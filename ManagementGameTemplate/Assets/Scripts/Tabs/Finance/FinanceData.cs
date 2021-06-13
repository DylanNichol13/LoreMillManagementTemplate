using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LoreMill
{
    public class FinanceData : MonoBehaviour
    {
        public static FinanceData instance;

        public Finance finance;

        // Start is called before the first frame update
        void Start()
        {
            instance = this;
        }
    }
}