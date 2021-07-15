using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Log
{
    public string LogMessage = string.Empty;

    public string GetLog()
    {
        return LogMessage;
    }

    public string WriteToLog(string msg)
    {
        this.LogMessage += $"\n\n{DateTime.Now.ToString("hh:mm:ss")}: {msg}";

        return this.LogMessage;
    }
}
