using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogHandler : MonoBehaviour
{
    public static LogHandler instance;
    private Log _log;
    private Text _logBodyText;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        _log = new Log();
    }

    public Log GetLog() { return _log; }

    public void SetupLog()
    {
        if(_logBodyText == null)
        {
            _logBodyText = GameObject.Find("LogBodyText").GetComponent<Text>();
        }


        _logBodyText.text = _log.GetLog();
    }
}
