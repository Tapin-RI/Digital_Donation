using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Main : MonoBehaviour
{
    private string organizationName;
    private Coroutine _coroutine = null;
    
    // Utility Vars
    public GameObject[] screens;
    public ItemEdit itemEdit;
    public Accounts accounts;
    
    // Organization Options Screen Vars
    [Header("Organization Options Screen")]
    public ToggleGroup oosRadioButtons;
    
    // Item Enter Screen Vars
    [Header("Item Enter Screen")] 
    public RectTransform listViewContents;
    public GameObject itemObjectPrefab;
    
    public void OOS_NextButton()
    {
        var toggle = oosRadioButtons.ActiveToggles().FirstOrDefault();

        if (toggle!.CompareTag("0"))
        {
            organizationName = "0013h00000QYlflAAD";
        }
        
        LoadScreen(toggle!.CompareTag("1") ? 1 : 2);
    }

    public void ONS_BackButton()
    {
        LoadScreen(0);
    }

    public void ONS_NextButton()
    {
        organizationName = accounts.accountIds[accounts.dropdown.value];
        
        LoadScreen(2);
    }

    public void IES_NextButton()
    {
        _coroutine = StartCoroutine(UploadData());
        LoadScreen(3);
    }

    public void CS_CancelButton()
    {
        StopCoroutine(_coroutine);
        LoadScreen(2);
    }

    private void LoadScreen(int id)
    {
        for (var i = 0; i < screens.Length; i++)
        {
            screens[i].SetActive(i == id);
        }
    }

    private void ClearItemScreen()
    {
        itemEdit.items[0] = "";
        itemEdit.workingText = "";
        itemEdit.workingIndex = 0;
        foreach (var item in itemEdit.items)
        {
            itemEdit.RemItem();
        }
    }

    private IEnumerator UploadData()
    {
        yield return new WaitForSeconds(3f);
        var sum = itemEdit.items.Sum(float.Parse);
        
        GetComponent<SaveData>().UploadData(organizationName, sum.ToString());
        ClearItemScreen();
        LoadScreen(0);
    }
}
