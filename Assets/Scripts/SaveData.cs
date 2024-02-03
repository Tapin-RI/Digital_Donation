using System.IO;
using UnityEngine;
using UnityEditor.Scripting.Python;

public class SaveData : MonoBehaviour
{
    public void UploadData()
    {
        var scriptPath = Path.Combine(Application.dataPath, @"Scripts\Python Uploader\SaveData.py");
        PythonRunner.RunFile(scriptPath);
    }
}
