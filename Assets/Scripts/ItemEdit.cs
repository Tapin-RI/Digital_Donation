using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ItemEdit : MonoBehaviour
{
    public RectTransform listViewContents;
    public GameObject itemPrefab;
    
    public List<string> items = new List<string>();

    public string workingText = "";
    public int workingIndex = 0;

    private void Start()
    {
        AddItem();
    }

    public void AddChar(string character)
    {
        workingText += character;
        items[workingIndex] = workingText;
        UpdateGUI();
    }

    public void RemChar()
    {
        try
        {
            workingText = workingText.Remove(workingText.Length - 1, 1);
            items[workingIndex] = workingText;
            UpdateGUI();
        } catch { /* ignore */ }
    }

    public void AddItem()
    {
        items.Add("");
        workingText = "";
        workingIndex = items.Count - 1;
        
        var itemObjectArray = GameObject.FindGameObjectsWithTag("Item Object");

        foreach (var obj in itemObjectArray)
        {
            var rectTransform = obj.GetComponent<RectTransform>();
            rectTransform.position += new Vector3(0, 125, 0);
        }
        
        listViewContents.sizeDelta += new Vector2(0, 125);
        Instantiate(itemPrefab, listViewContents);
        
        NewObjLbl();
    }

    public void RemItem()
    {
        try
        {
            if (items.Count == 1) return;
            
            items.RemoveAt(workingIndex);
            workingIndex = items.Count - 1;
            workingText = items[workingIndex];
            
            var itemObjectArray = GameObject.FindGameObjectsWithTag("Item Object");

            foreach (var obj in itemObjectArray)
            {
                var rectTransform = obj.GetComponent<RectTransform>();
                rectTransform.position -= new Vector3(0, 125, 0);
            }
        
            listViewContents.sizeDelta -= new Vector2(0, 125);
            Destroy(itemObjectArray[^1]);
        } catch { /* ignore */ }
    }

    private void NewObjLbl()
    {
        var labelList = GameObject.FindGameObjectsWithTag("Item Object Label");
        labelList[^1].GetComponent<TMP_Text>().text = "Item Number " + items.Count;
    }

    private void UpdateGUI()
    {
        var currentItems = GameObject.FindGameObjectsWithTag("Item Object");
        var currentItemText = currentItems[^1].GetComponentInChildren<TMP_Text>();

        currentItemText.text = workingText + " lbs";
    }
}
