using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor.Scripting.Python;

public class SaveData : MonoBehaviour
{
    private void Start()
    {
        var scriptPath = Path.Combine(Application.dataPath, @"Scripts\Python Uploader\SaveData.py");
        PythonRunner.RunFile(scriptPath);
    }
}
