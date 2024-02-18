using System;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Unity.Collections;
using UnityEngine.Networking;

public class SaveData : MonoBehaviour
{
    private const string URL = "https://montecalvol26.pythonanywhere.com/";
    
    public void UploadData(string organization, string sum)
    {
        StartCoroutine(PostData(URL, organization, sum));
    }

    private static IEnumerator PostData(string url, string organization, string sum)
    {
        Debug.Log(Application.dataPath);
        var saveDirectory = Application.dataPath + "/CREDENTIALS.txt";
        
        var loadString = File.ReadAllText(saveDirectory);
        var loadContents = loadString.Split(",");

        var username = loadContents[0];
        var password = loadContents[1];
        var token = loadContents[2];
        
        var form = new WWWForm();
        form.AddField("username", username);
        form.AddField("password", password);
        form.AddField("token", token);
        
        form.AddField("organization", organization);
        form.AddField("sum", sum);

        using var www = UnityWebRequest.Post(url, form);
        yield return www.SendWebRequest();
    }
}
