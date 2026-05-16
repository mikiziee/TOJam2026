using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using CodeMonkey.Utils;
using UnityEngine.InputSystem;
using Unity.VisualScripting;

public class ButtonSelfDeleter : MonoBehaviour
{
    public bool wasClicked { get; set; }

    private void Awake()
    {
        wasClicked = false;
    }

    public void OnButtonClicked()
    {
        wasClicked = true;
        print("Button " + gameObject.name + " was clicked.");
        Invoke("SetWasClickedFalse", 5f);
    }

    public void SetWasClickedFalse()
    {
        print("Button " + gameObject.name + " wasClicked reset to false.");
        wasClicked = false;
    }

    public void IncreaseDay()
    {
        Globals.currentDay++;
        print("Current day increased to: " + Globals.currentDay);
    }

}
