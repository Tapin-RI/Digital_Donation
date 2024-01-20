using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    // Screen Vars
    public GameObject[] screens;
    
    // Organization Options Screen Vars
    public ToggleGroup oosRadioButtons;

    public void OOS_NextButton()
    {
        var toggle = oosRadioButtons.ActiveToggles().FirstOrDefault();

        if (toggle!.CompareTag("1"))
        {
            for (var i = 0; i < screens.Length; i++)
            {
                screens[i].SetActive(i == 1);
            }
        }
        else
        {
            for (var i = 0; i < screens.Length; i++)
            {
                screens[i].SetActive(i == 2);
            }
        }
    }
}