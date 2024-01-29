using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ItemEdit : MonoBehaviour
{
    public RectTransform listViewContents;
    
    private string _numberOutput;
    private GameObject _currentItem;
    
    public void EnterCharacter(string character)
    {
        var itemObjectList = GameObject.FindGameObjectsWithTag("Item Object");
        
        if (_currentItem == itemObjectList[^1])
        {
            var text = itemObjectList[^1].GetComponentInChildren<TMP_Text>();
            _currentItem = itemObjectList[^1];
        
            _numberOutput += character;
            text.text = _numberOutput + " lbs";
        }
        else
        {
            _numberOutput = "";
            
            var text = itemObjectList[^1].GetComponentInChildren<TMP_Text>();
            _currentItem = itemObjectList[^1];
        
            _numberOutput += character;
            text.text = _numberOutput + " lbs";
        }
    }

    public void DeleteCharacter()
    {
        try
        {
            var itemObjectList = GameObject.FindGameObjectsWithTag("Item Object");
            var text = itemObjectList[^1].GetComponentInChildren<TMP_Text>();
            
            _numberOutput = _numberOutput.Remove(_numberOutput.Length - 1, 1);
            
            text.text = _numberOutput + " lbs";
        }
        catch
        {
            // ignore
        }
    }
    
    public void NewObjectLabel()
    {
        var labelList = GameObject.FindGameObjectsWithTag("Item Object Label");
        labelList[^1].GetComponent<TMP_Text>().text = "Item Number " + labelList.Length;
    }

    public void DeleteItem()
    {
        var itemObjectList = GameObject.FindGameObjectsWithTag("Item Object");

        try
        {
            Destroy(itemObjectList[^1]);

            foreach (var obj in itemObjectList)
            {
                var rectTransform = obj.GetComponent<RectTransform>();
                rectTransform.position -= new Vector3(0, 125, 0);
            }

            listViewContents.sizeDelta -= new Vector2(0, 125);
        }
        catch
        {
            // ignored
        }
    }
}
