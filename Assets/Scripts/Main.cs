using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Main : MonoBehaviour
{
    // Screen Vars
    public GameObject[] screens;
    
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
        
    }

    private void LoadScreen(int id)
    {
        for (var i = 0; i < screens.Length; i++)
        {
            screens[i].SetActive(i == id);
        }
    }
}
