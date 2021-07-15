using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LoreMill
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;

        //Called on continue button advancing - Main turn advancing logic will be referenced here
        public void Continue()
        {
            Debug.Log("Continue button pressed");

            //Add test data
            InboxData.instance.Test_AddData();
        }
    }
}