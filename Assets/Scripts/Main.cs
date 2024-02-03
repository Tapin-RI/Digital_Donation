using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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

        LoadScreen(toggle!.CompareTag("1") ? 1 : 2);
    }

    public void ONS_BackButton()
    {
        LoadScreen(0);
    }

    public void ONS_NextButton()
    {
        // TODO: Add save to variable for org name.
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

        var saveString = "0013h00000QYlflAAD,";
        saveString += string.Join(",", items);
        var saveDirectory = Application.dataPath + "/SAVE_DATA/export.csv";
        
        File.WriteAllText(saveDirectory, saveString);
        
        GetComponent<SaveData>().UploadData();
        Debug.Log("Uploaded");
    }

    private void LoadScreen(int id)
    {
        for (var i = 0; i < screens.Length; i++)
        {
            screens[i].SetActive(i == id);
        }
    }
}
