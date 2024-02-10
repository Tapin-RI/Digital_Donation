using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Main : MonoBehaviour
{
    private Coroutine _coroutine = null;
    
    // Screen Vars
    public GameObject[] screens;
    
    // Organization Options Screen Vars
    [Header("Organization Options Screen")]
    public ToggleGroup oosRadioButtons;
    
    // Item Enter Screen Vars
    [Header("Item Enter Screen")] 
    public RectTransform listViewContents;
    public GameObject itemObjectPrefab;
    public ItemEdit itemEdit;
    
    public void OOS_NextButton()
    {
        var toggle = oosRadioButtons.ActiveToggles().FirstOrDefault();

        if (toggle != null && toggle.CompareTag("0"))
        {
            itemEdit.orgName = "0013h00000QYlflAAD";
        }

        LoadScreen(toggle!.CompareTag("1") ? 1 : 2);
    }

    public void ONS_BackButton()
    {
        LoadScreen(0);
    }

    public void ONS_NextButton()
    {
        itemEdit.orgName = GetComponent<Accounts>().accountIds[GetComponent<Accounts>().dropdown.value];
        LoadScreen(2);
    }

    public void IES_NextButton()
    {
        _coroutine = StartCoroutine(UploadData()); 
        
        LoadScreen(3);
    }
    
    private bool csBackButton = false;
    public void CS_BackButton()
    {
        csBackButton = true;
        LoadScreen(2);
    }

    private void FixedUpdate()
    {
        if (!csBackButton) return;
        StopCoroutine(_coroutine);
        csBackButton = false; 
        Debug.Log("Stopped");
    }

    
    private IEnumerator UploadData()
    {
        yield return new WaitForSeconds(5f);
        
        var items = itemEdit.items;

        var saveString = itemEdit.orgName + ",";
        saveString += string.Join(",", items);
        var saveDirectory = Application.dataPath + "/SAVE_DATA/export.csv";
        
        File.WriteAllText(saveDirectory, saveString);
        
        GetComponent<SaveData>().UploadData();
        Debug.Log("Uploaded");
        LoadScreen(0);
    }

    private void LoadScreen(int id)
    {
        for (var i = 0; i < screens.Length; i++)
        {
            screens[i].SetActive(i == id);
        }
    }
}
