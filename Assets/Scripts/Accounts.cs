using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class Accounts : MonoBehaviour
{
    public List<string> accountNames = new();
    public List<string> accountIds = new();

    public TMP_Dropdown dropdown;
    
    private void Start()
    {
        using var reader = new StreamReader(Application.dataPath + "/OrganizationAccounts.csv");
        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine();
            if (line == null) continue;
            var values = line.Split(',');

            accountNames.Add(values[0]);
            accountIds.Add(values[1]);
        }
        
        dropdown.AddOptions(accountNames);
    }
}
